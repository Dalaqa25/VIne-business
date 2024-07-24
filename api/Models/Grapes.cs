namespace api.Models
{
    public class Grapes
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public DateTime CreatedOn {get; set;} = DateTime.Now;

        
        public int? VinesId {get; set;}
        public Vines? Vine {get; set;}
    }
}
