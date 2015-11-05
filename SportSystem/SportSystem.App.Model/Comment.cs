using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSystem.App.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public DateTime CreationDateTime { get; set; }

        [ForeignKey("OwnerUserId")]
        public virtual User OwnerUser { get; set; }
        
        [Required]
        public string OwnerUserId { get; set; } 

        [ForeignKey("MatchId")]
        public virtual Match Match { get; set; }

        [Required]
        public int MatchId { get; set; }
    }
}