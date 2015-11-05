using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSystem.App.Model
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        
        public virtual Team Team { get; set; }

        [Required]
        public int TeamId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}