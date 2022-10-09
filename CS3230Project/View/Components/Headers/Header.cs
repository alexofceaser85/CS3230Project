using CS3230Project.Model.Accounts;
using System;
using System.Windows.Forms;

namespace CS3230Project.View.Components.Headers
{
    /// <summary>
    /// The header component
    /// </summary>
    public partial class Header : UserControl
    {
        private readonly Form currentForm;

        /// <summary>
        /// Instantiates a new <see cref="Header"/>
        /// </summary>
        /// <param name="currentForm">The form the header is in</param>
        public Header(Form currentForm)
        {
            this.currentForm = currentForm;
            this.InitializeComponent();
            this.bindLabelsToCurrentUser();
        }

        private void bindLabelsToCurrentUser()
        {
            if (CurrentUser.User != null)
            {
                this.loggedInAsLabel.Text = $"Logged In As: {CurrentUser.User.UserName}";
                this.userIdLabel.Text = $"User ID: {CurrentUser.User.Id}";
                this.nameLabel.Text = $"Name: {CurrentUser.User.FirstName} {CurrentUser.User.LastName}";
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            Form form1 = new Login();
            form1.Location = Location;
            form1.StartPosition = FormStartPosition.Manual;
            form1.FormClosing += delegate { Show(); };
            if (this.currentForm != null)
            {
                this.currentForm.Hide();
            }
            form1.ShowDialog();
            if (this.currentForm != null)
            {
                this.currentForm.Close();
            }
        }
    }
}
