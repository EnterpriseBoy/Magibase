using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagiApi.Entities
{
    public class Organizer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OragnizerId { get; set; }

        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
