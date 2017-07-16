using System.Xml.Serialization;

using YAXLib;

namespace ChitankaInfo.Statistics.Models
{
    public class Category
    {
        [YAXSerializeAs("id")]
        public int CategoryId { get; set; }
        [YAXSerializeAs("slug")]
        public string CategorySlug { get; set; }
        [YAXSerializeAs("name")]
        public string CategoryName { get; set; }
        [YAXSerializeAs("nr-of-books")]
        public int NumberOfBooks { get; set; }
    }
}
