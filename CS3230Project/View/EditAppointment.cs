using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CS3230Project.Model.Appointments;
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
    /// The edit appointment form
    /// </summary>
    public partial class EditAppointment : Form
    {
        private readonly string invalidInputErrorMessage = "Invalid Values for Editing Appointment";
        private readonly string invalidInputErrorHeader = "Unable to edit Appointment";
        private readonly Patient patient;
        private readonly Appointment appointmentToEdit;
        private List<Doctor> availableDoctors;

        /// <summary>
        /// Initializes a new <see cref="EditAppointment"/>
        /// </summary>
        /// <param name="appointmentToEdit">The appointment to edit</param>
        /// <param name="patient">The patient ID for the appointment</param>
        public EditAppointment(Appointment appointmentToEdit, Patient patient)
        {
            this.InitializeComponent();
            this.PatientNameAndIdLabel.Text = $"{patient.PatientId}, {patient.LastName}, {patient.FirstName}";
            this.PatientDateOfBirthLabel.Text = $"Birthdate: {patient.DateOfBirth}";
            this.PatientPhoneNumberLabel.Text = $"Phone: {patient.PhoneNumber}";
            this.submitChangesFooter1.BackButtonEventHandler += this.SubmitChangesFooter1OnBackButtonEventHandler;
            this.submitChangesFooter1.SubmitButtonEventHandler += this.SubmitChangesFooter1OnSubmitButtonEventHandler;
            this.availableDoctors = new List<Doctor>();
            this.appointmentDatePicker.Format = DateTimePickerFormat.Custom;
            this.appointmentDatePicker.CustomFormat = AppointmentSettings.DateTimeFormat;
            this.appointmentToEdit = appointmentToEdit;
            this.patient = patient;
            this.appointmentDatePicker.Value = this.appointmentToEdit.Date;
            this.populateEditAppointmentValues();
        }

        private void populateEditAppointmentValues()
        {
            this.reasonTextBox.Text = this.appointmentToEdit.Reason;
            this.availableDoctors = DoctorsManagerViewModel.GetAvailableDoctors(this.appointmentDatePicker.Value);
            this.addCurrentAppointmentDoctorAsAvailableDoctor();
        }

        private void addCurrentAppointmentDoctorAsAvailableDoctor()
        {
            this.availableDoctors.Add(this.appointmentToEdit.Doctor);
            this.availableDoctors = this.availableDoctors.OrderBy(d => d.DoctorId).ToList();
        }

        private void SubmitChangesFooter1OnSubmitButtonEventHandler(object sender, EventArgs e)
        {
            try
            {
                this.validateAll();
                var appointmentDate = this.convertAppointmentDateTimeToZero();
                AppointmentManagerViewModel.ModifyAppointment(this.appointmentToEdit.AppointmentId, appointmentDate,
                    this.availableDoctors[this.appointmentDoctorDropDown.SelectedIndex].DoctorId, this.reasonTextBox.Text);
                SwitchForms.Switch(this, new Appointments(this.patient));
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

            if (appointmentDate == this.appointmentToEdit.Date)
            {
                this.addCurrentAppointmentDoctorAsAvailableDoctor();
            }

            foreach (var doctor in this.availableDoctors)
            {
                var doctorString = this.convertDoctorToDoctorString(doctor);
                this.appointmentDoctorDropDown.Items.Add(doctorString);
            }
        }

        private string convertDoctorToDoctorString(Doctor doctor)
        {
            return doctor.DoctorId + ", " + doctor.FirstName + ' ' + doctor.LastName;
        }

        private void appointmentDatePicker_ValueChanged(object sender, EventArgs e)
        {
            this.availableDoctors = DoctorsManagerViewModel.GetAvailableDoctors(this.appointmentDatePicker.Value);
            this.availableDoctors = this.availableDoctors.OrderBy(d => d.DoctorId).ToList();
            this.populateDoctorsDropDown();
        }
    }
}
