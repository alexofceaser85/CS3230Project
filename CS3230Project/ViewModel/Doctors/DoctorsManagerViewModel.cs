using System;
using System.Collections.Generic;
using CS3230Project.Model.Users;

namespace CS3230Project.ViewModel.Doctors
{
    /// <summary>
    /// The view model for the doctors manager
    /// </summary>
    public static class DoctorsManagerViewModel
    {
        /// <summary>
        /// Gets the doctors available for the given date and time
        /// </summary>
        /// <param name="dateTimeToGet">The date and time to get the available doctors for</param>
        /// <returns>The available doctors for the given date and time</returns>
        public static List<Doctor> GetAvailableDoctors(DateTime dateTimeToGet)
        {
            return DoctorManager.GetAvailableDoctors(dateTimeToGet);
        }
    }
}
