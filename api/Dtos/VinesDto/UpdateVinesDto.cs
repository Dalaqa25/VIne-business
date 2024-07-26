using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace api.Dtos
{
    public class UpdateVinesDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "At least 5 Characters")]
        [MaxLength(20, ErrorMessage = "Max Characters is 20")]
        public string Name {get; set;} = string.Empty;

        [Required]
        public DateTime CreatedOn {get; set;} = DateTime.Now; 
    }
}
