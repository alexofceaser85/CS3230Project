using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS3230Project.Model.Accounts;

namespace CS3230Project.View
{
    public partial class RegisterPatient : Form
    {
        public RegisterPatient()
        {
            InitializeComponent();
            this.bindLabelsToCurrentUser();
        }

        private void bindLabelsToCurrentUser()
        {
            this.loggedInAsLabel.Text = $"Logged In As: {CurrentUser.User.UserName}";
            this.userIdLabel.Text = $"User ID: {CurrentUser.User.Id}";
            this.nameLabel.Text = $"Name: {CurrentUser.User.FirstName} {CurrentUser.User.LastName}";
        }

        private void returnToHomeButton_Click(object sender, EventArgs e)
        {
            Form homeForm = new Home();
            homeForm.Location = Location;
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.FormClosing += delegate { Show(); };
            Hide();
            homeForm.Size = this.Size;
            homeForm.ShowDialog();
            Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Form homeForm = new Home();
            homeForm.Location = Location;
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.FormClosing += delegate { Show(); };
            Hide();
            homeForm.Size = this.Size;
            homeForm.ShowDialog();
            Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            Form homeForm = new Login();
            homeForm.Location = Location;
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.FormClosing += delegate { Show(); };
            Hide();
            homeForm.Size = this.Size;
            homeForm.ShowDialog();
            Close();
        }
    }
}
