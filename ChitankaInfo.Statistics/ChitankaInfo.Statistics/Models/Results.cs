using System.Collections.Generic;

using ChitankaInfo.Statistics.Models;

using YAXLib;

public class Results
{
    [YAXSerializeAs("books")]
    [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
    public List<Book> CollectionOfBooks { get; set; }

    [YAXSerializeAs("persons")]
    [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
    public List<Person> CollectionOfPersons { get; set; }

    [YAXSerializeAs("texts")]
    [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
    public List<Text> CollectionOfTexts { get; set; }

    [YAXSerializeAs("series")]
    [YAXErrorIfMissed(YAXExceptionTypes.Ignore)]
    public List<Serie> CollectionOfSeries { get; set; }
}