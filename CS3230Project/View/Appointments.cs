using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.ErrorMessages;
using CS3230Project.Model.Appointments;
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

        private List<Appointment> previousAppointments;
        private List<Appointment> upcomingAppointments;
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
            this.previousAppointments = new List<Appointment>();
            this.upcomingAppointments = new List<Appointment>();
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
                    appointment.Reason, appointment.AppointmentId.ToString()
                };

                this.upcomingAppointmentsTable.Rows.Add(appointmentDetails);
                this.upcomingAppointments.Add(appointment);
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
                    appointment.Reason, appointment.AppointmentId.ToString()
                };

                this.previousAppointmentsTable.Rows.Add(appointmentDetails);
                this.previousAppointments.Add(appointment);
            }
        }

        private void upcomingAppointmentsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView == null || e.RowIndex >= dataGridView.RowCount)
            {
                return;
            }

            if (upcomingAppointmentsTable.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                var appointmentID = int.Parse((string)upcomingAppointmentsTable.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value);

                if (appointmentID >= 0)
                {
                       SwitchForms.Switch(this, new Checkup(appointmentID, true));
                }
                else
                {
                    throw new ArgumentException(AppointmentErrorMessages.AppointmentIdCannotBeLessThanZero);
                }
            }
        }

        private void previousAppointmentsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView == null || e.RowIndex >= dataGridView.RowCount)
            {
                return;
            }

            if (previousAppointmentsTable.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 &&
                e.ColumnIndex == 5)
            {
                var appointmentID =
                    int.Parse((string)previousAppointmentsTable.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value);
                if (appointmentID >= 0)
                {
                       SwitchForms.Switch(this, new Checkup(appointmentID, false));
                }
                else
                {
                    throw new ArgumentException(AppointmentErrorMessages.AppointmentIdCannotBeLessThanZero);
                }
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
