using YAXLib;

namespace ChitankaInfo.Statistics.Models
{
    public class Serie
    {
        [YAXSerializeAs("id")]
        public int SerieId { get; set; }
        [YAXSerializeAs("slug")]
        public string SerieSlug { get; set; }
        [YAXSerializeAs("name")]
        public string SerieName { get; set; }
        [YAXSerializeAs("orig-name")]
        public string SerieOriginalName { get; set; }
        [YAXSerializeAs("author")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public BookAuthor Author { get; set; }
    }
}
