using System;
using System.Windows.Forms;

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
        }

        private void registerPatientButton_Click(object sender, EventArgs e)
        {
            Form registerPatientForm = new RegisterPatient();
            registerPatientForm.Location = Location;
            registerPatientForm.StartPosition = FormStartPosition.Manual;
            registerPatientForm.FormClosing += delegate { Show(); };
            Hide();
            registerPatientForm.Size = this.Size;
            registerPatientForm.ShowDialog();
            Close();
        }

        private void searchPatientsButton_Click(object sender, EventArgs e)
        {
            Form searchPatientForm = new SearchPatient();
            searchPatientForm.Location = Location;
            searchPatientForm.StartPosition = FormStartPosition.Manual;
            searchPatientForm.FormClosing += delegate { Show(); };
            Hide();
            searchPatientForm.Size = this.Size;
            searchPatientForm.ShowDialog();
            Close();
        }
    }
}
