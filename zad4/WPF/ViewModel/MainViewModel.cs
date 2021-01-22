using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Model;


namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private static MainViewModel _instance;

        private readonly ProductReviewOperations _creditCardService;

        private ObservableCollection<UpdateViewModel> _creditCardList;

        private UpdateViewModel _selectedCreditCard;


        private ICommand _showAddCommand;
        private ICommand _showEditCommand;

        public MainViewModel() : this(new ProductReviewOperations()) { }

        public MainViewModel(ProductReviewOperations creditCardService)
        {
            _creditCardService = creditCardService;
            CreditCardList = GetCreditCards();
        }

        public IWindowResolver WindowResolver { get; set; }

        public ObservableCollection<UpdateViewModel> CreditCardList
        {
            get => GetCreditCards();
            set
            {
                _creditCardList = value;
                OnPropertyChanged("CreditCardList");
            }
        }

        public UpdateViewModel SelectedCreditCard
        {
            get => _selectedCreditCard;
            set
            {
                _selectedCreditCard = value;
                OnPropertyChanged("SelectedCreditCard");
            }
        }


        public Lazy<IOperationWindow> DetailWindow { get; set; }

        public Lazy<IOperationWindow> AddWindow { get; set; }

        public ICommand ShowAddCommand => _showAddCommand ?? (_showAddCommand = new Command(ShowAddDialog));
        public ICommand ShowEditCommand => _showEditCommand ?? (_showEditCommand = new Command(ShowEditDialog));

        public Action CloseWindow { get; set; }

        public static MainViewModel Instance()
        {
            return _instance ?? (_instance = new MainViewModel());
        }

        public ObservableCollection<UpdateViewModel> GetCreditCards()
        {
            if (_creditCardList == null)
            {
                _creditCardList = new ObservableCollection<UpdateViewModel>();
            }

            _creditCardList.Clear();
            foreach (UpdateViewModel card in _creditCardService.GetAllProductReviews().Select(card => new UpdateViewModel(card, _creditCardService)))
            {
                _creditCardList.Add(card);
            }

            return _creditCardList;
        }
        
        private void ShowAddDialog()
        {
            UpdateViewModel card = new UpdateViewModel(new ProductReviewModel(), _creditCardService)
            {
                mode = true
            };

            IOperationWindow dialog = WindowResolver.GetWindow();
            dialog.BindViewModel(card);
            dialog.Show();
            UpdateViewModel.Container.CreditCardList = GetCreditCards();
        }

        private void ShowEditDialog()
        {
            _selectedCreditCard.mode = false;
            if (SelectedCreditCard != null)
            {
                IOperationWindow dialog = WindowResolver.GetWindow();
                dialog.BindViewModel(_selectedCreditCard);
                dialog.Show();
            }
        }


    }
}
