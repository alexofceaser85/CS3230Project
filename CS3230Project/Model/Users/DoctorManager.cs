using System;
using System.Collections.Generic;
using CS3230Project.DAL.Doctors;

namespace CS3230Project.Model.Users
{
    /// <summary>
    /// The manager service class for the doctors
    /// </summary>
    public static class DoctorManager
    {
        /// <summary>
        /// Gets the doctors available for the given date and time
        /// </summary>
        /// <param name="dateTimeToGet">The date and time to find available doctors for</param>
        /// <returns>The doctors available for the given date and time</returns>
        public static List<Doctor> GetAvailableDoctors(DateTime dateTimeToGet)
        {
            return DoctorsDAL.GetAvailableDoctors(dateTimeToGet);
        }
    }
}
