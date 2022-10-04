using CS3230Project.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.Model.Users.Patients;

namespace CS3230Project.View
{
    /// <summary>
    ///   The edit patient view.
    /// </summary>
    public partial class EditPatient : Form
    {
        private Dictionary<string, string> updatedDetails;
        private string[] states;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditPatient" /> class.
        ///s </summary>
        /// <param name="patient">The patient.</param>
        public EditPatient(Patient patient)
        {
            this.InitializeComponent();
            this.updatedDetails = new Dictionary<string, string>();
            this.bindLabelsToCurrentUser();
            this.loadPatientData(patient);
            this.updatedDetails.Add("PatientId", patient.PatientId.ToString());
        }

        private void loadPatientData(Patient patient)
        {
            this.patientFirstNameTextBox.Text = patient.FirstName;
            this.patientLastNameTextBox.Text = patient.LastName;
            this.patientDateOfBirthPicker.Value = patient.DateOfBirth;
            this.patientGenderComboBox.Text = patient.Gender;
            this.patientPhoneNumberTextBox.Text = patient.PhoneNumber;
            this.patientAddressOneTextBox.Text = patient.AddressOne;
            this.patientAddressTwoTextBox.Text = patient.AddressTwo;
            this.patientCityTextBox.Text = patient.City;
            this.patientStateComboBox.Text = patient.State;
            this.patientZipcodeTextBox.Text = patient.Zipcode;
            this.patientStatusComboBox.Text = patient.Status.ToString();

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
            PatientManager.ModifyPatient(this.updatedDetails);
            Form searchPatientForm = new SearchPatient();
            searchPatientForm.Location = Location;
            searchPatientForm.StartPosition = FormStartPosition.Manual;
            searchPatientForm.FormClosing += delegate { Show(); };
            Hide();
            searchPatientForm.Size = this.Size;
            searchPatientForm.ShowDialog();
            Close();
        }

        private void patientDateOfBirthPicker_ValueChanged(object sender, EventArgs e)
        {
            if (((DateTimePicker)sender).Name != null && !this.updatedDetails.ContainsKey(((DateTimePicker)sender).Name))
            {
                this.updatedDetails.Add(((DateTimePicker)sender).Name, ((DateTimePicker)sender).Value.ToString("yyyy-MM-dd"));
            }
            else if (((DateTimePicker)sender).Name != null && this.updatedDetails.ContainsKey(((DateTimePicker)sender).Name))
            {
                this.updatedDetails[((DateTimePicker)sender).Name] = ((DateTimePicker)sender).Value.ToString("yyyy-MM-dd");
            }
        }

        private void patientDetailComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Name != null && !this.updatedDetails.ContainsKey(((ComboBox)sender).Name))
            {
                this.updatedDetails.Add(((ComboBox)sender).Name, ((ComboBox)sender).Text);
            }
            else if (((ComboBox)sender).Name != null && this.updatedDetails.ContainsKey(((ComboBox)sender).Name))
            {
                this.updatedDetails[((ComboBox)sender).Name] = ((ComboBox)sender).Text;
            }
        }

        private void patientDetailTextBox_LeaveFocus(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name != null && !this.updatedDetails.ContainsKey(((TextBox)sender).Name))
            {
                this.updatedDetails.Add(((TextBox)sender).Name, ((TextBox)sender).Text);
            }
            else if (((TextBox)sender).Name != null && this.updatedDetails.ContainsKey(((TextBox)sender).Name))
            {
                this.updatedDetails[((TextBox)sender).Name] = ((TextBox)sender).Text;
            }
        }
    }
}
