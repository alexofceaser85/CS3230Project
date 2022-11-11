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
        /// Modifies the visit.
        ///
        /// Precondition: none
        /// Post-condition: the visit is modified with the provided details
        /// </summary>
        /// <param name="modifiedVisit">The modified visit.</param>
        /// <returns>
        ///   True if the visit was successfully modified
        ///   False if the visit was not modified
        /// </returns>
        public static bool ModifyVisit(Visit modifiedVisit)
        {
            return VisitManager.ModifyVisit(modifiedVisit);
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
