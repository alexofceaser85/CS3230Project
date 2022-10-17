using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.Model.Users.Patients;
using CS3230Project.View.Validation;
using CS3230Project.View.WindowSwitching;

namespace CS3230Project.View
{
    /// <summary>
    ///   The edit patient view.
    /// </summary>
    public partial class EditPatient : Form
    {
        private static string editPatientErrorHeader = "Unable To Edit Patient";
        private static string editPatientLoadingErrorHeader = "Unable To Edit Patient";
        private Dictionary<string, string> updatedDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditPatient" /> class.
        ///s </summary>
        /// <param name="patient">The patient.</param>
        public EditPatient(Patient patient)
        {
            try
            {
                this.InitializeComponent();
                this.updatedDetails = new Dictionary<string, string>();
                this.loadPatientData(patient);
                this.updatedDetails.Add("PatientId", patient.PatientId.ToString());
                this.submitChangesFooter1.SubmitButtonEventHandler += this.submitChangesButton_Click;
                this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
                this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
            }
            catch (ArgumentException errorMessage)
            {
                MessageBox.Show(errorMessage.Message, editPatientLoadingErrorHeader);
            }
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchBackToHome(this);
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

        private void submitChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.verifyAll();
                PatientManager.ModifyPatient(this.updatedDetails);
                Form searchPatientForm = new SearchPatient();
                SwitchForms.Switch(this, searchPatientForm);
            }
            catch (ArgumentException errorMessage)
            {
                MessageBox.Show(errorMessage.Message, editPatientErrorHeader);
            }
        }

        private void patientDateOfBirthPicker_ValueChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyDateInputs(this.patientDateOfBirthPicker, this.dateOfBirthErrorMessage);

            if (((DateTimePicker)sender).Name != null && !this.updatedDetails.ContainsKey(((DateTimePicker)sender).Name))
            {
                this.updatedDetails.Add(((DateTimePicker)sender).Name, ((DateTimePicker)sender).Value.ToString("yyyy-MM-dd"));
            }
            else if (((DateTimePicker)sender).Name != null && this.updatedDetails.ContainsKey(((DateTimePicker)sender).Name))
            {
                this.updatedDetails[((DateTimePicker)sender).Name] = ((DateTimePicker)sender).Value.ToString("yyyy-MM-dd");
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

        private void verifyAll()
        {
            PatientValidation.VerifyLastNameInputs(this.patientLastNameTextBox, this.lastNameErrorMessage);
            PatientValidation.VerifyFirstNameInputs(this.patientFirstNameTextBox, this.firstNameErrorMessage);
            PatientValidation.VerifyPhoneNumberInputs(this.patientPhoneNumberTextBox, this.phoneNumberErrorMessage);
            PatientValidation.VerifyAddressOneInputs(this.patientAddressOneTextBox, this.addressOneErrorMessage);
            PatientValidation.VerifyCityInputs(this.patientCityTextBox, this.cityErrorMessage);
            PatientValidation.VerifyGenderInputs(this.patientGenderComboBox, this.genderErrorMessage);
            PatientValidation.VerifyStateInputs(this.patientStateComboBox, this.stateErrorMessage);
            PatientValidation.VerifyZipCodeInputs(this.patientZipcodeTextBox, this.zipCodeErrorMessage);
            PatientValidation.VerifyStatusInputs(this.patientStatusComboBox, this.statusErrorMessage);
        }

        private void patientLastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyLastNameInputs(this.patientLastNameTextBox, this.lastNameErrorMessage);
        }

        private void patientFirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyFirstNameInputs(this.patientFirstNameTextBox, this.firstNameErrorMessage);
        }

        private void patientPhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyPhoneNumberInputs(this.patientPhoneNumberTextBox, this.phoneNumberErrorMessage);
        }

        private void patientAddressOneTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyAddressOneInputs(this.patientAddressOneTextBox, this.addressOneErrorMessage);
        }

        private void patientCityTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyCityInputs(this.patientCityTextBox, this.cityErrorMessage);
        }

        private void patientGenderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyGenderInputs(this.patientGenderComboBox, this.genderErrorMessage);
        }

        private void patientStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyStateInputs(this.patientStateComboBox, this.stateErrorMessage);
        }

        private void patientZipcodeTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyZipCodeInputs(this.patientZipcodeTextBox, this.zipCodeErrorMessage);
        }

        private void patientStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyStatusInputs(this.patientStatusComboBox, this.statusErrorMessage);
        }
    }
}
