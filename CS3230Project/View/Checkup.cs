using CS3230Project.View.WindowSwitching;
using System;
using System.Windows.Forms;
using CS3230Project.Model.Users;
using CS3230Project.Model.Users.Nurses;
using CS3230Project.Model.Visits;
using CS3230Project.View.Validation;
using CS3230Project.ViewModel.Checkups;

namespace CS3230Project.View
{
    /// <summary>
    ///   The Checkup form
    /// </summary>
    public partial class Checkup : Form
    {
        private int appointmentID;
        private readonly string invalidInputErrorMessage = "Invalid Values for the checkup details";
        private readonly string invalidInputErrorHeader = "Unable to add new checkup";

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkup" /> class.
        /// </summary>
        /// <param name="appointmentID">The appointment identifier.</param>
        public Checkup(int appointmentID)
        {
            InitializeComponent();
            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
            this.appointmentID = appointmentID;
            this.checkIfVisitExists(appointmentID);
        }

        private void checkIfVisitExists(int appointmentID)
        {
            Visit visit = CheckupManagerViewModel.GetVisit(appointmentID);
            if (visit == null)
            {
                this.submitChangesFooter1.SubmitButtonEventHandler += this.submitChangesFooter1OnSubmitButtonEventHandler;
                this.populateNurseComboBox();
            }
            else
            {
                this.displayCheckupDetails(visit);
            }
        }

        private void displayCheckupDetails(Visit visit)
        {
            this.systolicBloodPressureTextBox.Text = visit.SystolicBloodPressure.ToString();
            this.diastolicBloodPressureTextBox.Text = visit.DiastolicBloodPressure.ToString();
            this.bodyTemperatureTextBox.Text = visit.BodyTemp.ToString();
            this.pulseTextBox.Text = visit.Pulse.ToString();
            this.heightTextBox.Text = visit.Height.ToString();
            this.weightTextBox.Text = visit.Weight.ToString();
            this.symptomsTextBox.Text = visit.Symptoms;

            Nurse nurse = NurseManager.GetNurseByID(visit.NurseID);
            this.nurseComboBox.Items.Add(nurse.FirstName + " " + nurse.LastName + " ID: " + nurse.NurseId);
            this.nurseComboBox.SelectedItem = nurse.FirstName + " " + nurse.LastName + " ID: " + nurse.NurseId;
        }

        private void disableFormControls(Visit visit)
        {
            this.systolicBloodPressureTextBox.Enabled = false;
            this.diastolicBloodPressureTextBox.Enabled = false;
            this.bodyTemperatureTextBox.Enabled = false;
            this.pulseTextBox.Enabled = false;
            this.heightTextBox.Enabled = false;
            this.weightTextBox.Enabled = false;
            this.symptomsTextBox.Enabled = false;
            this.nurseComboBox.Enabled = false;
            this.submitChangesFooter1.HideSubmitButton(this.submitChangesFooter1);
        }

        private void populateNurseComboBox()
        {
            foreach (var nurse in NurseManager.GetNurses())
            {
                var nurseInfo = nurse.FirstName + " " + nurse.LastName + " ID: " + nurse.NurseId;
                this.nurseComboBox.Items.Add(nurseInfo);
            }
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

                var nurseID = this.getNurseID(this.nurseComboBox.Text);
                Visit visitToAdd = new Visit(this.appointmentID, nurseID, Convert.ToDouble(this.bodyTemperatureTextBox.Text), 
                    Convert.ToInt16(this.pulseTextBox.Text), Convert.ToDouble(this.heightTextBox.Text),
                    Convert.ToDouble(this.weightTextBox.Text), this.symptomsTextBox.Text, 
                    Convert.ToInt16(this.systolicBloodPressureTextBox.Text), 
                    Convert.ToInt16(this.diastolicBloodPressureTextBox.Text));
                CheckupManagerViewModel.AddVisit(visitToAdd);
                Form searchPatientForm = new SearchPatient();
                SwitchForms.Switch(this, searchPatientForm);
            }
            catch (Exception)
            {
                MessageBox.Show(this.invalidInputErrorMessage, this.invalidInputErrorHeader);
            }
        }

        private int getNurseID(string nurseInfo)
        {
            string[] nurseInfoSplit = nurseInfo.Split(' ');

            if (nurseInfoSplit.Length > 2)
            {
                var firstName = nurseInfoSplit[0];
                var lastName = nurseInfoSplit[1];
                var ID = nurseInfoSplit[3];
                return Int32.Parse(ID);
            }

            return -1;

        }

        private void verifyAll()
        {
            CheckupValidation.VerifySystolicBloodPressureInput(this.systolicBloodPressureTextBox, this.systolicBloodPressureErrorMessage);
            CheckupValidation.VerifyDiastolicBloodPressureInput(this.diastolicBloodPressureTextBox, this.diastolicBloodPressureErrorMessage);
            CheckupValidation.VerifyBodyTemperatureInput(this.bodyTemperatureTextBox, this.bodyTempErrorMessage);
            CheckupValidation.VerifyPulseInput(this.pulseTextBox, this.pulseErrorMessage);
            CheckupValidation.VerifyHeightInput(this.heightTextBox, this.heightErrorMessage);
            CheckupValidation.VerifyWeightInput(this.weightTextBox, this.weightErrorMessage);
            CheckupValidation.VerifyNurseInput(this.nurseComboBox, this.nurseErrorMessage);
            CheckupValidation.VerifySymptomsInput(this.symptomsTextBox, this.symptomsErrorMessage);
        }

        private void systolicBloodPressureTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifySystolicBloodPressureInput(this.systolicBloodPressureTextBox, this.systolicBloodPressureErrorMessage);
        }

        private void diastolicBloodPressureTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyDiastolicBloodPressureInput(this.diastolicBloodPressureTextBox, this.diastolicBloodPressureErrorMessage);
        }

        private void bodyTemperatureTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyBodyTemperatureInput(this.bodyTemperatureTextBox, this.bodyTempErrorMessage);
        }

        private void pulseTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyPulseInput(this.pulseTextBox, this.pulseErrorMessage);
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyHeightInput(this.heightTextBox, this.heightErrorMessage);
        }

        private void weightTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyWeightInput(this.weightTextBox, this.weightErrorMessage);
        }

        private void nurseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifyNurseInput(this.nurseComboBox, this.nurseErrorMessage);
        }

        private void symptomsTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckupValidation.VerifySymptomsInput(this.symptomsTextBox, this.symptomsErrorMessage);
        }
    }
}
