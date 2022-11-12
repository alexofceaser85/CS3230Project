using System;
using System.Windows.Forms;
using CS3230Project.Model.Tests;
using CS3230Project.Model.Users;
using CS3230Project.Model.Users.Patients;
using CS3230Project.View.Validation;
using CS3230Project.View.WindowSwitching;
using CS3230Project.ViewModel.Tests;

namespace CS3230Project.View
{
    /// <summary>
    /// The form to add the test results
    /// </summary>
    public partial class AddTestResults : Form
    {
        private readonly string invalidInputErrorMessage = "Invalid Values for Adding Results";
        private readonly string invalidInputErrorHeader = "Unable to Add Results";

        private readonly NotPerformedTest testToAddResults;
        private readonly int appointmentId;
        private readonly Patient patient;
        private readonly Doctor doctor;
        private readonly TestsManagerViewModel testManager;
        /// <summary>
        /// Initiates a new <see cref="AddTestResults"/>
        /// </summary>
        /// <param name="testToAddResults">The test to add results to</param>
        /// <param name="appointmentId">The appointment Id</param>
        /// <param name="patient">The patient</param>
        /// <param name="doctor">The doctor</param>
        public AddTestResults(NotPerformedTest testToAddResults, int appointmentId, Patient patient, Doctor doctor)
        {
            this.testManager = new TestsManagerViewModel(this.appointmentId);
            this.appointmentId = appointmentId;
            this.patient = patient;
            this.doctor = doctor;
            this.testToAddResults = testToAddResults;
            this.InitializeComponent();
            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.submitChangesFooter1.SubmitButtonEventHandler += this.SubmitChangesFooter1OnSubmitButtonEventHandler;
            this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
            this.TestResultsHeader.Text += $" For {this.testToAddResults.Name}";
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            SwitchForms.Switch(this, new Checkup(this.appointmentId, this.patient, this.doctor));
        }

        private void SubmitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            try
            {
                this.validateAll();
                this.testManager.AddTestResults(new PerformedTest(this.appointmentId, this.testToAddResults.Code,
                    this.testToAddResults.Name, this.TestResultsTextInput.Text, this.TestAbnormalCheckBox.Checked,
                    this.TestDateTimePicker.Value));
                SwitchForms.Switch(this, new Checkup(this.appointmentId, this.patient, this.doctor));
            }
            catch (ArgumentException)
            {
                MessageBox.Show(this.invalidInputErrorHeader, this.invalidInputErrorMessage);
            }
        }

        private void validateAll()
        {
            TestValidation.VerifyDateInput(this.TestDateTimePicker, this.TestDateErrorMessage);
            TestValidation.VerifyTestResults(this.TestResultsTextInput, this.ResultsErrorMessage);
        }
    }
}
