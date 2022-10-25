using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.DAL.Nurses;

namespace CS3230Project.Model.Users.Nurses
{
    public static class NurseManager
    {

        public static List<Nurse> GetNurses()
        {
            return NurseDal.GetNurses();
        }

        public static Nurse GetNurseByID(int ID)
        {
            return NurseDal.GetNurseByID(ID);
        }
    }
}
