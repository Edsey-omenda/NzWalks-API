using System.ComponentModel.DataAnnotations;

namespace NzWalks.Models.DTOs
{
    public class AddRegionDTO
    {
        [Required]
        [MinLength(3, ErrorMessage ="Code is required to have a minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code is required to have a maximum of 3 characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
