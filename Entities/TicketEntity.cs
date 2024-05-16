using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concert.Entities
{
    public class TicketEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString()[^4..];
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public UserEntity? User { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CO2 { get; set; }
    }
}
