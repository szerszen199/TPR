using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Model;


namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private static MainViewModel mainViewModel;

        private readonly ProductReviewOperations productReviewOperations;

        private ObservableCollection<UpdateViewModel> productReviewList;

        private UpdateViewModel selectedProductReview;


        private ICommand showAddCommand;
        private ICommand showEditCommand;

        public MainViewModel() : this(new ProductReviewOperations()) { }

        public MainViewModel(ProductReviewOperations productReviewService)
        {
            productReviewOperations = productReviewService;
            ProductReviewList = GetProductReviews();
        }

        public IWindowResolver WindowResolver { get; set; }

        public ObservableCollection<UpdateViewModel> ProductReviewList
        {
            get => GetProductReviews();
            set
            {
                productReviewList = value;
                OnPropertyChanged("ProductReviewList");
            }
        }

        public UpdateViewModel SelectedProductReview
        {
            get => selectedProductReview;
            set
            {
                selectedProductReview = value;
                OnPropertyChanged("SelectedProductReview");
            }
        }

        public ICommand ShowAddCommand => showAddCommand ?? (showAddCommand = new Command(ShowAddDialog));
        public ICommand ShowEditCommand => showEditCommand ?? (showEditCommand = new Command(ShowEditDialog));

        public Action CloseWindow { get; set; }

        public static MainViewModel Instance()
        {
            return mainViewModel ?? (mainViewModel = new MainViewModel());
        }

        public ObservableCollection<UpdateViewModel> GetProductReviews()
        {
            if (productReviewList == null)
            {
                productReviewList = new ObservableCollection<UpdateViewModel>();
            }

            productReviewList.Clear();
            foreach (UpdateViewModel review in productReviewOperations.GetAllProductReviews().Select(review => new UpdateViewModel(review, productReviewOperations)))
            {
                productReviewList.Add(review);
            }

            return productReviewList;
        }
        
        private void ShowAddDialog()
        {
            UpdateViewModel review = new UpdateViewModel(new ProductReviewModel(), productReviewOperations)
            {
                mode = true
            };

            IOperationWindow dialog = WindowResolver.GetWindow();
            dialog.BindViewModel(review);
            dialog.Show();
            UpdateViewModel.Container.ProductReviewList = GetProductReviews();
        }

        private void ShowEditDialog()
        {
            if (SelectedProductReview != null)
            {
                selectedProductReview.mode = false;
                IOperationWindow dialog = WindowResolver.GetWindow();
                dialog.BindViewModel(selectedProductReview);
                dialog.Show();
            }
        }


    }
}
