using System;
using System.Windows.Forms;
using CS3230Project.Model.Diagnosis;
using CS3230Project.View.Validation;
using CS3230Project.ViewModel.Diagnosis;

namespace CS3230Project.View
{
    public partial class ModifyDiagnosis : Form
    {
        private Diagnosis diagnosis;
        private int appointmentId;

        public event EventHandler<DiagnosisSubmitEventArgs> DiagnosisSubmittedEvent;

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
            }

            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.submitChangesFooter1.SubmitButtonEventHandler += this.SubmitChangesFooter1OnSubmitButtonEventHandler;
        }

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
    }

    public class DiagnosisSubmitEventArgs : EventArgs
    {
        public Diagnosis DiagnosisSubmitted { get; set; }
    }
}
