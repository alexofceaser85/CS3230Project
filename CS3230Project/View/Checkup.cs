using CS3230Project.View.WindowSwitching;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.Model.Diagnosis;
using CS3230Project.Model.Tests;
using CS3230Project.Model.Users;
using CS3230Project.Model.Users.Nurses;
using CS3230Project.Model.Users.Patients;
using CS3230Project.Model.Visits;
using CS3230Project.View.Validation;
using CS3230Project.ViewModel.Checkups;
using CS3230Project.ViewModel.Diagnosis;
using CS3230Project.ViewModel.Tests;

namespace CS3230Project.View
{
    /// <summary>
    ///   The Checkup form
    /// </summary>
    public partial class Checkup : Form
    {
        private readonly int appointmentId;
        private readonly Patient patient;
        private readonly Doctor doctor;
        private List<Diagnosis> diagnoses;
        private readonly TestsManagerViewModel testManager;
        private readonly string invalidInputErrorMessage = "Invalid Values for the checkup details";
        private readonly string invalidInputErrorHeader = "Unable to add new checkup";

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkup" /> class.
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <param name="patient">The patient</param>
        /// <param name="doctor">The doctor</param>
        public Checkup(int appointmentId, Patient patient, Doctor doctor)
        {
            this.InitializeComponent();
            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
            this.appointmentId = appointmentId;
            this.patient = patient;
            this.doctor = doctor;
            this.loadPatientAndDoctorInfo();
            this.testManager = new TestsManagerViewModel(this.appointmentId);
            this.updateTestData();
            this.checkIfVisitExists(appointmentId);
            this.updateDiagnosesData();
        }

        private void disableDiagnosisControls()
        {
            this.diagnosisDescriptionTextBox.Enabled = false;
            this.isFinalCheckBox.Enabled = false;
            this.basedOnTestResultsCheckBox.Enabled = false;
            this.submitDiagnosisButton.Enabled = false;
            this.diagnosisDescriptionLabel.Enabled = false;
        }

        private void updateDiagnosesData()
        {
            this.diagnoses = DiagnosisManagerViewModel.GetDiagnoses(this.appointmentId);

            foreach (var currDiagnosis in this.diagnoses)
            {
                this.diagnosisDataGridView.Rows.Add(currDiagnosis.DiagnosisDescription, currDiagnosis.IsFinal,
                    currDiagnosis.BasedOnTestResults);

                if (currDiagnosis.IsFinal)
                {
                    this.disableDiagnosisControls();
                    this.disableFormControls();
                    this.disableTestControls();
                }
            }
            
        }

        private void updateTestData()
        {
            this.updateCompletedTests();
            this.updateSubmittedTests();
            this.updateNonSubmittedTests();
        }

        private void updateCompletedTests()
        {
            this.CompletedTestsTable.Rows.Clear();
            foreach (var submittedTest in this.testManager.PerformedTests)
            {
                string[] testDetails =
                {
                    submittedTest.AppointmentId.ToString(), submittedTest.Code.ToString(), submittedTest.Name,
                    submittedTest.IsAbnormal.ToString(), submittedTest.TestDateTime.ToString("DD-MM-YYYY"),
                    submittedTest.Results
                };
                this.CompletedTestsTable.Rows.Add(testDetails);
            }
        }

        private void updateSubmittedTests()
        {
            foreach (var submittedTest in this.testManager.NotPerformedTests)
            {
                string[] testDetails =
                {
                    submittedTest.AppointmentId.ToString(), submittedTest.Code.ToString(), submittedTest.Name,
                    "Pending", "Pending", "Pending"
                };
                this.NotCompletedTestsTable.Rows.Add(testDetails);
            }
        }

        private void updateNonSubmittedTests()
        {
            this.PendingTestsTable.Rows.Clear();
            foreach (var submittedTest in this.testManager.NotSubmittedTests)
            {
                string[] testDetails =
                {
                    submittedTest.AppointmentId.ToString(), submittedTest.Code.ToString(), submittedTest.Name,
                };
                this.PendingTestsTable.Rows.Add(testDetails);
            }
        }

        private void checkIfVisitExists(int appointmentId)
        {
            Visit visit = CheckupManagerViewModel.GetVisit(appointmentId);
            if (visit == null)
            {
                this.submitChangesFooter1.SubmitButtonEventHandler += this.submitChangesFooter1OnSubmitButtonEventHandlerSubmitNewVisit;
                this.populateNurseComboBox();
            }
            else
            {
                this.submitChangesFooter1.SubmitButtonEventHandler +=
                    this.submitChangesFooter1OnSubmitButtonEventHandlerEditExistingVisit;
                this.displayCheckupDetails(visit);

            }
        }

        private void loadPatientAndDoctorInfo()
        {
            this.PatientNameAndIdLabel.Text = $"{patient.PatientId}, {patient.LastName}, {patient.FirstName}";
            this.PatientDateOfBirthLabel.Text = $"Birthdate: {patient.DateOfBirth}";
            this.PatientPhoneNumberLabel.Text = $"Phone: {patient.PhoneNumber}";
            this.DoctorNameAndIdLabel.Text = $"{doctor.DoctorId}, {doctor.LastName}, {doctor.FirstName}";
            this.DoctorDateOfBirthLabel.Text = $"Birthdate: {doctor.DateOfBirth}";
            this.DoctorPhoneNumberLabel.Text = $"Phone: {doctor.PhoneNumber}";
        }

        private void displayCheckupDetails(Visit visit)
        {
            this.systolicBloodPressureTextBox.Text = visit.SystolicBloodPressure.ToString();
            this.diastolicBloodPressureTextBox.Text = visit.DiastolicBloodPressure.ToString();
            this.bodyTemperatureTextBox.Text = visit.BodyTemp.ToString();
            this.pulseTextBox.Text = visit.Pulse.ToString();
            this.heightTextBox.Text = visit.Height.ToString();
            this.weightTextBox.Text = visit.Weight.ToString();
            this.symptomsTextBox.Text = visit.Symptoms;

            var nurse = NurseManager.GetNurseByID(visit.NurseID);
            this.nurseComboBox.Items.Add(nurse.FirstName + " " + nurse.LastName + " ID: " + nurse.NurseId);
            this.nurseComboBox.SelectedItem = nurse.FirstName + " " + nurse.LastName + " ID: " + nurse.NurseId;
        }

        private void disableFormControls()
        {
            this.systolicBloodPressureTextBox.Enabled = false;
            this.diastolicBloodPressureTextBox.Enabled = false;
            this.bodyTemperatureTextBox.Enabled = false;
            this.pulseTextBox.Enabled = false;
            this.heightTextBox.Enabled = false;
            this.weightTextBox.Enabled = false;
            this.symptomsTextBox.Enabled = false;
            this.nurseComboBox.Enabled = false;
            this.submitChangesFooter1.HideSubmitButton(this.submitChangesFooter1);
        }

        private void populateNurseComboBox()
        {
            foreach (var nurse in NurseManager.GetNurses())
            {
                var nurseInfo = nurse.FirstName + " " + nurse.LastName + " ID: " + nurse.NurseId;
                this.nurseComboBox.Items.Add(nurseInfo);
            }
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            SwitchForms.Switch(this, new Appointments(this.patient));
        }

        private void submitChangesFooter1OnSubmitButtonEventHandlerEditExistingVisit(object sender, EventArgs e)
        {
            try
            {
                CheckupManagerViewModel.ModifyVisit(this.getVisitInfo());
                this.testManager.SubmitTests();
                SwitchForms.Switch(this, new Appointments(this.patient));
            }
            catch (Exception)
            {
                MessageBox.Show(this.invalidInputErrorMessage, this.invalidInputErrorHeader);
            }
        }

        private void submitChangesFooter1OnSubmitButtonEventHandlerSubmitNewVisit(object sender, EventArgs e)
        {
            try
            {
                CheckupManagerViewModel.AddVisit(this.getVisitInfo());
                this.testManager.SubmitTests();
                SwitchForms.Switch(this, new Appointments(this.patient));

            }
            catch (Exception)
            {
                MessageBox.Show(this.invalidInputErrorMessage, this.invalidInputErrorHeader);
            }
        }

        private Visit getVisitInfo()
        {
            this.verifyAll();
            var nurseId = this.getNurseID(this.nurseComboBox.Text);
            Visit visit = new Visit(this.appointmentId, nurseId, Convert.ToDouble(this.bodyTemperatureTextBox.Text),
                Convert.ToInt16(this.pulseTextBox.Text), Convert.ToDouble(this.heightTextBox.Text),
                Convert.ToDouble(this.weightTextBox.Text), this.symptomsTextBox.Text,
                Convert.ToInt16(this.systolicBloodPressureTextBox.Text),
                Convert.ToInt16(this.diastolicBloodPressureTextBox.Text));
            return visit;
        }

        private int getNurseID(string nurseInfo)
        {
            string[] nurseInfoSplit = nurseInfo.Split(' ');

            if (nurseInfoSplit.Length > 2)
            {
                var firstName = nurseInfoSplit[0];
                var lastName = nurseInfoSplit[1];
                var ID = nurseInfoSplit[3];
                return Int32.Parse(ID);
            }

            return -1;

        }

        private void verifyAll()
        {
            CheckupValidation.VerifySystolicBloodPressureInput(this.systolicBloodPressureTextBox, this.systolicBloodPressureErrorMessage);
            CheckupValidation.VerifyDiastolicBloodPressureInput(this.diastolicBloodPressureTextBox, this.diastolicBloodPressureErrorMessage);
            CheckupValidation.VerifyBodyTemperatureInput(this.bodyTemperatureTextBox, this.bodyTempErrorMessage);
            CheckupValidation.VerifyPulseInput(this.pulseTextBox, this.pulseErrorMessage);
            CheckupValidation.VerifyHeightInput(this.heightTextBox, this.heightErrorMessage);
            CheckupValidation.VerifyWeightInput(this.weightTextBox, this.weightErrorMessage);
            CheckupValidation.VerifyNurseInput(this.nurseComboBox, this.nurseErrorMessage);
            CheckupValidation.VerifySymptomsInput(this.symptomsTextBox, this.symptomsErrorMessage);
        }

        private void systolicBloodPressureTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifySystolicBloodPressureInput(this.systolicBloodPressureTextBox, this.systolicBloodPressureErrorMessage);
        }

        private void diastolicBloodPressureTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyDiastolicBloodPressureInput(this.diastolicBloodPressureTextBox, this.diastolicBloodPressureErrorMessage);
        }

        private void bodyTemperatureTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyBodyTemperatureInput(this.bodyTemperatureTextBox, this.bodyTempErrorMessage);
        }

        private void pulseTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyPulseInput(this.pulseTextBox, this.pulseErrorMessage);
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyHeightInput(this.heightTextBox, this.heightErrorMessage);
        }

        private void weightTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyWeightInput(this.weightTextBox, this.weightErrorMessage);
        }

        private void nurseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyNurseInput(this.nurseComboBox, this.nurseErrorMessage);
        }

        private void symptomsTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifySymptomsInput(this.symptomsTextBox, this.symptomsErrorMessage);
        }

        private void AddTestButton_Click(object sender, EventArgs e)
        {
            var pendingTestDialog = new AddPendingTest(this.appointmentId, this.testManager.NotSubmittedTests);
            pendingTestDialog.TestAddedEvent += this.TestAddedEvent;
            pendingTestDialog.ShowDialog();
        }

        private void TestAddedEvent(object sender, TestAddedEventArgs e)
        {
            this.testManager.AddNonSubmittedTest(new NotPerformedTest(this.appointmentId, e.TestAdded.Code, e.TestAdded.Name));
            this.updateNonSubmittedTests();
        }

        private void PendingTestsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                this.testManager.RemoveNonSubmittedTest(this.testManager.NotSubmittedTests[e.RowIndex]);
                this.updateNonSubmittedTests();
            }
        }

        private void NotCompletedTestsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SwitchForms.Switch(this, new AddTestResults(this.testManager.NotPerformedTests[e.RowIndex], this.appointmentId, this.patient, this.doctor));
        }

        private void SubmitDiagnosis_Click(object sender, EventArgs e)
        {
            var diagnosis = new Diagnosis(null, this.appointmentId,
                this.diagnosisDescriptionTextBox.Text, this.isFinalCheckBox.Checked,
                this.basedOnTestResultsCheckBox.Checked);
            DiagnosisManagerViewModel.AddDiagnosis(diagnosis);
            this.diagnoses.Add(diagnosis);
            MessageBox.Show("The patient's diagnosis has been added.", "Diagnosis Added");
            this.diagnosisDescriptionTextBox.Clear();
            this.isFinalCheckBox.Checked = false;
            this.basedOnTestResultsCheckBox.Checked = false;
            this.diagnosisDataGridView.Rows.Clear();
            this.updateDiagnosesData();

            if (diagnosis.IsFinal)
            {
                this.disableFormControls();
                this.disableTestControls();
                this.disableDiagnosisControls();
            }
        }

        private void disableTestControls()
        {
            this.CompletedTestsTable.Enabled = false;
            this.NotCompletedTestsTable.Enabled = false;
            this.PendingTestsTable.Enabled = false;
            this.AddTestButton.Enabled = false;
        }
    }
}
