using CS3230Project.DAL.Visits;
using CS3230Project.ErrorMessages;
using System;

namespace CS3230Project.Model.Visits
{
    /// <summary>
    ///   Manages access and manipulation of the visits
    /// </summary>
    public static class VisitManager
    {

        /// <summary>
        /// Adds the visit.
        /// 
        /// Precondition: visitToAdd != null
        /// Post-condition: the visit is added to the database
        /// </summary>
        /// <param name="visitToAdd">The visit to add.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static bool AddVisit(Visit visitToAdd)
        {
            if (visitToAdd == null)
            {
                throw new ArgumentException(VisitErrorMessages.VisitToAddCannotBeNull);
            }

            return VisitDal.AddVisit(visitToAdd);
        }

        /// <summary>
        /// Modifies the visit.
        ///
        /// Precondition: modifiedVisit != null
        /// Post-condition: the visit is modified with the provided details
        /// </summary>
        /// <param name="modifiedVisit">The modified visit.</param>
        /// <returns>
        ///   True if the visit was successfully modified
        ///   False if the visit was not modified
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static bool ModifyVisit(Visit modifiedVisit)
        {
            if (modifiedVisit == null)
            {
                throw new ArgumentException(VisitErrorMessages.ModifiedVisitCannotBeNull);
            }

            return VisitDal.ModifyVisit(modifiedVisit);
        }

        /// <summary>
        /// Gets the visit.
        ///
        /// Precondition: appointmentID MORE THAN OR EQUAL TO 0
        /// Post-condition: none
        /// </summary>
        /// <param name="appointmentID">The appointment identifier.</param>
        /// <returns>
        ///   the visit, if exists
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static Visit GetVisit(int appointmentID)
        {
            if (appointmentID < 0)
            {
                throw new ArgumentException(VisitErrorMessages.AppointmentIDCannotBeLessThanZero);
            }

            return VisitDal.GetVisit(appointmentID);
        }

    }
}
