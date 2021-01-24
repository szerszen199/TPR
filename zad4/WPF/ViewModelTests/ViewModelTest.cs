using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicTests.DataModel;
using Model;
using ViewModel;

namespace ViewModelTests
{
    [TestClass]
    public class ViewModelTest
    {
        private UpdateViewModel updateViewModel;
        private MainViewModel mainViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            ProductReviewOperations service = new ProductReviewOperations(new TestDataModel());
            ProductReviewModel cardModel = new ProductReviewModel
            {
                productReviewID = 3,
                productID = 500,
                reviewerName = "Kate",
                reviewDate = new DateTime(2020, 1, 18),
                emailAddress = "test@test.com",
                rating = 3,
                comments = "Test Comment number 3"
            };
            updateViewModel = new UpdateViewModel(cardModel, service);
            mainViewModel = new MainViewModel(service);
        }

        [TestMethod]
        public void UpdateViewModelCtorTest()
        {
            Assert.IsNotNull(updateViewModel.ProductReviewId);
            Assert.IsNotNull(updateViewModel.ProductId);
            Assert.IsNotNull(updateViewModel.ReviewerName);
            Assert.IsNotNull(updateViewModel.ReviewDate);
            Assert.IsNotNull(updateViewModel.EmailAddress);
            Assert.IsNotNull(updateViewModel.Rating);
            Assert.IsNotNull(updateViewModel.Comments);
        }

        [TestMethod]
        public void MainViewModelCtorTest()
        {
            Assert.IsNotNull(mainViewModel.ProductReviewList);
        }

        [TestMethod]
        public void UpdateViewModelCommandsTest()
        {
            Assert.IsTrue(updateViewModel.UpdateCommand.CanExecute(null));
            Assert.IsTrue(updateViewModel.DeleteProductReview.CanExecute(null));
        }

        [TestMethod]
        public void MainViewModelCommandsTest()
        {
            Assert.IsTrue(mainViewModel.ShowEditCommand.CanExecute(null));
            Assert.IsTrue(mainViewModel.ShowAddCommand.CanExecute(null));
        }
    }
}
