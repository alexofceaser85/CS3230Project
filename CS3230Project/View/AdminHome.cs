using System;
using System.Windows.Forms;
using CS3230Project.View.WindowSwitching;

namespace CS3230Project.View
{
    /// <summary>
    /// The admin home form
    /// </summary>
    public partial class AdminHome : Form
    {
        /// <summary>
        /// Initializes a new <see cref="AdminHome"/>
        /// </summary>
        public AdminHome()
        {
            this.InitializeComponent();
            this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
        }

        private void searchVisitsButton_Click(object sender, EventArgs e)
        {
            SwitchForms.Switch(this, new AdminVisitsSearch());
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            SwitchForms.Switch(this, new AdminQuery());
        }
    }
}
