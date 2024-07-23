namespace api.Dtos
{
    public class UpdateVinesDto
    {
        public string Name {get; set;} = string.Empty;
        public DateTime CreatedOn {get; set;} = DateTime.Now; 
    }
}
