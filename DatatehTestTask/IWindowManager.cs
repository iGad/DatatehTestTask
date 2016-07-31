using System;
using System.Collections.Generic;
using System.Windows;

namespace DatatehTestTask
{
    public interface IWindowManager
    {
        Window ShowWindow(ViewModel viewModel, bool asDialog);

        void AddPair(Type viewModelType, Type windowType);

        IEnumerable<ViewModel> GetActiveViewModels();
    }
}