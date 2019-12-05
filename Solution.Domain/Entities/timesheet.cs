namespace Solution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("last.timesheet")]
    public partial class timesheet
    {
        public int id { get; set; }

        public int NbrH { get; set; }

        public DateTime? date { get; set; }
    }
}
