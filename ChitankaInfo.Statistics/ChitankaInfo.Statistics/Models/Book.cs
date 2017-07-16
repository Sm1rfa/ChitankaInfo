using System.Xml.Serialization;

using YAXLib;

namespace ChitankaInfo.Statistics.Models
{
    using System;

    [Serializable, XmlRoot("book")]
    public class Book
    {
        [YAXSerializeAs("id")]
        public int BookId { get; set; }

        [YAXSerializeAs("slug")]
        public string Slug { get; set; }

        [YAXSerializeAs("title")]
        public string Title { get; set; }

        [YAXSerializeAs("subtitle")]
        public string SubTitle { get; set; }

        [YAXSerializeAs("title-extra")]
        public string TitleExtra { get; set; }


        [YAXSerializeAs("orig-title")]
        public string OriginalTitle { get; set; }

        [YAXSerializeAs("lang")]
        public string BookLanguage { get; set; }

        [YAXSerializeAs("orig-lang")]
        public string OriginalLanguage { get; set; }

        [YAXSerializeAs("year")]
        public string PublishedYear { get; set; }

        [YAXSerializeAs("type")]
        public string BookType { get; set; }

        [YAXSerializeAs("author")]
        public BookAuthor Author { get; set; }

        [YAXSerializeAs("sequence")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public Sequence Sequence { get; set; }

        [YAXSerializeAs("category")]
        public Category Category { get; set; }

        [YAXSerializeAs("has-annotation")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string HasAnnotation { get; set; }

        [YAXSerializeAs("has-cover")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string HasCover { get; set; }

        [YAXSerializeAs("removed-notice")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string RemovedNotice { get; set; }

        [YAXSerializeAs("created-at")]
        public DateTime CreatedAt { get; set; }
    }
}
