using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
     public class Conge
    {


        [Key]
        public int CongeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }


        [Required]
        public string Type { get; set; }

        [ForeignKey("employeId")]
        public virtual employe employe { get; set; }
        public int? employeId { get; set; }

    }
}
