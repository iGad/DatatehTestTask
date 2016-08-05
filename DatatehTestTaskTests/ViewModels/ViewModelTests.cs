using DatatehTestTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatatehTestTaskTests.ViewModels
{
    [TestClass]
    public class ViewModelTests
    {
        private class TestViewModel : ViewModel {
            public TestViewModel(IContext context) : base(context)
            {
            }
        }

        [TestMethod]
        public void Close_Always_RaiseCloseEvent()
        {
            var viewModel = new TestViewModel(TestHelper.CreateTestContext());
            bool isRaised = false;
            viewModel.CloseEvent += (sender, args) => isRaised = true;

            viewModel.Close();

            Assert.IsTrue(isRaised);
        }
    }
}
