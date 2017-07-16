using YAXLib;

namespace ChitankaInfo.Statistics.Models
{
    public class Translator
    {
        [YAXSerializeAs("id")]
        public int TranslatorId { get; set; }
        [YAXSerializeAs("slug")]
        public int TranslatorSlug { get; set; }
        [YAXSerializeAs("name")]
        public int TranslatorName { get; set; }
        [YAXSerializeAs("country")]
        [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
        public int TranslatorCountry { get; set; }
    }
}
