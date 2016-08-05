using System.Windows;
using DatatehTestTask;

namespace DatatehTestTaskTests
{
    internal class WindowManagerMock : WindowManager
    {
        public override Window ShowWindow(ViewModel viewModel, bool asDialog)
        {
            Subscribe(viewModel);
            ActiveWindows.Add(viewModel, null);
            return null;
        }
    }
}
