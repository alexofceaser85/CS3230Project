using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.DAL;

namespace CS3230Project.Model.Users
{
    public static class AdminVisitsSearchManager
    {

        public static bool GetAllVisitsBetweenDates(DateTime startDate, DateTime endDate)
        {
            return AdminVisitsSearchDal.GetAllVisitsBetweenDates(startDate, endDate);
        }

    }
}
