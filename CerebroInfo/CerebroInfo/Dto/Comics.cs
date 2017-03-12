using System.Collections.Generic;
using Newtonsoft.Json;

namespace CerebroInfo.Dto
{

    public class Comics
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public List<Item> items { get; set; }
    }
}