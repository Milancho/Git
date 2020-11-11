using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AdminLTE.MVC.ViewModel
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CourseId { get; set; }
        public string Course { get; set; }

        public int UnitId { get; set; }
        public string Unit { get; set; }

    }
}
