using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.Model.Users;
using CS3230Project.Model.Users.Patients;
using CS3230Project.Settings;
using CS3230Project.View.Validation;
using CS3230Project.View.WindowSwitching;
using CS3230Project.ViewModel.Appointments;
using CS3230Project.ViewModel.Doctors;

namespace CS3230Project.View
{
    /// <summary>
    /// The form to create an appointment
    /// </summary>
    public partial class CreateAppointment : Form
    {
        private List<Doctor> availableDoctors;
        private readonly string invalidInputErrorMessage = "Invalid Values for Creating Appointment";
        private readonly string invalidInputErrorHeader = "Unable to create Appointment";
        private readonly Patient patient;
        /// <summary>
        /// Creates a new <see cref="CreateAppointment"/>
        /// </summary>
        /// <param name="patient">The appointment's patient</param>
        public CreateAppointment(Patient patient)
        {
            this.InitializeComponent();
            this.availableDoctors = new List<Doctor>();
            this.PatientNameAndIdLabel.Text = $"{patient.PatientId}, {patient.LastName}, {patient.FirstName}";
            this.PatientDateOfBirthLabel.Text = $"Birthdate: {patient.DateOfBirth}";
            this.PatientPhoneNumberLabel.Text = $"Phone: {patient.PhoneNumber}";
            this.submitChangesFooter1.SubmitButtonEventHandler += this.SubmitChangesFooter1OnSubmitButtonEventHandler;
            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.header1.LogoutEventHandler += this.Header1OnLogoutEventHandler;
            this.appointmentDatePicker.Format = DateTimePickerFormat.Custom;
            this.appointmentDatePicker.CustomFormat = AppointmentSettings.DateTimeFormat;
            this.patient = patient;
            this.populateDoctorsDropDown();
        }

        private void Header1OnLogoutEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchToLogin(this);
        }

        private void SubmitChangesFooter1OnBackButtonEventHandler(object sender, EventArgs e)
        {
            SwitchForms.Switch(this, new Appointments(this.patient));
        }

        private void SubmitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            try
            {
                this.validateAll();
                var appointmentDate = this.convertAppointmentDateTimeToZero();
                AppointmentManagerViewModel.AddAppointment(this.patient.PatientId, appointmentDate,
                    this.availableDoctors[this.appointmentDoctorDropDown.SelectedIndex].DoctorId, this.reasonTextBox.Text);
                SwitchForms.Switch(this, new Appointments(this.patient));
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
            this.availableDoctors = DoctorsManagerViewModel.GetAvailableDoctors(appointmentDate);
            foreach (var doctor in this.availableDoctors)
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
