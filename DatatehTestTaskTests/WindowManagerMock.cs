using DatatehTestTask;

namespace DatatehTestTaskTests
{
    internal class WindowManagerMock : WindowManager
    {
        public override void ShowWindow(ViewModel viewModel, bool asDialog)
        {
            Subscribe(viewModel);
            ActiveWindows.Add(viewModel, null);
        }
    }
}
