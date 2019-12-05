using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public  class Resources
    {
        [Key]
        public int ResourceId { get; set; }
        public string TypeResource { get; set; }
        public DateTime? Date_Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }   
        public string Description { get; set; }
   
    }
}
