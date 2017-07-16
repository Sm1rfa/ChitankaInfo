using YAXLib;

namespace ChitankaInfo.Statistics.Models
{
    public class Person
    {
        [YAXSerializeAs("id")]
        public int AuthorId { get; set; }
        [YAXSerializeAs("slug")]
        public string AuthorSlug { get; set; }
        [YAXSerializeAs("name")]
        public string Name { get; set; }
        [YAXSerializeAs("orig-name")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string OriginalName { get; set; }
        [YAXSerializeAs("country")]
        public string Country { get; set; }
        [YAXSerializeAs("info")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string Info { get; set; }
    }
}
