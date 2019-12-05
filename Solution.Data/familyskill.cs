namespace Solution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev4gl.familyskills")]
    public partial class familyskill
    {
        [Key]
        public int IdFamily { get; set; }

        [StringLength(255)]
        public string FamilyName { get; set; }

        public int? skills_Idskill { get; set; }

        public int? reference_idref { get; set; }

        public virtual reference reference { get; set; }

        public virtual skill skill { get; set; }
    }
}
