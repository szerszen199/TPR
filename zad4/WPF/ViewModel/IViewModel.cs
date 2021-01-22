using System;

namespace ViewModel
{
    public interface IViewModel
    {
        Action CloseWindow { get; set; }
    }
}