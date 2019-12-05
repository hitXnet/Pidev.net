namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mysqlpi.likecom")]
    public partial class likecom
    {
        [Key]
        public int likeC_id { get; set; }

        public int? fk_com_id { get; set; }

        public int? fk_emp_id { get; set; }

        public virtual commentaire commentaire { get; set; }

        public virtual employe employe { get; set; }
    }
}
