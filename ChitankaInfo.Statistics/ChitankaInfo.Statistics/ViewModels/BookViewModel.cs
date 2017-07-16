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
    public class BookViewModel : ViewModelBase
    {
        private int bookNumber;

        private CollectionViewSource filterBooks;

        private string filterText;

        public RelayCommand GetCommand { get; set; }

        private ObservableCollection<Book> books { get; set; }

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

        public ICollectionView FilterBooks => this.filterBooks.View;

        public string FilterText
        {
            get
            {
                return this.filterText;
            }

            set
            {
                this.filterText = value;
                this.filterBooks.View.Refresh();
                this.OnPropertyChanged();
            }
        }

        public int BookNumber
        {
            get
            {
                return this.bookNumber;

            }

            set
            {
                this.bookNumber = value;
                this.OnPropertyChanged();
            }
        }

        public BookViewModel()
        {
            this.GetCommand = new RelayCommand(this.GetBooks);

            this.books = new ObservableCollection<Book>();
            this.filterBooks = new CollectionViewSource{ Source = this.BookList };
            this.filterBooks.Filter += this.BooksFilter;
        }

        private void GetBooks(object obj)
        {
            var url = "http://chitanka.info/books/search.xml?q=all";
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

                this.BookNumber = this.BookList.Count;
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public void BooksFilter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            Book b = e.Item as Book;
            if (b.Title.ToUpper().Contains(FilterText.ToUpper()) || b.Author.Name.ToUpper().Contains(FilterText.ToUpper()))
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
