using System.Collections.Generic;
using CS3230Project.DAL.Nurses;

namespace CS3230Project.Model.Users.Nurses
{
    /// <summary>
    ///   Manages access and manipulation of the nurses
    /// </summary>
    public static class NurseManager
    {

        /// <summary>
        /// Gets the nurses.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <returns>
        ///   all of the nurses
        /// </returns>
        public static List<Nurse> GetNurses()
        {
            return NurseDal.GetNurses();
        }

        /// <summary>
        /// Gets the nurse by identifier.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>
        ///   the nurse with the provided ID
        /// </returns>
        public static Nurse GetNurseByID(int ID)
        {
            return NurseDal.GetNurseByID(ID);
        }
    }
}
