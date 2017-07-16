using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;

using ChitankaInfo.Statistics.Models;

using YAXLib;

namespace ChitankaInfo.Statistics.ViewModels
{
    public class TextViewModel : ViewModelBase
    {
        private int textNumber;

        private string filterText;

        public RelayCommand GetTextsCommand { get; set; }

        public ObservableCollection<Text> texts { get; set; }

        public ObservableCollection<Text> TextList
        {
            get
            {
                return this.texts;
            }

            set
            {
                this.texts = value;
                this.OnPropertyChanged();
            }
        }

        public int TextNumber
        {
            get
            {
                return this.textNumber;

            }

            set
            {
                this.textNumber = value;
                this.OnPropertyChanged();
            }
        }

        public string FilterText
        {
            get
            {
                return this.filterText;

            }

            set
            {
                this.filterText = value;
                this.OnPropertyChanged();
            }
        }

        public TextViewModel()
        {
            this.GetTextsCommand = new RelayCommand(this.GetTexts);
        }

        private void GetTexts(object obj)
        {
            var url = "http://chitanka.info/texts/search.xml?q=all";
            var response = string.Empty;
            this.TextList = new ObservableCollection<Text>();
            
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                response = client.DownloadString(url);
            }

            var ser = new YAXSerializer(typeof(Results));
            try
            {
                Results sample = (Results)ser.Deserialize(response);

                foreach (var x in sample.CollectionOfTexts)
                {
                    this.TextList.Add(new Text
                    {
                        TextId = x.TextId,
                        TextSlug = x.TextSlug,
                        TextTitle = x.TextTitle,
                        TextOriginalTitle = x.TextOriginalTitle,
                        TextLanguage = x.TextLanguage,
                        TextOriginalLanguage = x.TextOriginalLanguage,
                        TextYear = x.TextYear,
                        TextTranslationYear = x.TextTranslationYear,
                        TextType = x.TextType,
                        TextAuthor = new BookAuthor
                        {
                            AuthorId = x.TextAuthor.AuthorId,
                            AuthorSlug = x.TextAuthor.AuthorSlug,
                            Name = x.TextAuthor.Name,
                            OriginalName = x.TextAuthor.OriginalName,
                            Country = x.TextAuthor.Country,
                            Info = x.TextAuthor.Info
                        },
                        TextSerie = new Serie
                        {
                            SerieId = x.TextSerie.SerieId,
                            SerieSlug = x.TextSerie.SerieSlug,
                            SerieName = x.TextSerie.SerieName,
                            SerieOriginalName = x.TextSerie.SerieOriginalName
                        },
                        TextTranslator = new Translator
                        {
                            TranslatorId = x.TextTranslator.TranslatorId,
                            TranslatorSlug = x.TextTranslator.TranslatorSlug,
                            TranslatorName = x.TextTranslator.TranslatorName,
                            TranslatorCountry = x.TextTranslator.TranslatorCountry
                        },
                        TextSource = x.TextSource,
                        TextSize = x.TextSize,
                        TextCommentCount = x.TextCommentCount,
                        TextRating = x.TextRating,
                        TextRemovedNotice = x.TextRemovedNotice,
                        TextCreatedAt = x.TextCreatedAt
                    });
                }

                this.TextNumber = this.TextList.Count;
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }
    }
}
