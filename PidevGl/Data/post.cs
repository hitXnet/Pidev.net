namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mysqlpi.post")]
    public partial class post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public post()
        {
            commentaires = new HashSet<commentaire>();
            likeposts = new HashSet<likepost>();
        }

        [Key]
        public int post_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        [StringLength(255)]
        public string text { get; set; }

        [StringLength(255)]
        public string video { get; set; }

        public int? fk_emp_id { get; set; }

        public int? fk_forum_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<commentaire> commentaires { get; set; }

        public virtual employe employe { get; set; }

        public virtual forum forum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<likepost> likeposts { get; set; }
    }
}
