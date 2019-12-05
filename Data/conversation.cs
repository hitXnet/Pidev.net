namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mysqlpi.conversation")]
    public partial class conversation
    {
        [Key]
        public int id_conv { get; set; }

        public int id_emp1 { get; set; }

        public int id_emp2 { get; set; }

        public DateTime? seen_date { get; set; }
    }
}
