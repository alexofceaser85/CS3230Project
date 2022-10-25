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
using CS3230Project.Model.Users;
using CS3230Project.Model.Visits;

namespace CS3230Project.View
{
    public partial class Checkup : Form
    {
        private int appointmentID;

        public Checkup(int appointmentID)
        {
            InitializeComponent();
            this.submitChangesFooter1.SubmitButtonEventHandler += this.submitChangesFooter1OnSubmitButtonEventHandler;
            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
            this.appointmentID = appointmentID;
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchBackToHome(this);
        }

        private void submitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            try
            {
                this.verifyAll();

                Nurse nurse = ((Nurse)this.nurseComboBox.SelectedValue);
                Visit visitToAdd = new Visit(this.appointmentID, nurse.Id, Convert.ToDouble(this.bodyTemperatureTextBox.Text), 
                    Convert.ToInt16(this.pulseTextBox.Text), Convert.ToDouble(this.heightTextBox.Text),
                    Convert.ToDouble(this.weightTextBox.Text), this.symptomsTextBox.Text, 
                    Convert.ToInt16(this.systolicBloodPressureTextBox.Text), 
                    Convert.ToInt16(this.diastolicBloodPressureTextBox.Text));
                VisitManager.AddVisit(visitToAdd);
                Form searchPatientForm = new SearchPatient();
                SwitchForms.Switch(this, searchPatientForm);
            }
            catch (ArgumentException errorMessage)
            {
                MessageBox.Show(errorMessage.Message); // add checkup header?
            }
        }

        private void verifyAll()
        {

        }
    }
}
