using System;
using System.Collections.Generic;
using CS3230Project.Model.Tests;
using CS3230Project.Model.Users;
using CS3230Project.Model.Visits;

namespace CS3230Project.ViewModel.AdminVisitsSearch
{
    /// <summary>
    ///   the view model for the admin visits search
    /// </summary>
    public static class AdminVisitsSearchViewModel
    {

        /// <summary>
        /// Gets all visits between dates.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>
        ///   A list of all the visits between the 2 dates provided.
        /// </returns>
        public static List<AdminSearchVisit> GetAllVisitsBetweenDates(DateTime startDate, DateTime endDate)
        {
            return AdminVisitsSearchManager.GetAllVisitsBetweenDates(startDate, endDate);
        }

        /// <summary>
        /// Gets all admin search tests for appointment.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns>
        ///   a list of admin search tests for an appointment
        /// </returns>
        public static List<AdminSearchTest> GetAllAdminSearchTestsForAppointment(int appointmentId)
        {
            return AdminVisitsSearchManager.GetAllAdminSearchTestsForAppointment(appointmentId);
        }

    }
}
