using System;
using System.Collections.Generic;
using CS3230Project.DAL;
using CS3230Project.ErrorMessages;
using CS3230Project.Model.Tests;
using CS3230Project.Model.Visits;

namespace CS3230Project.Model.Users
{
    /// <summary>
    ///   The manager class for the admin visits search
    /// </summary>
    public static class AdminVisitsSearchManager
    {

        /// <summary>
        /// Gets all admin search visits between dates.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>
        ///   A list of admin search visits that were between the 2 provided dates
        /// </returns>
        public static List<AdminSearchVisit> GetAllVisitsBetweenDates(DateTime startDate, DateTime endDate)
        {
            return AdminVisitsSearchDal.GetAllVisitsBetweenDates(startDate, endDate);
        }

        /// <summary>
        /// Gets all admin search tests for appointment.
        ///
        /// Precondition: appointmentId MORE THAN OR EQUAL TO 0
        /// Post-condition: none
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns>
        ///   a list of the admin search tests for an appointment
        /// </returns>
        public static List<AdminSearchTest> GetAllAdminSearchTestsForAppointment(int appointmentId)
        {
            if (appointmentId < 0)
            {
                throw new ArgumentException(VisitErrorMessages.AppointmentIDCannotBeLessThanZero);
            }

            return AdminVisitsSearchDal.GetAllAdminSearchTestsForAppointment(appointmentId);
        }

    }
}
