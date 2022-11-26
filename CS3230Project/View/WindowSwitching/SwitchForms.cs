using System.Windows.Forms;
using CS3230Project.Model.Accounts;

namespace CS3230Project.View.WindowSwitching
{
    /// <summary>
    /// Switches between forms
    /// </summary>
    public static class SwitchForms
    {
        /// <summary>
        /// Switches to the home form
        /// </summary>
        /// <param name="currentForm">The form to switch from</param>
        public static void SwitchBackToHome(Form currentForm)
        {
            Form formToSwitchTo = new Home();
            Switch(currentForm, formToSwitchTo);
        }

        /// <summary>
        /// Switches to the admin home form
        /// </summary>
        /// <param name="currentForm">The form to switch from</param>
        public static void SwitchBackToAdminHome(Form currentForm)
        {
            Form formToSwitchTo = new AdminHome();
            Switch(currentForm, formToSwitchTo);
        }

        /// <summary>
        /// Switches to the login form
        /// </summary>
        /// <param name="currentForm">The form to switch from</param>
        public static void SwitchToLogin(Form currentForm)
        {
            CurrentUser.User = null;
            var formToSwitchTo = new Login();
            Switch(currentForm, formToSwitchTo);
        }

        /// <summary>
        /// Switches two forms
        /// </summary>
        /// <param name="currentForm">The form to switch from</param>
        /// <param name="formToSwitchTo">The form to switch to</param>
        public static void Switch(Form currentForm, Form formToSwitchTo)
        {
            formToSwitchTo.Location = currentForm.Location;
            formToSwitchTo.StartPosition = FormStartPosition.Manual;
            formToSwitchTo.Size = currentForm.Size;
            formToSwitchTo.FormClosing += delegate { currentForm.Close(); };
            currentForm.Hide();
            formToSwitchTo.ShowDialog();
            currentForm.Close();
        }
    }
}
