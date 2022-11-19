using CS3230Project.View.WindowSwitching;
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
    public partial class AdminVisitsSearch : Form
    {
        public AdminVisitsSearch()
        {
            InitializeComponent();
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchBackToHome(this);
        }

        private void SubmitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {

        }
    }
}
