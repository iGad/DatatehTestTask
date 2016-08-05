using System;
using NUnit.Framework;

namespace DatatehTestTaskTests
{
    [TestFixture]
    public class WindowOneViewModelTests
    {

        [Test]
        public void Constructor_Always_SetCanExecuteSecondButtonToFalse()
        {
            var viewModel = TestHelper.CreateWindowOneViewModel();

            Assert.IsFalse(viewModel.CanExecuteSecondButtonCommand);
        }

    }
}
