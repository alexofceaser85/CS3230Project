using CS3230Project.Model.Visits;

namespace CS3230Project.ViewModel.Checkups
{
    /// <summary>
    ///   The view model for the checkups
    /// </summary>
    public static class CheckupManagerViewModel
    {
        /// <summary>
        /// Adds the visit.
        ///
        /// Precondition: none
        /// Post-condition: The visit was added
        /// </summary>
        /// <param name="visitToAdd">The visit to add.</param>
        /// <returns>
        ///   true if the visit was added
        ///   false if the visit was not added
        /// </returns>
        public static bool AddVisit(Visit visitToAdd)
        {
            return VisitManager.AddVisit(visitToAdd);
        }

        /// <summary>
        /// Gets the visit.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="appointmentID">The appointment identifier.</param>
        /// <returns>
        ///   The visit, if exists
        /// </returns>
        public static Visit GetVisit(int appointmentID)
        {
            return VisitManager.GetVisit(appointmentID);
        }

    }
}
