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
    public class PersonViewModel : ViewModelBase
    {
        private int personsNumber;

        private ObservableCollection<Person> personList;

        private CollectionViewSource filterPersons;

        private string filterText;

        public RelayCommand GetPersonsCommand { get; set; }

        public PersonViewModel()
        {
            this.GetPersonsCommand = new RelayCommand(this.LoadPersons);

            this.personList = new ObservableCollection<Person>();
            this.filterPersons = new CollectionViewSource{ Source = this.PersonList };
            this.filterPersons.Filter += PersonFilter;
        }

        public ObservableCollection<Person> PersonList
        {
            get
            {
                return this.personList;
                
            }

            set
            {
                this.personList = value;
                this.OnPropertyChanged();
            }
        }

        public ICollectionView FilterPersons => this.filterPersons.View;

        public int PersonNumber
        {
            get
            {
                return this.personsNumber;
                
            }

            set
            {
                this.personsNumber = value;
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
                this.filterPersons.View.Refresh();
                this.OnPropertyChanged();
            }
        }

        public void LoadPersons(object o)
        {
            var url = "https://chitanka.info/persons/search.xml?q=all";
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

                foreach (var x in sample.CollectionOfPersons)
                {
                    this.PersonList.Add(new Person
                    {
                        AuthorId = x.AuthorId,
                        AuthorSlug = x.AuthorSlug,
                        Name = x.Name,
                        OriginalName = x.OriginalName,
                        Country = x.Country,
                        Info = x.Info
                    });
                }

                this.PersonNumber = this.PersonList.Count;
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public void PersonFilter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            Person p = e.Item as Person;
            if (p.Name.ToUpper().Contains(this.FilterText.ToUpper()) || p.Country.ToUpper().Contains(this.FilterText.ToUpper()))
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
