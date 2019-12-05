﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Models
{
    public enum typevm { Technique, Financiere }
    public class ReclamationVm
    {
        [Key]
        public int Idrec { get; set; }
        public string titre { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        
        public string objet { get; set; }
        public string contenu { get; set; }

        public typevm type { get; set; }
        
        public string etat { get; set; }
        public string ImageURL { get; set; }
        [Display(Name = "reclamation Product")]
        public int? ProductId { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
        public IEnumerable<SelectListItem> types { get; set; }



    }
}