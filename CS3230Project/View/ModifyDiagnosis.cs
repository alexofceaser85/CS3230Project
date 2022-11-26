using System;
using System.Windows.Forms;
using CS3230Project.Model.Diagnosis;
using CS3230Project.Model.Users.Patients;
using CS3230Project.View.Validation;
using CS3230Project.ViewModel.Diagnosis;

namespace CS3230Project.View
{
    /// <summary>
    ///   The form to add or modify a diagnosis
    /// </summary>
    public partial class ModifyDiagnosis : Form
    {
        private readonly Diagnosis diagnosis;
        private readonly int appointmentId;
        private Patient patient;
        private string cannotSubmitAppointmentWhenPatientIsNotActive = "Cannot submit appointment when patient is not active";
        private string cannotSubmitAppointment = "Cannot Submit Appointment";
        private const string YesString = "Yes";

        /// <summary>
        /// The event that a diagnosis was removed
        /// </summary>
        public event EventHandler<DiagnosisSubmitEventArgs> RemoveDiagnosisSubmittedEvent;

        /// <summary>
        /// The event that a diagnosis was modified
        /// </summary>
        public event EventHandler<DiagnosisSubmitEventArgs> ModifyDiagnosisSubmittedEvent;

        /// <summary>
        /// The event that a diagnosis was added
        /// </summary>
        public event EventHandler<DiagnosisSubmitEventArgs> AddDiagnosisSubmittedEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyDiagnosis" /> class.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="diagnosis">The diagnosis.</param>
        /// <param name="appointmentId">The appointment identifier.</param>
        public ModifyDiagnosis(Diagnosis diagnosis, int appointmentId, Patient patient)
        {
            InitializeComponent();
            this.diagnosis = diagnosis;
            this.appointmentId = appointmentId;
            this.patient = patient;

            if (this.diagnosis != null)
            {
                this.diagnosisDescriptionTextBox.Text = diagnosis.DiagnosisDescription;
                this.setComboBoxes(diagnosis.IsFinal, diagnosis.BasedOnTestResults);
                this.removeDiagnosisButton.Show();
            }
            else
            {
                this.removeDiagnosisButton.Hide();
                this.isFinalComboBox.SelectedItem = this.isFinalComboBox.Items[1];
                this.basedOnTestResultsComboBox.SelectedItem = this.basedOnTestResultsComboBox.Items[1];
            }

            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.submitChangesFooter1.SubmitButtonEventHandler += this.SubmitChangesFooter1OnSubmitButtonEventHandler;
            this.disableFieldsAndActionsIfPatientIsNotActive();
        }

        private void disableFieldsAndActionsIfPatientIsNotActive()
        {
            if (!this.patient.IsActive)
            {
                this.diagnosisDescriptionTextBox.Enabled = false;
                this.isFinalComboBox.Enabled = false;
                this.basedOnTestResultsComboBox.Enabled = false;
                this.removeDiagnosisButton.Enabled = false;
            }
        }

        private void setComboBoxes(bool isFinal, bool basedOnTest)
        {
            this.isFinalComboBox.SelectedItem = isFinal ? this.isFinalComboBox.Items[0] : this.isFinalComboBox.Items[1];
            this.basedOnTestResultsComboBox.SelectedItem = basedOnTest ? this.basedOnTestResultsComboBox.Items[0] : this.basedOnTestResultsComboBox.Items[1];
        }

        /// <summary>
        /// The event on an add or modify diagnosis
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="args">The <see cref="DiagnosisSubmitEventArgs" /> instance containing the event data.</param>
        protected virtual void OnDiagnosisSubmittedEvent(DiagnosisSubmitEventArgs args)
        {
            if (this.diagnosis != null)
            {
                this.ModifyDiagnosisSubmittedEvent?.Invoke(this, new DiagnosisSubmitEventArgs
                {
                    DiagnosisToEdit = this.diagnosis,
                    DiagnosisSubmitted =
                        new Diagnosis(this.diagnosis.DiagnosisId, this.appointmentId, this.diagnosisDescriptionTextBox.Text, 
                            (string)this.isFinalComboBox.SelectedItem == ModifyDiagnosis.YesString, (string)this.basedOnTestResultsComboBox.SelectedItem == ModifyDiagnosis.YesString)
                });
            }
            else
            {
                this.AddDiagnosisSubmittedEvent?.Invoke(this, new DiagnosisSubmitEventArgs
                {
                    DiagnosisToEdit = this.diagnosis,
                    DiagnosisSubmitted =
                        new Diagnosis(null, this.appointmentId, this.diagnosisDescriptionTextBox.Text,
                            (string)this.isFinalComboBox.SelectedItem == ModifyDiagnosis.YesString, (string)this.basedOnTestResultsComboBox.SelectedItem == ModifyDiagnosis.YesString)
                });
            }

            
        }

        private void SubmitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            if (this.diagnosis == null && this.patient.IsActive)
            {
                if (DiagnosisValidation.VerifyDiagnosisDescription(this.diagnosisDescriptionTextBox,
                        this.diagnosisDescriptionErrorMessage))
                {
                    var newDiagnosis = new Diagnosis(null, this.appointmentId,
                        this.diagnosisDescriptionTextBox.Text, (string)this.isFinalComboBox.SelectedItem == ModifyDiagnosis.YesString,
                        (string)this.basedOnTestResultsComboBox.SelectedItem == ModifyDiagnosis.YesString);
                    this.OnDiagnosisSubmittedEvent(new DiagnosisSubmitEventArgs { DiagnosisToEdit = this.diagnosis, DiagnosisSubmitted = newDiagnosis });
                    this.Close();
                }
            }
            else if (this.diagnosis != null && this.patient.IsActive)
            {
                if (DiagnosisValidation.VerifyDiagnosisDescription(this.diagnosisDescriptionTextBox,
                        this.diagnosisDescriptionErrorMessage))
                {
                    var newDiagnosis = new Diagnosis(this.diagnosis.DiagnosisId, this.diagnosis.AppointmentId,
                        this.diagnosisDescriptionTextBox.Text, (string)this.isFinalComboBox.SelectedItem == ModifyDiagnosis.YesString,
                        (string)this.basedOnTestResultsComboBox.SelectedItem == ModifyDiagnosis.YesString);
                    DiagnosisManagerViewModel.ModifyDiagnosis(newDiagnosis);
                    this.OnDiagnosisSubmittedEvent(new DiagnosisSubmitEventArgs { DiagnosisToEdit = this.diagnosis, DiagnosisSubmitted = newDiagnosis });
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(this.cannotSubmitAppointmentWhenPatientIsNotActive, this.cannotSubmitAppointment);
            }
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void diagnosisDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            DiagnosisValidation.VerifyDiagnosisDescription(this.diagnosisDescriptionTextBox, this.diagnosisDescriptionErrorMessage);
        }

        private void RemoveDiagnosis_Click(object sender, EventArgs e)
        {
            if (this.diagnosis.DiagnosisId != null)
            {
                DiagnosisManagerViewModel.RemoveDiagnosis((int)this.diagnosis.DiagnosisId);
            }
            this.RemoveDiagnosisSubmittedEvent?.Invoke(this, new DiagnosisSubmitEventArgs { DiagnosisSubmitted = diagnosis });
            this.Close();
        }
    }

    /// <summary>
    ///   The event arguments for a diagnosis added or modified
    /// </summary>
    public class DiagnosisSubmitEventArgs : EventArgs
    {
        /// <summary>
        /// The old diagnosis
        /// </summary>
        public Diagnosis DiagnosisToEdit { get; set; }
        /// <summary>
        /// The diagnosis submitted
        /// </summary>
        /// <value>The diagnosis submitted.</value>
        public Diagnosis DiagnosisSubmitted { get; set; }
    }
}
