using CS3230Project.Model.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS3230Project.View
{
    public partial class EditPatient : Form
    {
        public EditPatient()
        {
            this.InitializeComponent();
            this.bindLabelsToCurrentUser();
            this.setStatusComboBoxValues();
        }

        private void setStatusComboBoxValues()
        {
            //TODO: use enum
            this.statusComboBox.Items.Add("Active");
            this.statusComboBox.Items.Add("Inactive");
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
            Form homeForm = new Login();
            homeForm.Location = Location;
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.FormClosing += delegate { Show(); };
            Hide();
            homeForm.Size = this.Size;
            homeForm.ShowDialog();
            Close();
        }

        private void backToHomeButton_Click(object sender, EventArgs e)
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

        private void submitChangesButton_Click(object sender, EventArgs e)
        {

        }
    }
}
