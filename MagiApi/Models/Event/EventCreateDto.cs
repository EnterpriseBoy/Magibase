using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagiApi.Models
{
    public class EventCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength (200)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string First_Name { get; set; }
        public string StartDate { get; set; }

    }
}
