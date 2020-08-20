using System.ComponentModel.DataAnnotations;

namespace MagiApi.Models.Event
{
    /// <summary>
    /// Event Creat Class
    /// </summary>
    public class EventCreateDto
    {
        /// <summary>
        /// Name required Max Lenght 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Description required Max Lenght 200
        /// </summary>
        [Required]
        [MaxLength (200)]
        public string Description { get; set; }
    }
}
