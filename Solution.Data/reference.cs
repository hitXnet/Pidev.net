namespace Solution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev4gl.reference")]
    public partial class reference
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reference()
        {
            familyskills = new HashSet<familyskill>();
        }

        [Key]
        public int idref { get; set; }

        [StringLength(255)]
        public string nomref { get; set; }

        public int noteref { get; set; }

        [StringLength(255)]
        public string backing { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<familyskill> familyskills { get; set; }
    }
}
