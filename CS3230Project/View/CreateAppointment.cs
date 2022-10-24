using System;
using System.Windows.Forms;
using CS3230Project.Settings;
using CS3230Project.View.Validation;
using CS3230Project.ViewModel.Appointments;
using CS3230Project.ViewModel.Doctors;

namespace CS3230Project.View
{
    /// <summary>
    /// The form to create an appointment
    /// </summary>
    public partial class CreateAppointment : Form
    {
        private readonly string invalidInputErrorMessage = "Invalid Values for Creating Appointment";
        private readonly string invalidInputErrorHeader = "Unable to create Appointment";
        private readonly int patientId;
        /// <summary>
        /// Creates a new <see cref="CreateAppointment"/>
        /// </summary>
        /// <param name="patientId">The id of the patient who the appointment is for</param>
        public CreateAppointment(int patientId)
        {
            this.InitializeComponent();
            this.submitChangesFooter1.SubmitButtonEventHandler += this.SubmitChangesFooter1OnSubmitButtonEventHandler;
            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.appointmentDatePicker.Format = DateTimePickerFormat.Custom;
            this.appointmentDatePicker.CustomFormat = AppointmentSettings.DateTimeFormat;
            this.patientId = patientId;
            this.populateDoctorsDropDown();
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            WindowSwitching.SwitchForms.Switch(this, new Appointments(this.patientId));
        }

        private void SubmitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            try
            {
                this.validateAll();
                var appointmentDate = this.convertAppointmentDateTimeToZero();
                AppointmentManagerViewModel.AddAppointment(this.patientId, appointmentDate,
                    this.appointmentDoctorDropDown.SelectedIndex + 1, this.reasonTextBox.Text);
                WindowSwitching.SwitchForms.Switch(this, new Appointments(this.patientId));
            }
            catch (ArgumentException)
            {
                MessageBox.Show(this.invalidInputErrorHeader, this.invalidInputErrorMessage);
            }
        }

        private void appointmentDatePicker_ValueChanged(object sender, EventArgs e)
        {
            this.populateDoctorsDropDown();
        }

        private void populateDoctorsDropDown()
        {
            this.appointmentDoctorDropDown.Items.Clear();
            var appointmentDate = this.convertAppointmentDateTimeToZero();
            foreach (var doctor in DoctorsManagerViewModel.GetAvailableDoctors(appointmentDate))
            {
                var doctorString = doctor.DoctorId + ", " + doctor.FirstName + ' ' + doctor.LastName;
                this.appointmentDoctorDropDown.Items.Add(doctorString);
            }
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
    }
}
