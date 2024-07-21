namespace api.Dtos
{
    public class CreateVinesDto
    {
        public string Name {get; set;} = string.Empty;
        public DateTime CreatedOn {get; set;} = DateTime.Now; 
    }
}
