using System.ComponentModel.DataAnnotations;

namespace Web
{
    
    public partial class notefraisemploye
    {
        [Key]
        public int idfraisem { get; set; }

        [StringLength(255)]
        public string descriptionem { get; set; }

        public float montantfraisem { get; set; }

        public string naturefraisem { get; set; }
    }
}
