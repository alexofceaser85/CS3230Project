﻿using System;
using System.Drawing;
using System.Windows.Forms;
using CS3230Project.Model;

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
            if (patientLastNameTextBox.Text.Trim().Length == 0)
            {
                patientLastNameTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                patientLastNameTextBoxErrorMessage.Text = ErrorMessages.PatientErrorMessages.LastNameCannotBeEmpty;
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
            if (patientFirstNameTextBox.Text.Trim().Length == 0)
            {
                patientFirstNameErrorMessage.Font = LabelNotCollapsedFont;
                patientFirstNameErrorMessage.Text = ErrorMessages.PatientErrorMessages.FirstNameCannotBeEmpty;
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
            if (patientGenderDropBox.Text.Trim().Length == 0)
            {
                patientGenderErrorMessage.Font = LabelNotCollapsedFont;
                patientGenderErrorMessage.Text = ErrorMessages.PatientErrorMessages.GenderCannotBeEmpty;
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
            if (patientAddressOneTextBox.Text.Trim().Length == 0)
            {
                patientAddressOneErrorMessage.Text = ErrorMessages.PatientErrorMessages.AddressOneCannotBeEmpty;
                patientAddressOneErrorMessage.Font = LabelNotCollapsedFont;
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
            if (patientCityTextBox.Text.Trim().Length == 0)
            {
                patientCityErrorMessage.Text = ErrorMessages.PatientErrorMessages.CityCannotBeEmpty;
                patientCityErrorMessage.Font = LabelNotCollapsedFont;
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
            if (patientStateTextBox.Text.Trim().Length == 0)
            {
                patientStateErrorMessage.Text = ErrorMessages.PatientErrorMessages.StateCannotBeEmpty;
                patientStateErrorMessage.Font = LabelNotCollapsedFont;
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