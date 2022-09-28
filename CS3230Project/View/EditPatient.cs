using CS3230Project.Model.Accounts;
using System;
using System.Windows.Forms;
using CS3230Project.Model.Users.Patients;

namespace CS3230Project.View
{
    /// <summary>
    ///   The edit patient view.
    /// </summary>
    public partial class EditPatient : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditPatient" /> class.
        ///s </summary>
        /// <param name="patient">The patient.</param>
        public EditPatient(Patient patient)
        {
            this.InitializeComponent();
            this.bindLabelsToCurrentUser();
            this.setStatusComboBoxValues();
            this.loadPatientData(patient);
        }

        private void setStatusComboBoxValues()
        {
            //TODO: use enum
            this.statusComboBox.Items.Add("Active");
            this.statusComboBox.Items.Add("Inactive");
        }

        private void loadPatientData(Patient patient)
        {
            this.patientFirstNameTextBox.Text = patient.FirstName;
            this.patientLastNameTextBox.Text = patient.LastName;
            this.patientDateOfBirthPicker.Value = patient.DateOfBirth;
            this.patientGenderDropBox.Text = patient.Gender;
            this.patientPhoneNumberTextBox.Text = patient.PhoneNumber;
            this.patientAddressOneTextBox.Text = patient.AddressOne;
            this.patientAddressTwoTextBox.Text = patient.AddressTwo;
            this.patientCityTextBox.Text = patient.City;
            this.patientStateComboBox.Text = patient.State;
            this.patientZipCodeComboBox.Text = patient.Zipcode;
            this.statusComboBox.Text = patient.Status.ToString();
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

        private void submitChangesButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
