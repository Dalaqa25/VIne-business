﻿namespace api.Models
{
    public class Grapes
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public DateTime CreatedOn {get; set;} = DateTime.Now;
    }
}
