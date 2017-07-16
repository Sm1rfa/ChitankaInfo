using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Windows.Data;
using ChitankaInfo.Statistics.Models;
using YAXLib;

namespace ChitankaInfo.Statistics.ViewModels
{
    public class SerieViewModel : ViewModelBase
    {
        private int serieNumber;

        private CollectionViewSource filterSeries;

        private string filterText;

        public RelayCommand GetSeriesCommand { get; set; }

        private ObservableCollection<Serie> series { get; set; }

        public ObservableCollection<Serie> SerieList
        {
            get
            {
                return this.series;
            }

            set
            {
                this.series = value;
                this.OnPropertyChanged();
            }
        }

        public ICollectionView FilterSeries => this.filterSeries.View;

        public string FilterText
        {
            get
            {
                return this.filterText;
            }

            set
            {
                this.filterText = value;
                this.filterSeries.View.Refresh();
                this.OnPropertyChanged();
            }
        }

        public int SerieNumber
        {
            get
            {
                return this.serieNumber;

            }

            set
            {
                this.serieNumber = value;
                this.OnPropertyChanged();
            }
        }

        public SerieViewModel()
        {
            this.GetSeriesCommand = new RelayCommand(this.GetSeries);

            this.series = new ObservableCollection<Serie>();
            this.filterSeries = new CollectionViewSource { Source = this.SerieList };
            this.filterSeries.Filter += this.SeriesFilter;
        }

        private void GetSeries(object obj)
        {
            var url = "https://chitanka.info/series/search.xml?q=all";
            var response = string.Empty;

            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                response = client.DownloadString(url);
            }

            var ser = new YAXSerializer(typeof(Results));
            try
            {
                Results sample = (Results)ser.Deserialize(response);

                foreach (var x in sample.CollectionOfSeries)
                {
                    this.SerieList.Add(new Serie
                    {
                        SerieId = x.SerieId,
                        SerieSlug = x.SerieSlug,
                        SerieName = x.SerieName,
                        SerieOriginalName = x.SerieOriginalName,
                        Author = new BookAuthor
                        {
                            AuthorId = x.Author.AuthorId,
                            AuthorSlug = x.Author.AuthorSlug,
                            Name = x.Author.Name,
                            OriginalName = x.Author.OriginalName,
                            Country = x.Author.Country,
                            Info = x.Author.Country
                        }
                    });
                }

                this.SerieNumber = this.SerieList.Count;
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public void SeriesFilter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            Serie s = e.Item as Serie;
            if (s.SerieName.ToUpper().Contains(FilterText.ToUpper()) || s.Author.Name.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
    }
}
