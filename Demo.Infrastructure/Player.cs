using System.ComponentModel.DataAnnotations;

namespace Demo.Infrastructure
{
    /// <summary>
    /// Сущность - Игрок
    /// </summary>
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}