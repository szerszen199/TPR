using ViewModel;

namespace View.DI
{
    public class ProductReviewUpdateResolver : IWindowResolver
    {
        public IOperationWindow GetWindow()
        {
            return new ProductReviewUpdateWindow();
        }
    }
}
