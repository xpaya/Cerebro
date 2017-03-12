using System.Collections.Generic;

namespace CerebroInfo.Dto
{
    public class Data
    {
        public string offset { get; set; }
        public string limit { get; set; }
        public string total { get; set; }
        public string count { get; set; }
        public List<Result> results { get; set; }
    }
}