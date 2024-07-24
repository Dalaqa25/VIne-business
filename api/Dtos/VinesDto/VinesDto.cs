using api.Dtos.Grapes;

namespace api.Dtos
{
    public class VinesDto
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public DateTime CreatedOn {get; set;} = DateTime.Now; 
        public List<GrapesDto> Grape {get; set;} = new List<GrapesDto>();
    }
}
