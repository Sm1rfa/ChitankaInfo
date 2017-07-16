using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using ChitankaInfo.Statistics.Models;
using YAXLib;

namespace ChitankaInfo.Statistics.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private string personName;
        private string bookName;
        private ObservableCollection<Person> persons;
        private ObservableCollection<Book> books;

        public RelayCommand SearchBooksCommand { get; set; }
        public RelayCommand SearchPersonsCommand { get; set; }

        public SearchViewModel()
        {
            this.SearchPersonsCommand = new RelayCommand(this.SearchPersons);
            this.SearchBooksCommand = new RelayCommand(this.SearchBooks);
        }

        #region Public properties
        public string PersonName
        {
            get
            {
                return this.personName;
            }

            set
            {
                this.personName = value;
                this.OnPropertyChanged();
            }
        }

        public string BookName
        {
            get
            {
                return this.bookName;
            }

            set
            {
                this.bookName = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> PersonList
        {
            get
            {
                return this.persons;
            }

            set
            {
                this.persons = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<Book> BookList
        {
            get
            {
                return this.books;
            }

            set
            {
                this.books = value;
                this.OnPropertyChanged();
            }
        }
        #endregion

        private void SearchPersons(object o)
        {
            var url = "https://chitanka.info/persons/search.xml?q=" + this.PersonName + "&by=name";
            var response = string.Empty;
            this.PersonList = new ObservableCollection<Person>();

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
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        private void SearchBooks(object o)
        {
            var url = "https://chitanka.info/books/search.xml?q=" + this.BookName + "&by=title";
            var response = string.Empty;
            this.BookList = new ObservableCollection<Book>();

            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                response = client.DownloadString(url);
            }

            var ser = new YAXSerializer(typeof(Results));
            try
            {
                Results sample = (Results)ser.Deserialize(response);

                foreach (var x in sample.CollectionOfBooks)
                {
                    this.BookList.Add(new Book
                    {
                        BookId = x.BookId,
                        Slug = x.Slug,
                        Title = x.Title,
                        SubTitle = x.SubTitle,
                        TitleExtra = x.TitleExtra,
                        OriginalTitle = x.OriginalTitle,
                        BookLanguage = x.BookLanguage,
                        OriginalLanguage = x.OriginalLanguage,
                        PublishedYear = x.PublishedYear,
                        BookType = x.BookType,
                        Author = new BookAuthor
                        {
                            AuthorId = x.Author.AuthorId,
                            AuthorSlug = x.Author.AuthorSlug,
                            Name = x.Author.Name,
                            OriginalName = x.Author.OriginalName,
                            Country = x.Author.Country,
                            Info = x.Author.Country
                        },
                        //Sequence = new Sequence
                        //{
                        //    SequenceId = x.Sequence.SequenceId,
                        //    SequenceSlug = x.Sequence.SequenceSlug,
                        //    SequenceName = x.Sequence.SequenceName,
                        //    PublisherName = x.Sequence.PublisherName
                        //},
                        Category = new Category
                        {
                            CategoryId = x.Category.CategoryId,
                            CategorySlug = x.Category.CategorySlug,
                            CategoryName = x.Category.CategoryName,
                            NumberOfBooks = x.Category.NumberOfBooks
                        },
                        HasAnnotation = x.HasAnnotation,
                        HasCover = x.HasCover,
                        RemovedNotice = x.RemovedNotice,
                        CreatedAt = x.CreatedAt
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }
    }
}
