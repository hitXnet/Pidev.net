using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Facture
    {

        [Key]
        public int idfacture { get; set; }

        public string imagefacture { get; set; }

        public string descriptionfacture { get; set; }
    }
}
