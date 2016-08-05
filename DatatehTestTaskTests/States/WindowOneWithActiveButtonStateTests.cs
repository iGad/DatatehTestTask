using System;
using System.Linq;
using DatatehTestTask;
using DatatehTestTask.States;
using DatatehTestTask.ViewModels;
using NUnit.Framework;

namespace DatatehTestTaskTests.States
{
    [TestFixture]
    public class WindowOneWithActiveButtonStateTests
    {
        [Test]
        public void Handle_WhenContextIsNull_ExceptionExpected()
        {
            var state = new WindowOneWithActiveButtonState();
            IContext context = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.Catch<ArgumentNullException>(() => state.Go(context));
        }

        [Test]
        public void Handle_WhenContextIsCorrect_CreateViewModel()
        {
            var state = new WindowOneWithActiveButtonState();
            var context = TestHelper.CreateTestContext();

            state.Go(context);

            Assert.AreEqual(typeof(WindowTwoViewModel), context.WindowManager.GetActiveViewModels().Last().GetType());
        }

        [Test]
        public void Handle_WhenContextIsCorrect_SetExpectedStateToContext()
        {
            var state = new WindowOneWithActiveButtonState();
            var context = TestHelper.CreateTestContext();

            state.Go(context);

            Assert.AreEqual(typeof(WindowTwoInitialState), context.State.GetType());
        }
    }
}
