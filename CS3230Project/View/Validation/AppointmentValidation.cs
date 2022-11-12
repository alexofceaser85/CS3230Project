using System;
using System.Drawing;
using System.Windows.Forms;
using CS3230Project.ErrorMessages;

namespace CS3230Project.View.Validation
{
    /// <summary>
    /// The validator class for the appointment
    /// </summary>
    public static class AppointmentValidation
    {
        private static readonly Font LabelCollapsedFont = new Font("Segoe UI", 1);
        private static readonly Font LabelNotCollapsedFont = new Font("Segoe UI", 8);

        /// <summary>
        /// Verifies the user input for the date
        /// </summary>
        /// <param name="dateInput">The user input for the date</param>
        /// <param name="dateErrorMessage">The error message for the date</param>
        public static void VerifyDateInput(DateTimePicker dateInput, Label dateErrorMessage)
        {
            dateErrorMessage.ForeColor = Color.Red;
            if (dateInput.Value < DateTime.Today)
            {
                dateErrorMessage.Font = LabelNotCollapsedFont;
                dateErrorMessage.Text = CreateAppointmentValidationMessages.DateTimeCannotBeInThePast;
            }
            else
            {
                dateErrorMessage.Font = LabelCollapsedFont;
                dateErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the user input for the doctor
        /// </summary>
        /// <param name="doctorComboBox">The user input for the doctor</param>
        /// <param name="doctorErrorMessage">The error message for the doctor</param>
        public static void VerifyDoctorInput(ComboBox doctorComboBox, Label doctorErrorMessage)
        {
            doctorErrorMessage.ForeColor = Color.Red;
            if (doctorComboBox.SelectedItem == null)
            {
                doctorErrorMessage.Font = LabelNotCollapsedFont;
                doctorErrorMessage.Text = CreateAppointmentValidationMessages.DoctorSelectionCannotBeEmpty;
            }
            else
            {
                doctorErrorMessage.Font = LabelCollapsedFont;
                doctorErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Verifies the user input for the appointment reason
        /// </summary>
        /// <param name="reasonTextBox">The user input for the reason</param>
        /// <param name="reasonErrorMessage">The error message for the reason</param>
        public static void VerifyReasonInput(TextBox reasonTextBox, Label reasonErrorMessage)
        {
            reasonErrorMessage.ForeColor = Color.Red;
            if (reasonTextBox.Text.Length == 0)
            {
                reasonErrorMessage.Font = LabelNotCollapsedFont;
                reasonErrorMessage.Text = CreateAppointmentValidationMessages.AppointmentReasonCannotBeEmpty;
            } else if (reasonTextBox.Text.Length > Settings.AppointmentSettings.AppointmentReasonMaximumLength)
            {
                reasonErrorMessage.Font = LabelNotCollapsedFont;
                reasonErrorMessage.Text = CreateAppointmentValidationMessages.AppointmentReasonCannotBeAboveMaxLength;
            }
            else
            {
                reasonErrorMessage.Font = LabelCollapsedFont;
                reasonErrorMessage.Text = "";
            }
        }
    }
}
