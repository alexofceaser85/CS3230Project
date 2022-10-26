using CS3230Project.DAL.Visits;

namespace CS3230Project.Model.Visits
{
    /// <summary>
    ///   Manages access and manipulation of the visits
    /// </summary>
    public static class VisitManager
    {

        /// <summary>
        /// Adds the visit.
        /// Precondition: none
        /// Post-condition: visits.length = visits.length @prev + 1
        /// </summary>
        /// <param name="visitToAdd">The visit to add.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static bool AddVisit(Visit visitToAdd)
        {
            return VisitDal.AddVisit(visitToAdd);
        }

    }
}
