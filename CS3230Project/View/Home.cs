using System;
using System.Windows.Forms;
using CS3230Project.Model.Accounts;

namespace CS3230Project.View
{
    /// <summary>
    /// The home page
    /// </summary>
    public partial class Home : Form
    {
        /// <summary>
        /// Instantiates a new <see cref="Home"/> page
        /// </summary>
        public Home()
        {
            this.InitializeComponent();
            this.bindLabelsToCurrentUser();
        }

        private void bindLabelsToCurrentUser()
        {
            this.loggedInAsLabel.Text = $"Logged In As: {CurrentUser.User.UserName}";
            this.userIdLabel.Text = $"User ID: {CurrentUser.User.Id}";
            this.nameLabel.Text = $"Name: {CurrentUser.User.FirstName} {CurrentUser.User.LastName}";
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            Form form1 = new Login();
            form1.Location = Location;
            form1.StartPosition = FormStartPosition.Manual;
            form1.FormClosing += delegate { Show(); };
            Hide();
            form1.ShowDialog();
            Close();
        }
    }
}
