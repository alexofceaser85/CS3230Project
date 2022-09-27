using CS3230Project.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.Model.Users.Patients;

namespace CS3230Project.View
{
    /// <summary>
    ///   The search patient view
    /// </summary>
    public partial class SearchPatient : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPatient" /> class.
        /// </summary>
        public SearchPatient()
        {
            this.InitializeComponent();
            this.bindLabelsToCurrentUser();
        }

        private void bindLabelsToCurrentUser()
        {
            this.loggedInAsLabel.Text = $"Logged In As: {CurrentUser.User.UserName}";
            this.userIdLabel.Text = $"User ID: {CurrentUser.User.Id}";
            this.nameLabel.Text = $"Name: {CurrentUser.User.FirstName} {CurrentUser.User.LastName}";
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            Form homeForm = new Login();
            homeForm.Location = Location;
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.FormClosing += delegate { Show(); };
            Hide();
            homeForm.Size = this.Size;
            homeForm.ShowDialog();
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<Patient> matchingPatients = new List<Patient>();
            if (this.searchFirstAndLastNameCheckBox.Checked && this.searchByBirthDateCheckBox.Checked)
            {
                matchingPatients = PatientManager.GetPatientsByNameAndDateOfBirth(this.firstNameTextBox.Text,
                    this.lastNameTextBox.Text, this.dateOfBirthDatePicker.Value);
            }
            else if (this.searchFirstAndLastNameCheckBox.Checked)
            {
                matchingPatients =
                    PatientManager.GetPatientsByName(this.firstNameTextBox.Text, this.lastNameTextBox.Text);
            }
            else if (this.searchByBirthDateCheckBox.Checked)
            {
                matchingPatients = PatientManager.GetPatientsByDateOfBirth(this.dateOfBirthDatePicker.Value);
            }
            this.displayPatientData(matchingPatients);
        }

        private void displayPatientData(List<Patient> patientsToDisplay)
        {
            this.PatientDataGridView.Rows.Clear();
            foreach (var currPatient in patientsToDisplay)
            {
                string[] patientDetails =
                {
                    currPatient.PatientId.ToString(), currPatient.LastName, currPatient.FirstName,
                    currPatient.DateOfBirth.ToString(), currPatient.Gender, currPatient.PhoneNumber,
                    currPatient.AddressOne, currPatient.AddressTwo, currPatient.City, currPatient.State,
                    currPatient.Zipcode, currPatient.Status.ToString()
                };
                this.PatientDataGridView.Rows.Add(patientDetails);
                this.PatientDataGridView.CellClick +=
                    new DataGridViewCellEventHandler(this.PatientDataGridView_CellClick);
            }
        }

        private void backToHomeButton_Click(object sender, EventArgs e)
        {
            Form homeForm = new Home();
            homeForm.Location = Location;
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.FormClosing += delegate { Show(); };
            Hide();
            homeForm.Size = this.Size;
            homeForm.ShowDialog();
            Close();
        }

        private void PatientDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView == null)
            {
                return;
            }

            if (dataGridView.CurrentRow.Selected)
            {
                Form editForm = new EditPatient();
                editForm.Location = Location;
                editForm.StartPosition = FormStartPosition.Manual;
                editForm.FormClosing += delegate { Show(); };
                Hide();
                editForm.Size = this.Size;
                editForm.ShowDialog();
                Close();
            }
            
        }
    }
}
