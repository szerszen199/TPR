﻿namespace ViewModel
{
    public interface IOperationWindow
    {
        void BindViewModel<T>(T viewModel);
        void Show();
        event VoidHandler OnClose;
    }

    public delegate void VoidHandler();
}