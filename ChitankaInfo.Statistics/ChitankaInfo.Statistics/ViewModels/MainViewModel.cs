namespace ChitankaInfo.Statistics.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool isAboutClosed;

        private int selectedTabIndex;

        public RelayCommand AboutCommand { get; set; }

        public BookViewModel BookViewModel { get; set; }

        public TextViewModel TextViewModel { get; set; }

        public PersonViewModel PersonViewModel { get; set; }

        public SerieViewModel SerieViewModel { get; set; }

        public SearchViewModel SearchViewModel { get; set; }

        public ReaderViewModel ReaderViewModel { get; set; }


        public MainViewModel()
        {
            this.BookViewModel = new BookViewModel();
            this.TextViewModel = new TextViewModel();
            this.PersonViewModel = new PersonViewModel();
            this.SerieViewModel = new SerieViewModel();
            this.SearchViewModel = new SearchViewModel();
            this.ReaderViewModel = new ReaderViewModel();

            this.AboutCommand = new RelayCommand(this.OnAboutExecuted);
        }

        public bool IsAboutClosed
        {
            get
            {
                return this.isAboutClosed;

            }

            set
            {
                this.isAboutClosed = value;
                this.OnPropertyChanged();
            }
        }

        public int SelectedTabIndex
        {
            get
            {
                return this.selectedTabIndex;
            }

            set
            {
                if (value == this.selectedTabIndex)
                {
                    return;
                }

                this.selectedTabIndex = value;
                this.OnPropertyChanged();
            }
        }

        private void OnAboutExecuted(object obj)
        {
            this.IsAboutClosed = true;
        }
    }
}
