﻿namespace api.Helpers
{
    public class VinesQuery
    {
        public string? Name {get; set;} = null;
        public int pageNumber {get; set;} = 1;
        public int pageSize {get; set;} = 20;
    }
}