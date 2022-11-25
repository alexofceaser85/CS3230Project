using CS3230Project.View.WindowSwitching;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.Model.Accounts;
using CS3230Project.Model.Diagnosis;
using CS3230Project.Model.Tests;
using CS3230Project.Model.Users;
using CS3230Project.Model.Users.Nurses;
using CS3230Project.Model.Users.Patients;
using CS3230Project.Model.Visits;
using CS3230Project.Settings;
using CS3230Project.View.Validation;
using CS3230Project.ViewModel.Checkups;
using CS3230Project.ViewModel.Diagnosis;
using CS3230Project.ViewModel.Nurses;
using CS3230Project.ViewModel.Tests;

namespace CS3230Project.View
{
    /// <summary>
    ///   The Checkup form
    /// </summary>
    public partial class Checkup : Form
    {
        private List<Diagnosis> allDiagnoses
        {
            get
            {
                var allDiagnoses = new List<Diagnosis>();
                allDiagnoses.AddRange(this.diagnoses);
                allDiagnoses.AddRange(this.pendingDiagnoses);
                return allDiagnoses;
            }
        }

        private readonly int appointmentId;
        private readonly Patient patient;
        private readonly Doctor doctor;
        private List<Diagnosis> diagnoses;
        private List<Diagnosis> pendingDiagnoses;
        private bool finalDiagnosisExists;
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
            this.finalDiagnosisExists = false;
            this.loadPatientAndDoctorInfo();
            this.testManager = new TestsManagerViewModel(this.appointmentId);
            this.updateTestData();
            this.loadPageInfoForVisit(appointmentId);
            this.pendingDiagnoses = new List<Diagnosis>();
            this.updateDiagnosesData();
        }

        private void updateDiagnosesData()
        {
            this.diagnosisDataGridView.Rows.Clear();
            this.diagnoses = DiagnosisManagerViewModel.GetDiagnoses(this.appointmentId);

            foreach (var currDiagnosis in this.diagnoses)
            {
                this.diagnosisDataGridView.Rows.Add(currDiagnosis.DiagnosisId, currDiagnosis.DiagnosisDescription, currDiagnosis.IsFinal,
                    currDiagnosis.BasedOnTestResults);

                if (currDiagnosis.IsFinal)
                {
                    this.finalDiagnosisExists = true;
                    this.submitDiagnosisButton.Enabled = false;
                    this.disableFormControls();
                    this.disableTestControls();
                }
            }

            foreach (var currPendingDiagnosis in this.pendingDiagnoses)
            {
                this.diagnosisDataGridView.Rows.Add("Pending", currPendingDiagnosis.DiagnosisDescription,
                    currPendingDiagnosis.IsFinal,
                    currPendingDiagnosis.BasedOnTestResults);
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
                    submittedTest.IsAbnormal.ToString(), submittedTest.TestDateTime.ToString(AppointmentSettings.DateTimeFormat),
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

        private void loadPageInfoForVisit(int appointmentId)
        {
            Visit visit = CheckupManagerViewModel.GetVisit(appointmentId);
            if (visit == null)
            {
                this.submitChangesFooter1.SubmitButtonEventHandler += this.submitChangesFooter1OnSubmitButtonEventHandlerSubmitNewVisit;
                this.displayCheckupDetailsForNewVisit();
            }
            else
            {
                this.submitChangesFooter1.SubmitButtonEventHandler +=
                    this.submitChangesFooter1OnSubmitButtonEventHandlerEditExistingVisit;
                this.displayCheckupDetailsForExistingVisit(visit);

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

        private void displayCheckupDetailsForNewVisit()
        {
            this.NurseInfoTextBox.Text =
                $"{CurrentUser.User.Id}: {CurrentUser.User.LastName}, {CurrentUser.User.FirstName}";
        }

        private void displayCheckupDetailsForExistingVisit(Visit visit)
        {
            var visitNurse = NurseManagerViewModel.GetNurseByID(visit.NurseID);
            this.systolicBloodPressureTextBox.Text = visit.SystolicBloodPressure.ToString();
            this.diastolicBloodPressureTextBox.Text = visit.DiastolicBloodPressure.ToString();
            this.bodyTemperatureTextBox.Text = visit.BodyTemp.ToString();
            this.pulseTextBox.Text = visit.Pulse.ToString();
            this.heightTextBox.Text = visit.Height.ToString();
            this.weightTextBox.Text = visit.Weight.ToString();
            this.symptomsTextBox.Text = visit.Symptoms;
            this.NurseInfoTextBox.Text =
                $"{visitNurse.Id}: {visitNurse.LastName}, {visitNurse.FirstName}";
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
            this.submitChangesFooter1.HideSubmitButton(this.submitChangesFooter1);
        }

        private void enableFormControls()
        {
            this.systolicBloodPressureTextBox.Enabled = true;
            this.diastolicBloodPressureTextBox.Enabled = true;
            this.bodyTemperatureTextBox.Enabled = true;
            this.pulseTextBox.Enabled = true;
            this.heightTextBox.Enabled = true;
            this.weightTextBox.Enabled = true;
            this.symptomsTextBox.Enabled = true;
            this.submitChangesFooter1.ShowSubmitButton(this.submitChangesFooter1);
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
                this.submitDiagnoses();
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
                this.submitDiagnoses();
                SwitchForms.Switch(this, new Appointments(this.patient));

            }
            catch (Exception)
            {
                MessageBox.Show(this.invalidInputErrorMessage, this.invalidInputErrorHeader);
            }
        }

        private void submitDiagnoses()
        {
            DiagnosisManagerViewModel.AddDiagnosises(this.pendingDiagnoses);
            this.pendingDiagnoses.Clear();
        }

        private Visit getVisitInfo()
        {
            this.verifyAll();
            var nurseId = CurrentUser.User.Id;
            Visit visit = new Visit(this.appointmentId, nurseId, Convert.ToDouble(this.bodyTemperatureTextBox.Text),
                Convert.ToInt16(this.pulseTextBox.Text), Convert.ToDouble(this.heightTextBox.Text),
                Convert.ToDouble(this.weightTextBox.Text), this.symptomsTextBox.Text,
                Convert.ToInt16(this.systolicBloodPressureTextBox.Text),
                Convert.ToInt16(this.diastolicBloodPressureTextBox.Text));
            return visit;
        }

        private void verifyAll()
        {
            CheckupValidation.VerifySystolicBloodPressureInput(this.systolicBloodPressureTextBox, this.systolicBloodPressureErrorMessage);
            CheckupValidation.VerifyDiastolicBloodPressureInput(this.diastolicBloodPressureTextBox, this.diastolicBloodPressureErrorMessage);
            CheckupValidation.VerifyBodyTemperatureInput(this.bodyTemperatureTextBox, this.bodyTempErrorMessage);
            CheckupValidation.VerifyPulseInput(this.pulseTextBox, this.pulseErrorMessage);
            CheckupValidation.VerifyHeightInput(this.heightTextBox, this.heightErrorMessage);
            CheckupValidation.VerifyWeightInput(this.weightTextBox, this.weightErrorMessage);
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
            var modifyDiagnosisDialog = new ModifyDiagnosis(null, this.appointmentId);
            modifyDiagnosisDialog.AddDiagnosisSubmittedEvent += this.ModifyDiagnosisDialogOnAddDiagnosisSubmittedEvent;
            modifyDiagnosisDialog.ShowDialog();
        }

        private void ModifyDiagnosisDialogOnRemoveDiagnosisSubmittedEvent(object sender, DiagnosisSubmitEventArgs e)
        {
            if (e.DiagnosisSubmitted.DiagnosisId == null)
            {
                this.pendingDiagnoses.Remove(e.DiagnosisSubmitted);
            }
            
            this.enableControlsAndUpdateData();
        }

        private void ModifyDiagnosisDialogOnAddDiagnosisSubmittedEvent(object sender, DiagnosisSubmitEventArgs e)
        {
            this.pendingDiagnoses.Add(e.DiagnosisSubmitted);
            this.updateDiagnosesData();
        }

        private void DiagnosisDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.finalDiagnosisExists)
            {
                var diagnosisToModify = this.allDiagnoses[e.RowIndex];
                var modifyDiagnosisDialog = new ModifyDiagnosis(diagnosisToModify, this.appointmentId);
                modifyDiagnosisDialog.RemoveDiagnosisSubmittedEvent += ModifyDiagnosisDialogOnRemoveDiagnosisSubmittedEvent;

                if (diagnosisToModify?.DiagnosisId != null)
                {
                    modifyDiagnosisDialog.ModifyDiagnosisSubmittedEvent += this.DiagnosisSubmitEvent;
                    modifyDiagnosisDialog.ShowDialog();
                }
                else
                {
                    modifyDiagnosisDialog.ModifyDiagnosisSubmittedEvent += ModifyDiagnosisDialogOnModifyDiagnosisSubmittedEvent;
                    modifyDiagnosisDialog.ShowDialog();
                }
            }
        }

        private void ModifyDiagnosisDialogOnModifyDiagnosisSubmittedEvent(object sender, DiagnosisSubmitEventArgs e)
        {

            if (e.DiagnosisSubmitted != null)
            {
                int diagnosisIndex = this.pendingDiagnoses.IndexOf(e.DiagnosisToEdit);

                if (diagnosisIndex != -1)
                {
                    this.pendingDiagnoses[diagnosisIndex] = e.DiagnosisSubmitted;
                }

                this.enableControlsAndUpdateData();
            }
        }

        private void disableTestControls()
        {
            this.CompletedTestsTable.Enabled = false;
            this.NotCompletedTestsTable.Enabled = false;
            this.PendingTestsTable.Enabled = false;
            this.AddTestButton.Enabled = false;
        }

        private void enableTestControls()
        {
            this.CompletedTestsTable.Enabled = true;
            this.NotCompletedTestsTable.Enabled = true;
            this.PendingTestsTable.Enabled = true;
            this.AddTestButton.Enabled = true;
        }

        private void DiagnosisSubmitEvent(object sender, DiagnosisSubmitEventArgs e)
        {
            this.enableControlsAndUpdateData();
        }

        private void enableControlsAndUpdateData()
        {
            this.enableFormControls();
            this.enableTestControls();
            this.submitDiagnosisButton.Enabled = true;
            this.diagnosisDataGridView.Rows.Clear();
            this.updateDiagnosesData();
        }
    }
}
