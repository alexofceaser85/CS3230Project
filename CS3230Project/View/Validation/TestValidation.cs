using System;
using System.Drawing;
using System.Windows.Forms;
using CS3230Project.ErrorMessages;

namespace CS3230Project.View.Validation
{
    /// <summary>
    /// The validation class for the tests
    /// </summary>
    public static class TestValidation
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
            if (dateInput.Value < DateTime.Today)
            {
                dateErrorMessage.Font = LabelNotCollapsedFont;
                dateErrorMessage.Text = TestManagerErrorMessages.CannotAddTestResultsBeforeCurrentDate;
            }
            else
            {
                dateErrorMessage.Font = LabelCollapsedFont;
                dateErrorMessage.Text = "";
            }
        }
        /// <summary>
        /// Verifies the test results
        /// </summary>
        /// <param name="resultsTextInput">The user input for the results</param>
        /// <param name="resultsErrorMessage">The error message for the results</param>
        public static void VerifyTestResults(TextBox resultsTextInput, Label resultsErrorMessage)
        {
            if (resultsTextInput.Text.Trim().Length == 0)
            {
                resultsErrorMessage.Font = LabelNotCollapsedFont;
                resultsErrorMessage.Text = TestManagerErrorMessages.TestResultsCannotBeEmpty;
            }
            else
            {
                resultsErrorMessage.Font = LabelCollapsedFont;
                resultsErrorMessage.Text = "";
            }
        }
    }
}
