using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.Model.Users;

namespace CS3230Project.ViewModel.AdminVisitsSearch
{
    public static class AdminVisitsSearchViewModel
    {

        public static bool GetAllVisitsBetweenDates(DateTime startDate, DateTime endDate)
        {
            return AdminVisitsSearchManager.GetAllVisitsBetweenDates(startDate, endDate);
        }

    }
}
