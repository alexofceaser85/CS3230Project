using System;
using System.Collections.Generic;
using CS3230Project.DAL.Appointments;

namespace CS3230Project.Model.Appointments
{
    /// <summary>
    /// The model class for the appointment manager
    /// </summary>
    public static class AppointmentManager
    {
        public static List<Appointment> GetUpcomingAppointments(int patientId)
        {
            if (patientId < 0)
            {
                //TODO Add error message
                throw new ArgumentException();
            }
            return AppointmentsDAL.GetUpcomingAppointments(patientId);
        }

        public static List<Appointment> GetPreviousAppointments(int patientId)
        {
            if (patientId < 0)
            {
                //TODO Add error message
                throw new ArgumentException();
            }

            return AppointmentsDAL.GetPreviousAppointments(patientId);
        }
    }
}
