using api.Models;

namespace api.Dtos.Grapes
{
    public class GrapesDto
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public int? VinesId {get; set;}
        
    }
}
