using System.ComponentModel.DataAnnotations;

namespace WeBStore.Dto
{
    public class GenresDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}