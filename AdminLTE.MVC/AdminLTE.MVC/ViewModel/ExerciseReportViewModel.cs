using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.ViewModel
{
    public class ExerciseReportViewModel
    {
        public List<Models.School.Exercise> ExerciseList { get; set; }
        public int UnitId { get; set; }
    }
}
