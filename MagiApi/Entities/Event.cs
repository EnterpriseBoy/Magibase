using MagiApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagiApi.Entities
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        [Required]
        [MaxLength(50)]
        public string First_Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(2000)]
        public string Comments { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public Organizer Organizer { get; set; }

        public List<Participant> Participants { get; set; }
        public Location Location { get; set; }

    }
}
