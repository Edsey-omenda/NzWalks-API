using System;
using System.ComponentModel.DataAnnotations;

namespace NzWalks.Models.DTOs
{
    public class AddWalkRequestDTO
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }
    }
}
