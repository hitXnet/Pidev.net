using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class ResourcesVM
    {
        public int ResourceId { get; set; }
        public string TypeResource { get; set; }
        public DateTime? Date_Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Description { get; set; }
    }
}