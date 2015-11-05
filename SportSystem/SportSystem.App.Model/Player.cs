using System;
using System.ComponentModel.DataAnnotations;

namespace SportSystem.App.Model
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Decimal Height { get; set; }

        public virtual Team Team { get; set; }

        public int? TeamId { get; set; }
    }
}