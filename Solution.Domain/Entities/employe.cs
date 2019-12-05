namespace Solution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("last.employe")]
    public partial class employe
    {
        [Key]
        public int emp_id { get; set; }

        [StringLength(255)]
        public string bio { get; set; }

        [StringLength(255)]
        public string cv { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_embauche { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string login { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string photo { get; set; }
    }
}
