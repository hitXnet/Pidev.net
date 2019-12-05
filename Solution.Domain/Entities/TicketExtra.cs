

namespace Solution.Presentation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    public class TicketExtra
    {
        public int id { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        public int flextime { get; set; }

        [StringLength(255)]
        public string tache { get; set; }

        public int price { get; set; }

        public int id_emp { get; set; }



    }
}