namespace api.Models
{
    public class Grapes
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public DateTime CreatedOn {get; set;} = DateTime.Now;

        //forign key
        public int? VinesId {get; set;}

        //Navigation
        public Vines? Vine {get; set;}
    }
}
