using System;

using YAXLib;

namespace ChitankaInfo.Statistics.Models
{
    public class Text
    {
        [YAXSerializeAs("id")]
        public int TextId { get; set; }
        [YAXSerializeAs("slug")]
        public string TextSlug { get; set; }
        [YAXSerializeAs("title")]
        public string TextTitle { get; set; }
        [YAXSerializeAs("orig-title")]
        public string TextOriginalTitle { get; set; }
        [YAXSerializeAs("lang")]
        public string TextLanguage { get; set; }
        [YAXSerializeAs("orig-lang")]
        public string TextOriginalLanguage { get; set; }
        [YAXSerializeAs("year")]
        public string TextYear { get; set; }
        [YAXSerializeAs("trans-year")]
        public int TextTranslationYear { get; set; }
        [YAXSerializeAs("type")]
        public string TextType { get; set; }
        [YAXSerializeAs("author")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public BookAuthor TextAuthor { get; set; }

        [YAXSerializeAs("serie")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public Serie TextSerie { get; set; }

        [YAXSerializeAs("translator")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public Translator TextTranslator { get; set; }
        [YAXSerializeAs("source")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string TextSource { get; set; }
        [YAXSerializeAs("size")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public int TextSize { get; set; }
        [YAXSerializeAs("comment-count")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public int TextCommentCount { get; set; }
        [YAXSerializeAs("rating")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public double TextRating { get; set; }
        [YAXSerializeAs("removed-notice")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public string TextRemovedNotice { get; set; }
        [YAXSerializeAs("created-at")]
        public DateTime TextCreatedAt { get; set; }
    }
}
