using System;
using System.Windows.Forms;
using CS3230Project.Settings;
using CS3230Project.View.WindowSwitching;
using CS3230Project.ViewModel.Appointments;

namespace CS3230Project.View
{
    /// <summary>
    /// The appointments form
    /// </summary>
    public partial class Appointments : Form
    {
        private readonly int patientId;
        /// <summary>
        /// Initializes a new <see cref="Appointments"/>
        /// </summary>
        /// <param name="patientId">The patient for the appointments</param>
        public Appointments(int patientId)
        {
            this.InitializeComponent();
            this.patientId = patientId;
            this.footer2.BackButtonEventHandler += this.Footer2OnBackButtonEventHandler;
            this.addUpcomingAppointments();
            this.addPreviousAppointments();
        }

        private void Footer2OnBackButtonEventHandler(object sender, EventArgs e)
        {
            SwitchForms.SwitchBackToHome(this);
        }

        private void addUpcomingAppointments()
        {
            this.upcomingAppointmentsTable.Rows.Clear();
            foreach (var appointment in AppointmentManagerViewModel.GetUpcomingAppointments(this.patientId))
            {
                string[] appointmentDetails =
                {
                    (appointment.Patient.FirstName + " " + appointment.Patient.LastName),
                    appointment.Date.ToString(AppointmentSettings.DateTimeFormat),
                    (appointment.Doctor.FirstName + " " + appointment.Doctor.LastName),
                    appointment.Reason
                };

                this.upcomingAppointmentsTable.Rows.Add(appointmentDetails);
            }
        }

        private void addPreviousAppointments()
        {
            this.previousAppointmentsTable.Rows.Clear();
            foreach (var appointment in AppointmentManagerViewModel.GetPreviousAppointments(this.patientId))
            {
                string[] appointmentDetails =
                {
                    (appointment.Patient.FirstName + " " + appointment.Patient.LastName),
                    appointment.Date.ToShortDateString(),
                    (appointment.Doctor.FirstName + " " + appointment.Doctor.LastName),
                    appointment.Reason
                };

                this.previousAppointmentsTable.Rows.Add(appointmentDetails);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwitchForms.Switch(this, new CreateAppointment(this.patientId));
        }

        private void upcomingAppointmentsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex < 4)
            {
                var appointment = AppointmentManagerViewModel.GetUpcomingAppointments(this.patientId)[e.RowIndex];
                SwitchForms.Switch(this, new EditAppointment(appointment, this.patientId));
            }
        }
    }
}
