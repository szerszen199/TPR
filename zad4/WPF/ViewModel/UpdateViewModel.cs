using System;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class UpdateViewModel : ViewModelBase
    {
        private readonly ProductReviewModel productReviewModel;
        private readonly ProductReviewOperations productReviewOperations;

        private ICommand updateCommand;
        private ICommand deleteCommand;

        public UpdateViewModel(ProductReviewModel productReviewModel, ProductReviewOperations productReviewOperations)
        {
            this.productReviewModel = productReviewModel;
            this.productReviewOperations = productReviewOperations;

        }
        public bool mode { get; set; }
        public ICommand UpdateCommand => updateCommand ?? (updateCommand = new Command(Update));
        public ICommand DeleteProductReview => deleteCommand ?? (deleteCommand = new Command(Delete));


        public Action CloseWindow { get; set; }

        public int ProductReviewId
        {
            get => productReviewModel.productReviewID;
            set
            {
                productReviewModel.productReviewID = value;
                OnPropertyChanged("ProductReviewId");
            }
        }

        public int ProductId
        {
            get => productReviewModel.productID;
            set
            {
                productReviewModel.productID = value;
                OnPropertyChanged("ProductId");
            }
        }

        public string ReviewerName
        {
            get => productReviewModel.reviewerName;
            set
            {
                productReviewModel.reviewerName = value;
                OnPropertyChanged("ReviewerName");
            }
        }

        public DateTime ReviewDate
        {
            get => productReviewModel.reviewDate;
            set
            {
                productReviewModel.reviewDate = value;
                OnPropertyChanged("ReviewDate");
            }
        }

        public string EmailAddress
        {
            get => productReviewModel.emailAddress;
            set
            {
                productReviewModel.emailAddress = value;
                OnPropertyChanged("EmailAddress");
            }
        }

        public int Rating
        {
            get => productReviewModel.rating;
            set
            {
                productReviewModel.rating = value;
                OnPropertyChanged("Rating");
            }
        }

        public string Comments
        {
            get => productReviewModel.comments;
            set
            {
                productReviewModel.comments = value;
                OnPropertyChanged("Comments");
            }
        }

        public static MainViewModel Container => MainViewModel.Instance();

        private void Update()
        {
            if(mode)
            {
                productReviewOperations.AddProductReview(productReviewModel);
                Container.ProductReviewList = Container.GetProductReviews();
            }
            else
                productReviewOperations.UpdateProductReview(ProductReviewId, productReviewModel);

            CloseWindow?.Invoke();
        }


        private void Delete()
        {
            try
            {
                productReviewOperations.RemoveProductReview(ProductReviewId);
            }
            catch (Exception)
            {
                
            }

            Container.ProductReviewList = Container.GetProductReviews();
        }

    }
}
