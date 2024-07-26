using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class CreateGrapesDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "At least 5 Characters")]
        [MaxLength(20, ErrorMessage = "Max Characters is 20")]
       public String Name {get; set;} = string.Empty; 
    }
}
