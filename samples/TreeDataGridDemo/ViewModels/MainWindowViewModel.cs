namespace TreeDataGridDemo.ViewModels
{
    internal class MainWindowViewModel
    {
        private CountriesPageViewModel? _countries;
        private FilesPageViewModel? _files;
        private WikipediaPageViewModel? _wikipedia;
        private DragDropPageViewModel? _dragDrop;
        private DiffVM? _diffVM;

        public CountriesPageViewModel Countries
        {
            get => _countries ??= new CountriesPageViewModel();
        }

        public FilesPageViewModel Files
        {
            get => _files ??= new FilesPageViewModel();
        }

        public WikipediaPageViewModel Wikipedia
        {
            get => _wikipedia ??= new WikipediaPageViewModel();
        }

        public DragDropPageViewModel DragDrop
        {
            get => _dragDrop ??= new DragDropPageViewModel();
        }
        public DiffVM Diffs
        {
            get => _diffVM ??= new DiffVM();
        }
    }
}
