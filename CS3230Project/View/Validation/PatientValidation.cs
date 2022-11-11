using System;
using System.Drawing;
using System.Windows.Forms;
using CS3230Project.Model;
using CS3230Project.Settings;

namespace CS3230Project.View.Validation
{
    /// <summary>
    /// Shows the UI messages that validate the inputs
    /// </summary>
    public static class PatientValidation
    {
        private static readonly Font LabelCollapsedFont = new Font("Segoe UI", 1);
        private static readonly Font LabelNotCollapsedFont = new Font("Segoe UI", 8);

        /// <summary>
        /// Verifies the inputs for the last name
        /// </summary>
        /// <param name="patientLastNameTextBox">The input to validate</param>
        /// <param name="patientLastNameTextBoxErrorMessage">The label to show the violation</param>
        public static void VerifyLastNameInputs(TextBox patientLastNameTextBox, Label patientLastNameTextBoxErrorMessage)
        {
            patientLastNameTextBoxErrorMessage.ForeColor = Color.Red;
            if (patientLastNameTextBox.Text.Trim().Length == 0)
            {
                patientLastNameTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                patientLastNameTextBoxErrorMessage.Text = ErrorMessages.PatientErrorMessages.LastNameCannotBeEmpty;
            }
            else if (patientLastNameTextBox.Text.Length > UserSettings.NameMaximumLength)
            {
                patientLastNameTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                patientLastNameTextBoxErrorMessage.Text = ErrorMessages.PatientErrorMessages.LastNameIsTooLong;
            }
            else
            {
                patientLastNameTextBoxErrorMessage.Font = LabelCollapsedFont;
                patientLastNameTextBoxErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the inputs for the first name
        /// </summary>
        /// <param name="patientFirstNameTextBox">The input to validate</param>
        /// <param name="patientFirstNameErrorMessage">The label to show the violation</param>
        public static void VerifyFirstNameInputs(TextBox patientFirstNameTextBox, Label patientFirstNameErrorMessage)
        {
            patientFirstNameErrorMessage.ForeColor = Color.Red;
            if (patientFirstNameTextBox.Text.Trim().Length == 0)
            {
                patientFirstNameErrorMessage.Font = LabelNotCollapsedFont;
                patientFirstNameErrorMessage.Text = ErrorMessages.PatientErrorMessages.FirstNameCannotBeEmpty;
            }
            else if (patientFirstNameTextBox.Text.Length > UserSettings.NameMaximumLength)
            {
                patientFirstNameErrorMessage.Font = LabelNotCollapsedFont;
                patientFirstNameErrorMessage.Text = ErrorMessages.PatientErrorMessages.FirstNameIsTooLong;
            }
            else
            {
                patientFirstNameErrorMessage.Font = LabelCollapsedFont;
                patientFirstNameErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the inputs for the birth date
        /// </summary>
        /// <param name="patientDateOfBirthPicker">The input to validate</param>
        /// <param name="patientDateOfBirthErrorMessage">The label to show the violation</param>
        public static void VerifyDateInputs(DateTimePicker patientDateOfBirthPicker, Label patientDateOfBirthErrorMessage)
        {
            patientDateOfBirthErrorMessage.ForeColor = Color.Red;
            if (patientDateOfBirthPicker.Value < new DateTime(1900, 1, 1))
            {
                patientDateOfBirthErrorMessage.Font = LabelNotCollapsedFont;
                patientDateOfBirthErrorMessage.Text = ErrorMessages.PatientErrorMessages.DateOfBirthCannotBeBefore1900;
            }
            else if (patientDateOfBirthPicker.Value > DateTime.Now)
            {
                patientDateOfBirthErrorMessage.Font = LabelNotCollapsedFont;
                patientDateOfBirthErrorMessage.Text = ErrorMessages.PatientErrorMessages.DateOfBirthCannotBeInTheFuture;
            }
            else
            {
                patientDateOfBirthErrorMessage.Font = LabelCollapsedFont;
                patientDateOfBirthErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the inputs for the gender
        /// </summary>
        /// <param name="patientGenderDropBox">The input to validate</param>
        /// <param name="patientGenderErrorMessage">The label to show the violation</param>
        public static void VerifyGenderInputs(ComboBox patientGenderDropBox, Label patientGenderErrorMessage)
        {
            patientGenderErrorMessage.ForeColor = Color.Red;
            if (patientGenderDropBox.Text.Trim().Length == 0)
            {
                patientGenderErrorMessage.Font = LabelNotCollapsedFont;
                patientGenderErrorMessage.Text = ErrorMessages.PatientErrorMessages.GenderCannotBeEmpty;
            }
            else if (patientGenderDropBox.Text.Length > UserSettings.GenderMaximumLength)
            {
                patientGenderErrorMessage.Font = LabelNotCollapsedFont;
                patientGenderErrorMessage.Text = ErrorMessages.PatientErrorMessages.GenderIsTooLong;
            }
            else
            {
                patientGenderErrorMessage.Font = LabelCollapsedFont;
                patientGenderErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the inputs for the phone number
        /// </summary>
        /// <param name="patientPhoneNumberTextBox">The input to validate</param>
        /// <param name="patientPhoneNumberErrorMessage">The label to show the violation</param>
        public static void VerifyPhoneNumberInputs(TextBox patientPhoneNumberTextBox,
            Label patientPhoneNumberErrorMessage)
        {
            patientPhoneNumberErrorMessage.ForeColor = Color.Red;
            if (patientPhoneNumberTextBox.Text.Trim().Length == 0)
            {
                patientPhoneNumberErrorMessage.Text = ErrorMessages.PatientErrorMessages.PhoneNumberCannotBeEmpty;
                patientPhoneNumberErrorMessage.Font = LabelNotCollapsedFont;
            } else if (!DataValidator.IsValidPhoneNumberFormat(patientPhoneNumberTextBox.Text))
            {
                patientPhoneNumberErrorMessage.Text = ErrorMessages.PatientErrorMessages.InvalidPhoneNumberFormat;
                patientPhoneNumberErrorMessage.Font = LabelNotCollapsedFont;
            }
            else
            {
                patientPhoneNumberErrorMessage.Font = LabelCollapsedFont;
                patientPhoneNumberErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the inputs for the address one
        /// </summary>
        /// <param name="patientAddressOneTextBox">The input to validate</param>
        /// <param name="patientAddressOneErrorMessage">The label to show the violation</param>
        public static void VerifyAddressOneInputs(TextBox patientAddressOneTextBox, Label patientAddressOneErrorMessage)
        {
            patientAddressOneErrorMessage.ForeColor = Color.Red;
            if (patientAddressOneTextBox.Text.Trim().Length == 0)
            {
                patientAddressOneErrorMessage.Text = ErrorMessages.PatientErrorMessages.AddressOneCannotBeEmpty;
                patientAddressOneErrorMessage.Font = LabelNotCollapsedFont;
            }
            else if (patientAddressOneTextBox.Text.Length > UserSettings.AddressComponentMaximumLength)
            {
                patientAddressOneErrorMessage.Font = LabelNotCollapsedFont;
                patientAddressOneErrorMessage.Text = ErrorMessages.PatientErrorMessages.AddressOneIsTooLong;
            }
            else
            {
                patientAddressOneErrorMessage.Font = LabelCollapsedFont;
                patientAddressOneErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the inputs for the city
        /// </summary>
        /// <param name="patientCityTextBox">The input to validate</param>
        /// <param name="patientCityErrorMessage">The label to show the violation</param>
        public static void VerifyCityInputs(TextBox patientCityTextBox, Label patientCityErrorMessage)
        {
            patientCityErrorMessage.ForeColor = Color.Red;
            if (patientCityTextBox.Text.Trim().Length == 0)
            {
                patientCityErrorMessage.Text = ErrorMessages.PatientErrorMessages.CityCannotBeEmpty;
                patientCityErrorMessage.Font = LabelNotCollapsedFont;
            }
            else if (patientCityTextBox.Text.Length > UserSettings.AddressComponentMaximumLength)
            {
                patientCityErrorMessage.Font = LabelNotCollapsedFont;
                patientCityErrorMessage.Text = ErrorMessages.PatientErrorMessages.CityIsTooLong;
            }
            else
            {
                patientCityErrorMessage.Font = LabelCollapsedFont;
                patientCityErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the inputs for the state
        /// </summary>
        /// <param name="patientStateTextBox">The input to validate</param>
        /// <param name="patientStateErrorMessage">The label to show the violation</param>
        public static void VerifyStateInputs(ComboBox patientStateTextBox, Label patientStateErrorMessage)
        {
            patientStateErrorMessage.ForeColor = Color.Red;
            if (patientStateTextBox.Text.Trim().Length == 0)
            {
                patientStateErrorMessage.Text = ErrorMessages.PatientErrorMessages.StateCannotBeEmpty;
                patientStateErrorMessage.Font = LabelNotCollapsedFont;
            }
            else if (patientStateTextBox.Text.Length > UserSettings.StateMaximumLength)
            {
                patientStateErrorMessage.Font = LabelNotCollapsedFont;
                patientStateErrorMessage.Text = ErrorMessages.PatientErrorMessages.StateIsTooLong;
            }
            else
            {
                patientStateErrorMessage.Font = LabelCollapsedFont;
                patientStateErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the inputs for the zip code
        /// </summary>
        /// <param name="patientZipCodeTextBox">The input to validate</param>
        /// <param name="patientZipCodeErrorMessage">The label to show the violation</param>
        public static void VerifyZipCodeInputs(TextBox patientZipCodeTextBox, Label patientZipCodeErrorMessage)
        {
            patientZipCodeErrorMessage.ForeColor = Color.Red;
            if (patientZipCodeTextBox.Text.Trim().Length == 0)
            {
                patientZipCodeErrorMessage.Text = ErrorMessages.PatientErrorMessages.ZipcodeCannotBeEmpty;
                patientZipCodeErrorMessage.Font = LabelNotCollapsedFont;
            } else if (!DataValidator.IsValidZipCodeFormat(patientZipCodeTextBox.Text))
            {
                patientZipCodeErrorMessage.Text = ErrorMessages.PatientErrorMessages.ZipCodeMustBeAllDigitsAndHaveFiveCharacters;
                patientZipCodeErrorMessage.Font = LabelNotCollapsedFont;
            }
            else
            {
                patientZipCodeErrorMessage.Font = LabelCollapsedFont;
                patientZipCodeErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the inputs for the status
        /// </summary>
        /// <param name="patientStatusTextBox">The input to validate</param>
        /// <param name="patientStatusErrorMessage">The label to show the violation</param>
        public static void VerifyStatusInputs(ComboBox patientStatusTextBox, Label patientStatusErrorMessage)
        {
            patientStatusErrorMessage.ForeColor = Color.Red;
            if (patientStatusTextBox.Text.Trim().Length == 0)
            {
                patientStatusErrorMessage.Text = ErrorMessages.PatientErrorMessages.PatientStatusCannotBeEmpty;
                patientStatusErrorMessage.Font = LabelNotCollapsedFont;
            }
            else
            {
                patientStatusErrorMessage.Font = LabelCollapsedFont;
                patientStatusErrorMessage.Text = "";
            }
        }
    }
}
