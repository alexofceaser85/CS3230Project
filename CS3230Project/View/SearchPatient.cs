using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.Model.Users.Patients;
using CS3230Project.View.WindowSwitching;
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
            this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
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
                    currPatient.DateOfBirth.ToString("MM/dd/yyyy"), currPatient.Gender, currPatient.PhoneNumber,
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
            SwitchForms.SwitchBackToHome(this);
        }

        private void PatientDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (dataGridView == null || e.RowIndex >= dataGridView.RowCount - 1)
            {
                return;
            }

            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 12)
            {
                SwitchForms.Switch(this, new Appointments(this.createPatient(dataGridView.SelectedCells).PatientId));
            }
            else
            {
                if (dataGridView.CurrentRow.Selected)
                {
                    DataGridViewSelectedCellCollection cells = dataGridView.SelectedCells;
                    Form editForm = new EditPatient(this.createPatient(cells));
                    SwitchForms.Switch(this, editForm);
                }
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
