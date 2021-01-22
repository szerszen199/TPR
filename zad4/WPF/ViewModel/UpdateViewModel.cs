using System;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class UpdateViewModel : ViewModelBase
    {
        private readonly ProductReviewModel _creditCardModel;
        private readonly ProductReviewOperations _creditCardService;
        //private ProductReviewModel _originalCardModel;

        private ICommand _updateCommand;
        private ICommand _deleteCommand;

        public UpdateViewModel(ProductReviewModel creditCardModel, ProductReviewOperations creditCardService)
        {
            _creditCardModel = creditCardModel;
            //_originalCardModel = creditCardModel.Clone();
            _creditCardService = creditCardService;

        }
        public bool mode { get; set; }
        public ICommand UpdateCommand => _updateCommand ?? (_updateCommand = new Command(Update));
        public ICommand DeleteProductReview => _deleteCommand ?? (_deleteCommand = new Command(Delete));


        public Action CloseWindow { get; set; }

        public int ProductReviewId
        {
            get => _creditCardModel.productReviewID;
            set
            {
                _creditCardModel.productReviewID = value;
                OnPropertyChanged("ProductReviewId");
            }
        }

        public int ProductId
        {
            get => _creditCardModel.productID;
            set
            {
                _creditCardModel.productID = value;
                OnPropertyChanged("ProductId");
            }
        }

        public string ReviewerName
        {
            get => _creditCardModel.reviewerName;
            set
            {
                _creditCardModel.reviewerName = value;
                OnPropertyChanged("ReviewerName");
            }
        }

        public DateTime ReviewDate
        {
            get => _creditCardModel.reviewDate;
            set
            {
                _creditCardModel.reviewDate = value;
                OnPropertyChanged("ReviewDate");
            }
        }

        public string EmailAddress
        {
            get => _creditCardModel.emailAddress;
            set
            {
                _creditCardModel.emailAddress = value;
                OnPropertyChanged("EmailAddress");
            }
        }

        public int Rating
        {
            get => _creditCardModel.rating;
            set
            {
                _creditCardModel.rating = value;
                OnPropertyChanged("Rating");
            }
        }

        public string Comments
        {
            get => _creditCardModel.comments;
            set
            {
                _creditCardModel.comments = value;
                OnPropertyChanged("Comments");
            }
        }

        public static MainViewModel Container => MainViewModel.Instance();

        private void Update()
        {
            if(mode)
            {
                _creditCardService.AddProductReview(_creditCardModel);
                Container.CreditCardList = Container.GetCreditCards();
            }
            else
                _creditCardService.UpdateProductReview(ProductReviewId, _creditCardModel);
            //_originalCardModel = _creditCardModel.Clone();

            CloseWindow?.Invoke();
        }


        private void Delete()
        {
            try
            {
                _creditCardService.RemoveProductReview(ProductReviewId);
            }
            catch (Exception)
            {
                
            }

            Container.CreditCardList = Container.GetCreditCards();
        }

    }
}
