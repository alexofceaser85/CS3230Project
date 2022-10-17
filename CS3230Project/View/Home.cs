using System;
using System.Windows.Forms;
using CS3230Project.View.WindowSwitching;

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
            this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
        }

        private void registerPatientButton_Click(object sender, EventArgs e)
        {
            Form registerPatientForm = new RegisterPatient();
            SwitchForms.Switch(this, registerPatientForm);
        }

        private void searchPatientsButton_Click(object sender, EventArgs e)
        {
            Form searchPatientForm = new SearchPatient();
            SwitchForms.Switch(this, searchPatientForm);
        }
    }
}
