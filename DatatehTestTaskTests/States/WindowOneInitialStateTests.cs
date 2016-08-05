using System;
using DatatehTestTask;
using DatatehTestTask.States;
using DatatehTestTask.ViewModels;
using NUnit.Framework;

namespace DatatehTestTaskTests.States
{
    [TestFixture]
    public class WindowOneInitialStateTests
    {
        [Test]
        public void Constructor_WhenViewModelIsNull_ExceptionExpected()
        {
            WindowOneViewModel viewModel = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Catch<ArgumentNullException>(() => new WindowOneInitialState(viewModel));
        }

        [Test]
        public void Handle_WhenContextIsNull_ExceptionExpected()
        {
            var viewModel = TestHelper.CreateWindowOneViewModel();
            var state = new WindowOneInitialState(viewModel);
            IContext context = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.Catch<ArgumentNullException>(() => state.Handle(context));
        }

        [Test]
        public void Handle_WhenContextIsCorrect_SetCanExecuteSecondButtonToTrue()
        {
            var viewModel = TestHelper.CreateWindowOneViewModel();
            var state = new WindowOneInitialState(viewModel);
            var context = viewModel.Context;

            state.Handle(context);

            Assert.IsTrue(viewModel.CanExecuteSecondButtonCommand);
        }

        [Test]
        public void Handle_WhenContextIsCorrect_SetExpectedStateToContext()
        {
            var viewModel = TestHelper.CreateWindowOneViewModel();
            var state = new WindowOneInitialState(viewModel);
            var context = viewModel.Context;

            state.Handle(context);

            Assert.AreEqual(typeof(WindowOneWithActiveButtonState), context.State.GetType());
        }
    }
}
