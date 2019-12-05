using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace Web.Models
{
    public class Multiple
    {

        public List<Conge> congedetails { get; set; }
        public List<Absence> absencedetails { get; set; }
        public List<employe> employedetails { get; set; }
        public int CongeId { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }


        public string Type { get; set; }

  
        public int? emp_id { get; set; }


    }
}