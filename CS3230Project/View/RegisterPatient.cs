using System;
using System.Windows.Forms;
using CS3230Project.Model.Accounts;
using CS3230Project.Model.Users.Patients;
using CS3230Project.ViewModel.Accounts;
using CS3230Project.ViewModel.Users;

namespace CS3230Project.View
{
    /// <summary>
    /// The screen to register a patient
    /// </summary>
    public partial class RegisterPatient : Form
    {

        private readonly string loginErrorHeader = "Unable to add new patient";

        /// <summary>
        /// Instantiates a new <see cref="RegisterPatient"/>
        /// </summary>
        public RegisterPatient()
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

        private void returnToHomeButton_Click(object sender, EventArgs e)
        {
            Form homeForm = new Home();
            homeForm.Location = Location;
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.FormClosing += delegate { Show(); };
            Hide();
            homeForm.Size = Size;
            homeForm.ShowDialog();
            Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                var patientToAdd = new Patient(
                    0,
                    this.patientLastNameTextBox.Text,
                    this.patientFirstNameTextBox.Text,
                    this.patientDateOfBirthPicker.Value,
                    this.patientGenderDropBox.SelectedItem?.ToString(),
                    this.patientPhoneNumberTextBox.Text,
                    this.patientAddressOneTextBox.Text,
                    this.patientAddressTwoTextBox.Text,
                    this.patientCityTextBox.Text,
                    this.patientStateComboBox.SelectedItem?.ToString(),
                    this.patientZipCodeComboBox.Text,
                    true
                );
                PatientManagerViewModel.AddPatient(patientToAdd);
                Form homeForm = new Home();
                homeForm.Location = Location;
                homeForm.StartPosition = FormStartPosition.Manual;
                homeForm.FormClosing += delegate { Show(); };
                Hide();
                homeForm.Size = Size;
                homeForm.ShowDialog();
                Close();
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, this.loginErrorHeader);
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            Form homeForm = new Login();
            homeForm.Location = Location;
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.FormClosing += delegate { Show(); };
            Hide();
            homeForm.Size = Size;
            homeForm.ShowDialog();
            Close();
        }
    }
}
