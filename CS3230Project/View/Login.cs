using System;
using System.Windows.Forms;
using CS3230Project.Model.Accounts;
using CS3230Project.View.WindowSwitching;
using CS3230Project.ViewModel.Accounts;

namespace CS3230Project.View
{
    /// <summary>
    /// The login page
    /// </summary>
    public partial class Login : Form
    {
        private readonly string incorrectUserNameAndPasswordErrorMessage = "User name and password are incorrect, please try again";
        private readonly string loginErrorHeader = "Unable to login";

        /// <summary>
        /// Instantiates a new <see cref="Login"/> page
        /// </summary>
        public Login()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var isLoginSuccessful = AccountServiceViewModel.Login(this.userNameTextBox.Text, this.passwordTextBox.Text);

                if (isLoginSuccessful)
                {
                    this.goToHomeForm();
                }
                else
                {
                    MessageBox.Show(this.incorrectUserNameAndPasswordErrorMessage, this.loginErrorHeader);
                }
            }
            catch (ArgumentException errorMessage)
            {
                MessageBox.Show(errorMessage.Message, this.loginErrorHeader);
            }
        }

        private void goToHomeForm()
        {

            if (CurrentUser.User.AccountType == AccountType.NURSE)
            {
                Form homeForm = new Home();
                SwitchForms.Switch(this, homeForm);
            }
            else if (CurrentUser.User.AccountType == AccountType.ADMIN)
            {
                Form homeForm = new AdminHome();
                SwitchForms.Switch(this, homeForm);
            }
        }
    }
}
