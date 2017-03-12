using System.Collections.Generic;

namespace CerebroInfo.Dto
{
    public class Events
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public List<Item3> items { get; set; }
    }
}