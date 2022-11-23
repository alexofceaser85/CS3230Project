using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.ErrorMessages;
using CS3230Project.Model.Users.Patients;
using CS3230Project.View.Validation;
using CS3230Project.View.WindowSwitching;
using CS3230Project.ViewModel.Users;

namespace CS3230Project.View
{
    /// <summary>
    ///   The edit patient view.
    /// </summary>
    public partial class EditPatient : Form
    {
        private static string editPatientErrorHeader = "Unable To Edit Patient";
        private static string editPatientLoadingErrorHeader = "Unable To Edit Patient";
        private Patient patientToEdit;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditPatient" /> class.
        ///s </summary>
        /// <param name="patient">The patient.</param>
        public EditPatient(Patient patient)
        {
            try
            {
                this.InitializeComponent();
                this.patientToEdit = patient;
                this.loadPatientData();
                this.disablePatientFieldsOnInactivePatient();
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

        private void loadPatientData()
        {
            this.patientFirstNameTextBox.Text = this.patientToEdit.FirstName;
            this.patientLastNameTextBox.Text = this.patientToEdit.LastName;
            this.patientDateOfBirthPicker.Value = this.patientToEdit.DateOfBirth;
            this.patientGenderComboBox.Text = this.patientToEdit.Gender;
            this.patientPhoneNumberTextBox.Text = this.patientToEdit.PhoneNumber;
            this.patientAddressOneTextBox.Text = this.patientToEdit.AddressOne;
            this.patientAddressTwoTextBox.Text = this.patientToEdit.AddressTwo;
            this.patientCityTextBox.Text = this.patientToEdit.City;
            this.patientStateComboBox.Text = this.patientToEdit.State;
            this.patientZipcodeTextBox.Text = this.patientToEdit.Zipcode;
            this.patientStatusComboBox.Text = this.patientToEdit.IsActive.ToString();
        }

        private void disablePatientFieldsOnInactivePatient()
        {
            if (this.patientToEdit.IsActive == false)
            {
                this.patientFirstNameTextBox.Enabled = false;
                this.patientLastNameTextBox.Enabled = false;
                this.patientDateOfBirthPicker.Enabled = false;
                this.patientGenderComboBox.Enabled = false;
                this.patientPhoneNumberTextBox.Enabled = false;
                this.patientAddressOneTextBox.Enabled = false;
                this.patientAddressTwoTextBox.Enabled = false;
                this.patientCityTextBox.Enabled = false;
                this.patientStateComboBox.Enabled = false;
                this.patientZipcodeTextBox.Enabled = false;
            }
        }

        private void submitChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.verifyAll();
                if (this.ValidateModifiedData())
                {
                    PatientManagerViewModel.ModifyPatient(new Patient(
                        this.patientToEdit.PatientId, 
                        this.patientLastNameTextBox.Text,
                        this.patientFirstNameTextBox.Text, 
                        this.patientDateOfBirthPicker.Value, 
                        this.patientGenderComboBox.Text, 
                        this.patientPhoneNumberTextBox.Text,
                        this.patientAddressOneTextBox.Text,
                        this.patientAddressTwoTextBox.Text,
                        this.patientCityTextBox.Text,
                        this.patientStateComboBox.Text,
                        this.patientZipcodeTextBox.Text,
                        this.patientStatusComboBox.Text.Equals("True")
                    ));
                    Form searchPatientForm = new SearchPatient();
                    SwitchForms.Switch(this, searchPatientForm);
                }
                else
                {
                    MessageBox.Show(PatientErrorMessages.UpdatedPatientDetailsAreInvalid, editPatientErrorHeader);
                }
            }
            catch (ArgumentException errorMessage)
            {
                MessageBox.Show(errorMessage.Message, editPatientErrorHeader);
            }
        }

        private bool ValidateModifiedData()
        {
            List<Label> errorLabels = new List<Label>
            {
                lastNameErrorMessage,
                firstNameErrorMessage,
                dateOfBirthErrorMessage,
                genderErrorMessage,
                phoneNumberErrorMessage,
                addressOneErrorMessage,
                cityErrorMessage,
                stateErrorMessage,
                zipCodeErrorMessage,
                statusErrorMessage
            };

            foreach (var currentLabel in errorLabels)
            {
                if (!currentLabel.Text.Equals(""))
                {
                    return false;
                }
            }

            return true;
        }

        private void patientDateOfBirthPicker_ValueChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyDateInputs(this.patientDateOfBirthPicker, this.dateOfBirthErrorMessage);
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
