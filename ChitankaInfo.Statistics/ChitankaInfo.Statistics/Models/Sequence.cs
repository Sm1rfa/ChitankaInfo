using System.Xml.Serialization;

using YAXLib;

namespace ChitankaInfo.Statistics.Models
{
    public class Sequence
    {
        [YAXSerializeAs("id")]
        public int SequenceId { get; set; }
        [YAXSerializeAs("slug")]
        public string SequenceSlug { get; set; }
        [YAXSerializeAs("name")]
        public string SequenceName { get; set; }
        [YAXSerializeAs("publisher")]
        public string PublisherName { get; set; }
    }
}
