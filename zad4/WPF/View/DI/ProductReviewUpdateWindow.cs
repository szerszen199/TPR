using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace View.DI
{
    public class ProductReviewUpdateWindow : IOperationWindow
    {
        private readonly UpdateWindow view;

        public ProductReviewUpdateWindow()
        {
            this.view = new UpdateWindow();
        }

        public event VoidHandler OnClose;

        public void BindViewModel<T>(T viewModel)
        {
            view.DataContext = viewModel;
        }

        public void Show()
        {
            view.Show();
        }

    }
}