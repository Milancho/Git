using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models.School
{
    [Table("Unit", Schema = "school")]
    public class Unit
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Course Course { get; set; }
        public List<Exercise> ExerciseList { get; set; }
    }
}
