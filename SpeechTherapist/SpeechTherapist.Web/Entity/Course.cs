using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpeechTherapist.Web.Entity
{
    [Table("Course", Schema = "school")]
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Unit> UnitList { get; set; }
    }
}
