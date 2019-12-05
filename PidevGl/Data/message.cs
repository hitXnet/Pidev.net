namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mysqlpi.message")]
    public partial class message
    {
        [Key]
        public int id_message { get; set; }

        [StringLength(255)]
        public string contenu { get; set; }

        public DateTime? date_message { get; set; }

        public int employe_dest_id { get; set; }

        public int? fk_emp_sender_id { get; set; }

        public virtual employe employe { get; set; }
    }
}
