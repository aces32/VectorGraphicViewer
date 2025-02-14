using Wscad.VectorGraphicViewer.Command;

namespace Wscad.VectorGraphicViewer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public VectorViewModel VectorViewModel { get; }
        private ViewModelBase? _selectedViewModel;

        public MainViewModel(VectorViewModel vectorViewModel)
        {
            VectorViewModel = vectorViewModel;
            SelectedViewModel = VectorViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand SelectViewModelCommand { get; set; }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();

            }
        }

        public async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }

    }
}
