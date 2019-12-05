namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mysqlpi.commentaire")]
    public partial class commentaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public commentaire()
        {
            likecoms = new HashSet<likecom>();
        }

        [Key]
        public int com_id { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string text { get; set; }

        public int? fk_emp_id { get; set; }

        public int? fk_post_id { get; set; }

        public virtual employe employe { get; set; }

        public virtual post post { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<likecom> likecoms { get; set; }
    }
}
