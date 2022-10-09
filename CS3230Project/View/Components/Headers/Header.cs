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
        /// <summary>
        /// The event handler for a logout
        /// </summary>
        public event EventHandler LogoutEventHandler;
        /// <summary>
        /// Instantiates a new <see cref="Header"/>
        /// </summary>
        public Header()
        {
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
            this.LogoutEventHandler?.Invoke(sender, e);
        }
    }
}
