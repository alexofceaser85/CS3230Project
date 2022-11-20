using CS3230Project.Model.Users;
using CS3230Project.Model.Users.Nurses;

namespace CS3230Project.ViewModel.Nurses
{
    /// <summary>
    /// The view model for the Nurse Manager
    /// </summary>
    public static class NurseManagerViewModel
    {
        /// <summary>
        /// Gets the nurse by id
        /// </summary>
        /// <param name="nurseIdToGet">The nurse id to get</param>
        /// <returns>The nurse with the given id</returns>
        public static Nurse GetNurseByID(int nurseIdToGet)
        {
            return NurseManager.GetNurseByID(nurseIdToGet);
        }
    }
}
