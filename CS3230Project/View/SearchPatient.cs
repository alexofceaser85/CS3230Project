using CS3230Project.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.Model.Users.Patients;
using CS3230Project.ViewModel.Users;

namespace CS3230Project.View
{
    /// <summary>
    ///   The search patient view
    /// </summary>
    public partial class SearchPatient : Form
    {
        private readonly string searchErrorHeader = "Unable to Search";

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
            try
            {
                List<Patient> matchingPatients = new List<Patient>();
                if (this.searchFirstAndLastNameCheckBox.Checked && this.searchByBirthDateCheckBox.Checked)
                {
                    matchingPatients = PatientManagerViewModel.GetPatientsByNameAndDateOfBirth(this.firstNameTextBox.Text,
                        this.lastNameTextBox.Text, this.dateOfBirthDatePicker.Value);
                }
                else if (this.searchFirstAndLastNameCheckBox.Checked)
                {
                    matchingPatients =
                        PatientManagerViewModel.GetPatientsByName(this.firstNameTextBox.Text, this.lastNameTextBox.Text);
                }
                else if (this.searchByBirthDateCheckBox.Checked)
                {
                    matchingPatients = PatientManagerViewModel.GetPatientsByDateOfBirth(this.dateOfBirthDatePicker.Value);
                }
                this.displayPatientData(matchingPatients);
            }
            catch (ArgumentException errorMessage)
            {
                MessageBox.Show(errorMessage.Message, this.searchErrorHeader);
            }

            
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
                    this.PatientDataGridView_CellClick;
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
                DataGridViewSelectedCellCollection cells = dataGridView.SelectedCells;
                Form editForm = new EditPatient(this.createPatient(cells));
                editForm.Location = Location;
                editForm.StartPosition = FormStartPosition.Manual;
                editForm.FormClosing += delegate { Show(); };
                Hide();
                editForm.Size = this.Size;
                editForm.ShowDialog();
                Close();
            }

        }

        private Patient createPatient(DataGridViewSelectedCellCollection cells)
        {
            string patientId = "";
            string lastName = "";
            string firstName = "";
            string dateOfBirth = "";
            string gender = "";
            string phoneNumber = "";
            string addressOne = "";
            string addressTwo = "";
            string city = "";
            string state = "";
            string zipcode = "";
            string status = "";

            for (int index = 0; index < cells.Count; index++)
            {
                switch (index)
                {
                    case 0:
                        patientId = cells[index].Value as string;
                        break;
                    case 1:
                        lastName = cells[index].Value as string;
                        break;
                    case 2:
                        firstName = cells[index].Value as string;
                        break;
                    case 3:
                        dateOfBirth = cells[index].Value as string;
                        break;
                    case 4:
                        gender = cells[index].Value as string;
                        break;
                    case 5:
                        phoneNumber = cells[index].Value as string;
                        break;
                    case 6:
                        addressOne = cells[index].Value as string;
                        break;
                    case 7:
                        addressTwo = cells[index].Value as string;
                        break;
                    case 8:
                        city = cells[index].Value as string;
                        break;
                    case 9:
                        state = cells[index].Value as string;
                        break;
                    case 10:
                        zipcode = cells[index].Value as string;
                        break;
                    case 11:
                        status = cells[index].Value as string;
                        break;
                }

            }
            
            Patient patient = new Patient(Int32.Parse(patientId), firstName, lastName, DateTime.Parse(dateOfBirth), gender, phoneNumber, addressOne, addressTwo, city,
                state, zipcode, bool.Parse(status));

            return patient;
        }
    }
}
