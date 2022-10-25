using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.DAL.Visits;

namespace CS3230Project.Model.Visits
{
    public class VisitManager
    {

        public static bool AddVisit(Visit visitToAdd)
        {
            return VisitDal.AddVisit(visitToAdd);
        }

    }
}
