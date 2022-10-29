using System;
using System.Windows.Forms;
using CS3230Project.Model.Appointments;
using CS3230Project.Model.Users;
using CS3230Project.Settings;
using CS3230Project.View.Validation;
using CS3230Project.View.WindowSwitching;
using CS3230Project.ViewModel.Appointments;
using CS3230Project.ViewModel.Doctors;

namespace CS3230Project.View
{
    /// <summary>
    /// The edit appointment form
    /// </summary>
    public partial class EditAppointment : Form
    {
        private readonly string invalidInputErrorMessage = "Invalid Values for Editing Appointment";
        private readonly string invalidInputErrorHeader = "Unable to edit Appointment";
        private readonly int patientId;
        private readonly Appointment appointmentToEdit;

        /// <summary>
        /// Initializes a new <see cref="EditAppointment"/>
        /// </summary>
        /// <param name="appointmentToEdit">The appointment to edit</param>
        /// <param name="patientId">The patient ID for the appointment</param>
        public EditAppointment(Appointment appointmentToEdit, int patientId)
        {
            this.InitializeComponent();
            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.submitChangesFooter1.SubmitButtonEventHandler += this.SubmitChangesFooter1OnSubmitButtonEventHandler;
            this.appointmentDatePicker.Format = DateTimePickerFormat.Custom;
            this.appointmentDatePicker.CustomFormat = AppointmentSettings.DateTimeFormat;
            this.appointmentToEdit = appointmentToEdit;
            this.patientId = patientId;
            this.appointmentDatePicker.Value = this.appointmentToEdit.Date;
            this.populateEditAppointmentValues();
        }

        private void populateEditAppointmentValues()
        {
            this.reasonTextBox.Text = this.appointmentToEdit.Reason;
            this.populateDoctorsDropDown();
            this.appointmentDoctorDropDown.Sorted = true;
            this.appointmentDoctorDropDown.SelectedIndex =
                this.appointmentDoctorDropDown.FindString(this.convertDoctorToDoctorString(this.appointmentToEdit.Doctor));
        }

        private void SubmitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            try
            {
                this.validateAll();
                var appointmentDate = this.convertAppointmentDateTimeToZero();
                AppointmentManagerViewModel.ModifyAppointment(this.appointmentToEdit.AppointmentId, appointmentDate,
                    this.appointmentDoctorDropDown.SelectedIndex + 1, this.reasonTextBox.Text);
                SwitchForms.Switch(this, new Appointments(this.patientId));
            }
            catch (ArgumentException)
            {
                MessageBox.Show(this.invalidInputErrorHeader, this.invalidInputErrorMessage);
            }
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchBackToHome(this);
        }

        private void validateAll()
        {
            AppointmentValidation.VerifyDateInput(this.appointmentDatePicker, this.AppointmentDateLabel);
            AppointmentValidation.VerifyDoctorInput(this.appointmentDoctorDropDown, this.AppointmentDoctorErrorMessage);
            AppointmentValidation.VerifyReasonInput(this.reasonTextBox, this.AppointmentReasonErrorMessage);
        }

        private DateTime convertAppointmentDateTimeToZero()
        {
            var appointmentDate = this.appointmentDatePicker.Value;
            appointmentDate = appointmentDate.AddSeconds(-appointmentDate.Second);
            return appointmentDate;
        }

        private void populateDoctorsDropDown()
        {
            this.appointmentDoctorDropDown.Items.Clear();
            var appointmentDate = this.convertAppointmentDateTimeToZero();
            foreach (var doctor in DoctorsManagerViewModel.GetAvailableDoctors(appointmentDate))
            {
                var doctorString = this.convertDoctorToDoctorString(doctor);
                this.appointmentDoctorDropDown.Items.Add(doctorString);
            }

            var currentAppointmentDoctorString = this.convertDoctorToDoctorString(this.appointmentToEdit.Doctor);
            this.appointmentDoctorDropDown.Items.Add(currentAppointmentDoctorString);
        }

        private string convertDoctorToDoctorString(Doctor doctor)
        {
            return doctor.DoctorId + ", " + doctor.FirstName + ' ' + doctor.LastName;
        }
    }
}
