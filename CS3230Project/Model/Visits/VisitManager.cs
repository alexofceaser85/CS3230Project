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
        /// Precondition: visitToAdd != null
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

    }
}
