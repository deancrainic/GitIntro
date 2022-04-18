using System.ComponentModel.DataAnnotations;

namespace HakunaMatata.API.Dto
{
    public class ImageCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
    }
}
