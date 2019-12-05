namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mysqlpi.likepost")]
    public partial class likepost
    {
        [Key]
        public int like_id { get; set; }

        public int? fk_emp_id { get; set; }

        public int? fk_post_id { get; set; }

        public virtual employe employe { get; set; }

        public virtual post post { get; set; }
    }
}
