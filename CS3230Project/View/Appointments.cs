using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS3230Project.ViewModel.Appointments;

namespace CS3230Project.View
{
    /// <summary>
    /// The appointments form
    /// </summary>
    public partial class Appointments : Form
    {
        /// <summary>
        /// Initializes a new <see cref="Appointments"/>
        /// </summary>
        /// <param name="patientId">The patient for the appointments</param>
        public Appointments(int patientId)
        {
            InitializeComponent();
            this.footer2.BackButtonEventHandler += Footer2OnBackButtonEventHandler;
            this.addUpcomingAppointments(patientId);
            this.addPreviousAppointments(patientId);
        }

        private void Footer2OnBackButtonEventHandler(object sender, EventArgs e)
        {
            WindowSwitching.SwitchForms.SwitchBackToHome(this);
        }

        private void addUpcomingAppointments(int patientId)
        {
            this.upcomingAppointmentsTable.Rows.Clear();
            foreach (var appointment in AppointmentManagerViewModel.GetUpcomingAppointments(patientId))
            {
                string[] appointmentDetails =
                {
                    (appointment.Patient.FirstName + " " + appointment.Patient.LastName),
                    appointment.Date.ToShortDateString(),
                    (appointment.Doctor.FirstName + " " + appointment.Doctor.LastName),
                    appointment.Reason
                };

                this.upcomingAppointmentsTable.Rows.Add(appointmentDetails);
            }
        }

        private void addPreviousAppointments(int patientId)
        {
            this.previousAppointmentsTable.Rows.Clear();
            foreach (var appointment in AppointmentManagerViewModel.GetPreviousAppointments(patientId))
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
    }
}
