using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpeechTherapist.Web.Entity
{
    [Table("Exercise", Schema = "school")]
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
