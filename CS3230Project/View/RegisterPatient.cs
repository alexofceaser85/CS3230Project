using System;
using System.Windows.Forms;
using CS3230Project.Model.Users.Patients;
using CS3230Project.View.Validation;
using CS3230Project.ViewModel.Users;

namespace CS3230Project.View
{
    /// <summary>
    /// The screen to register a patient
    /// </summary>
    public partial class RegisterPatient : Form
    {
        private readonly string invalidInputErrorMessage = "Invalid Values for New Patient";
        private readonly string invalidInputErrorHeader = "Unable to add new patient";

        /// <summary>
        /// Instantiates a new <see cref="RegisterPatient"/>
        /// </summary>
        public RegisterPatient()
        {
            this.InitializeComponent();
            this.submitChangesFooter1.SubmitButtonEventHandler += this.submitChangesFooter1OnSubmitButtonEventHandler;
        }

        private void submitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            try
            {
                this.validateAll();
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
                    this.patientZipCodeTextBox.Text,
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
            catch (ArgumentException)
            {
                MessageBox.Show(this.invalidInputErrorMessage, this.invalidInputErrorHeader);
            }
        }

        private void validateAll()
        {
            PatientValidation.VerifyLastNameInputs(this.patientLastNameTextBox, this.patientLastNameTextBoxErrorMessage);
            PatientValidation.VerifyFirstNameInputs(this.patientFirstNameTextBox, this.patientFirstNameErrorMessage);
            PatientValidation.VerifyDateInputs(this.patientDateOfBirthPicker, this.patientDateOfBirthErrorMessage);
            PatientValidation.VerifyGenderInputs(this.patientGenderDropBox, this.patientGenderErrorMessage);
            PatientValidation.VerifyPhoneNumberInputs(this.patientPhoneNumberTextBox, this.patientPhoneNumberErrorMessage);
            PatientValidation.VerifyAddressOneInputs(this.patientAddressOneTextBox, this.patientAddressOneErrorMessage);
            PatientValidation.VerifyCityInputs(this.patientCityTextBox, this.patientCityErrorMessage);
            PatientValidation.VerifyStateInputs(this.patientStateComboBox, this.patientStateErrorMessage);
            PatientValidation.VerifyZipCodeInputs(this.patientZipCodeTextBox, this.patientZipCodeErrorMessage);
        }

        private void patientLastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyLastNameInputs(this.patientLastNameTextBox, this.patientLastNameTextBoxErrorMessage);
        }

        private void patientFirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyFirstNameInputs(this.patientFirstNameTextBox, this.patientFirstNameErrorMessage);
        }
        private void patientDateOfBirthPicker_ValueChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyDateInputs(this.patientDateOfBirthPicker, this.patientDateOfBirthErrorMessage);
        }

        private void patientGenderDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyGenderInputs(this.patientGenderDropBox, this.patientGenderErrorMessage);
        }

        private void patientPhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyPhoneNumberInputs(this.patientPhoneNumberTextBox, this.patientPhoneNumberErrorMessage);
        }

        private void patientAddressOneTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyAddressOneInputs(this.patientAddressOneTextBox, this.patientAddressOneErrorMessage);
        }

        private void patientCityTextBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyCityInputs(this.patientCityTextBox, this.patientCityErrorMessage);
        }

        private void patientStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyStateInputs(this.patientStateComboBox, this.patientStateErrorMessage);
        }

        private void patientZipCodeComboBox_TextChanged(object sender, EventArgs e)
        {
            PatientValidation.VerifyZipCodeInputs(this.patientZipCodeTextBox, this.patientZipCodeErrorMessage);
        }
    }
}

