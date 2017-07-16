using System.IO;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace ChitankaInfo.Statistics.ViewModels
{
    public class ReaderViewModel : ViewModelBase
    {
        private string bookContent;

        public RelayCommand BrowseCommand { get; set; }

        public ReaderViewModel()
        {
            this.BrowseCommand = new RelayCommand(this.OpenBook);
        }

        public string BookContent
        {
            get
            {
                return this.bookContent;
            }

            set
            {
                this.bookContent = value;
                this.OnPropertyChanged();
            }
        }

        private void OpenBook(object o)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "EPUB files (*.epub)|*.epub|Text files (*.txt)|*.txt"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                this.BookContent = File.ReadAllText(openFileDialog.FileName);
            }
        }
    }
}
