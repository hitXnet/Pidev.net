using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public enum typevm { Technique, Financiere }
    public class reclamation
    {

       [Key]
        public int Idrec { get; set; }
        public string titre { get; set; }

        public DateTime date { get; set; }

        public string objet { get; set; }
        public string contenu { get; set; }
        public string etat { get; set; }

        public string ImageURL { get; set; }
        public typevm type { get; set; }
        public int? ProductId { get; set; }
        // PROP DE NAVIG
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }


    }
}
