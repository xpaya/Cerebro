using System.Collections.Generic;

namespace CerebroInfo.Dto
{
    public class Stories
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public List<Item2> items { get; set; }
    }
}