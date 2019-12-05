using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public enum AgentType
    {
        Passable,
        Refuse
    }

    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        [Required (ErrorMessage = "FirstName is requied")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is requied")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required (ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public AgentType Type { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Heure_travail { get; set; }

        public virtual ICollection<Tache> Taches { get; set; }

    }
}