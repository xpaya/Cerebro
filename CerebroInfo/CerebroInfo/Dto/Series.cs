using System.Collections.Generic;

namespace CerebroInfo.Dto
{
    public class Series
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public List<Item4> items { get; set; }
    }
}