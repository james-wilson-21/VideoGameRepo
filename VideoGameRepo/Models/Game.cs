using System.ComponentModel.DataAnnotations;

namespace VideoGameRepo.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public decimal Cost { get; set; }
    }
}
