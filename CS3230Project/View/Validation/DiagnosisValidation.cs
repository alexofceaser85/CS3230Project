using System.Drawing;
using System.Windows.Forms;
using CS3230Project.ErrorMessages;

namespace CS3230Project.View.Validation
{
    /// <summary>
    ///   Shows the UI messages that validate the inputs for the diagnoses
    /// </summary>
    public static class DiagnosisValidation
    {

        private static readonly Font LabelCollapsedFont = new Font("Segoe UI", 1);
        private static readonly Font LabelNotCollapsedFont = new Font("Segoe UI", 8);

        /// <summary>
        /// Verifies the diagnosis description.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="diagnosisDescriptionTextBox">The diagnosis description text box.</param>
        /// <param name="diagnosisDescriptionTextBoxErrorMessage">The diagnosis description text box error message.</param>
        /// <returns>
        ///   True if the diagnosis description is valid
        ///   False if the diagnosis description is invalid
        /// </returns>
        public static bool VerifyDiagnosisDescription(TextBox diagnosisDescriptionTextBox,
            Label diagnosisDescriptionTextBoxErrorMessage)
        {
            diagnosisDescriptionTextBoxErrorMessage.ForeColor = Color.Red;
            if (diagnosisDescriptionTextBox.Text.Trim().Length == 0)
            {
                diagnosisDescriptionTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                diagnosisDescriptionTextBoxErrorMessage.Text = DiagnosisErrorMessages.DiagnosisDescriptionCannotBeEmpty;
                return false;
            }
            else if (diagnosisDescriptionTextBox.Text.Trim().Length > 100)
            {
                diagnosisDescriptionTextBoxErrorMessage.Font = LabelNotCollapsedFont;
                diagnosisDescriptionTextBoxErrorMessage.Text =
                    DiagnosisErrorMessages.DiagnosisDescriptionCannotBeMoreThan100Chars;
                return false;
            }
            else
            {
                diagnosisDescriptionTextBoxErrorMessage.Font = LabelCollapsedFont;
                diagnosisDescriptionTextBoxErrorMessage.Text = "";
                return true;
            }
        }
    }
}
