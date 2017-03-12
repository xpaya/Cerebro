namespace CerebroInfo.Dto
{
    public class RootObject
    {
        public string code { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public Data data { get; set; }
        public string etag { get; set; }
    }
}