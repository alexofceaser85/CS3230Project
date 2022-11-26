using CS3230Project.View.WindowSwitching;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.Model.Diagnosis;
using CS3230Project.Model.Tests;
using CS3230Project.Model.Visits;
using CS3230Project.ViewModel.AdminVisitsSearch;
using CS3230Project.ViewModel.Diagnosis;

namespace CS3230Project.View
{
    /// <summary>
    ///   The admin visits search form
    /// </summary>
    public partial class AdminVisitsSearch : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminVisitsSearch" /> class.
        ///
        /// Precondition: none
        /// </summary>
        public AdminVisitsSearch()
        {
            InitializeComponent();
            this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
        }

        private void FooterOnBackButton_Click(object sender, EventArgs e)
        {
            SwitchForms.SwitchBackToAdminHome(this);
        }

        private void getVisitsButton_Click(object sender, EventArgs e)
        {
            this.visitsDataGridView.Rows.Clear();
            List<AdminSearchVisit> visits = AdminVisitsSearchViewModel.GetAllVisitsBetweenDates
                (this.startDateTimePicker.Value, this.endDateTimePicker.Value);

            foreach (var currVisit in visits)
            {
                this.visitsDataGridView.Rows.Add(currVisit.AppointmentDateTime.ToString("MM-dd-yyyy"), currVisit.AppointmentId, 
                    currVisit.PatientId, currVisit.PatientFirstName + " " + currVisit.PatientLastName, currVisit.DoctorFirstName + " " + 
                    currVisit.DoctorLastName, currVisit.NurseFirstName + " " + currVisit.NurseLastName);
            }
        }

        private void visitsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var appointmentId = (int)this.visitsDataGridView.Rows[e.RowIndex].Cells[1].Value;
                this.loadTests(appointmentId);
                this.loadDiagnoses(appointmentId);
            }
            
        }

        private void loadTests(int appointmentId)
        {
            this.testsDataGridView.Rows.Clear();
            List<AdminSearchTest> tests = AdminVisitsSearchViewModel.GetAllAdminSearchTestsForAppointment(appointmentId);

            foreach (var currTest in tests)
            {
                this.testsDataGridView.Rows.Add(currTest.Name, currTest.Date, currTest.Results, currTest.IsAbnormal ? "Yes" : "No");
            }
        }

        private void loadDiagnoses(int appointmentId)
        {
            this.diagnosesDataGridView.Rows.Clear();
            List<Diagnosis> diagnoses = DiagnosisManagerViewModel.GetDiagnoses(appointmentId);

            foreach (var currDiagnosis in diagnoses)
            {
                this.diagnosesDataGridView.Rows.Add(currDiagnosis.DiagnosisDescription, currDiagnosis.IsFinal ? "Yes" : "No",
                    currDiagnosis.BasedOnTestResults ? "Yes" : "No");
            }
        }
    }
}
