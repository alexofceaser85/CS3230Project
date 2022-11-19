using System.Drawing;
using System.Windows.Forms;
using CS3230Project.ErrorMessages;

namespace CS3230Project.View.Validation
{
    /// <summary>
    /// The validator class for the admin query
    /// </summary>
    public class AdminQueryValidation
    {
        private static readonly Font LabelCollapsedFont = new Font("Segoe UI", 1);
        private static readonly Font LabelNotCollapsedFont = new Font("Segoe UI", 8);
        /// <summary>
        /// Verifies the user input for the admin query
        /// </summary>
        /// <param name="queryTextBox">The user input for the reason</param>
        /// <param name="queryErrorMessage">The error message for the reason</param>
        public static void VerifyAdminQuery(TextBox queryTextBox, Label queryErrorMessage)
        {
            queryErrorMessage.ForeColor = Color.Red;
            if (queryTextBox.Text.Length == 0)
            {
                queryErrorMessage.Font = LabelNotCollapsedFont;
                queryErrorMessage.Text = CreateAppointmentValidationMessages.AppointmentReasonCannotBeEmpty;
            }
            else
            {
                queryErrorMessage.Font = LabelCollapsedFont;
                queryErrorMessage.Text = "";
            }
        }
    }
}
