using System;
using System.Windows.Forms;
using CS3230Project.Model.Diagnosis;
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

        /// <summary>
        /// The event that a diagnosis was added or modified
        /// </summary>
        public event EventHandler<DiagnosisSubmitEventArgs> DiagnosisSubmittedEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyDiagnosis" /> class.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="diagnosis">The diagnosis.</param>
        /// <param name="appointmentId">The appointment identifier.</param>
        public ModifyDiagnosis(Diagnosis diagnosis, int appointmentId)
        {
            InitializeComponent();
            this.diagnosis = diagnosis;
            this.appointmentId = appointmentId;

            if (this.diagnosis != null)
            {
                this.diagnosisDescriptionTextBox.Text = diagnosis.DiagnosisDescription;
                this.isFinalCheckBox.Checked = diagnosis.IsFinal;
                this.basedOnTestResultsCheckBox.Checked = diagnosis.BasedOnTestResults;
                this.removeDiagnosisButton.Show();
            }
            else
            {
                this.removeDiagnosisButton.Hide();
            }

            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.submitChangesFooter1.SubmitButtonEventHandler += this.SubmitChangesFooter1OnSubmitButtonEventHandler;
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
                this.DiagnosisSubmittedEvent?.Invoke(this, new DiagnosisSubmitEventArgs
                {
                    DiagnosisSubmitted =
                        new Diagnosis(this.diagnosis.DiagnosisId, this.appointmentId, this.diagnosisDescriptionTextBox.Text, 
                            this.isFinalCheckBox.Checked, this.basedOnTestResultsCheckBox.Checked)
                });
            }
            else
            {
                this.DiagnosisSubmittedEvent?.Invoke(this, new DiagnosisSubmitEventArgs
                {
                    DiagnosisSubmitted =
                        new Diagnosis(null, this.appointmentId, this.diagnosisDescriptionTextBox.Text,
                            this.isFinalCheckBox.Checked, this.basedOnTestResultsCheckBox.Checked)
                });
            }

            
        }

        private void SubmitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            if (this.diagnosis == null)
            {
                if (DiagnosisValidation.VerifyDiagnosisDescription(this.diagnosisDescriptionTextBox,
                        this.diagnosisDescriptionErrorMessage))
                {
                    var diagnosis = new Diagnosis(null, this.appointmentId,
                        this.diagnosisDescriptionTextBox.Text, this.isFinalCheckBox.Checked,
                        this.basedOnTestResultsCheckBox.Checked);
                    DiagnosisManagerViewModel.AddDiagnosis(diagnosis);
                    this.OnDiagnosisSubmittedEvent(new DiagnosisSubmitEventArgs {DiagnosisSubmitted = diagnosis});
                    this.Close();
                }
            }
            else
            {
                if (DiagnosisValidation.VerifyDiagnosisDescription(this.diagnosisDescriptionTextBox,
                        this.diagnosisDescriptionErrorMessage))
                {
                    var diagnosis = new Diagnosis(this.diagnosis.DiagnosisId, this.diagnosis.AppointmentId,
                        this.diagnosisDescriptionTextBox.Text, this.isFinalCheckBox.Checked,
                        this.basedOnTestResultsCheckBox.Checked);
                    DiagnosisManagerViewModel.ModifyDiagnosis(diagnosis);
                    this.OnDiagnosisSubmittedEvent(new DiagnosisSubmitEventArgs { DiagnosisSubmitted = diagnosis });
                    this.Close();
                }
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
            this.OnDiagnosisSubmittedEvent(new DiagnosisSubmitEventArgs { DiagnosisSubmitted = diagnosis });
            this.Close();
        }
    }

    /// <summary>
    ///   The event arguments for a diagnosis added or modified
    /// </summary>
    public class DiagnosisSubmitEventArgs : EventArgs
    {
        /// <summary>
        /// The diagnosis submitted
        /// </summary>
        /// <value>The diagnosis submitted.</value>
        public Diagnosis DiagnosisSubmitted { get; set; }
    }
}
