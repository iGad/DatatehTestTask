using System;
using System.Linq;
using DatatehTestTask;
using DatatehTestTask.States;
using DatatehTestTask.ViewModels;
using NUnit.Framework;

namespace DatatehTestTaskTests.States
{
    [TestFixture]
    public class WindowTwoInitialStateTests
    {
        [Test]
        public void Constructor_WhenViewModelIsNull_ExceptionExpected()
        {
            WindowTwoViewModel viewModel = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Catch<ArgumentNullException>(() => new WindowTwoInitialState(viewModel));
        }

        [Test]
        public void Handle_WhenContextIsNull_ExceptionExpected()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new WindowTwoInitialState(viewModel);
            IContext context = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.Catch<ArgumentNullException>(() => state.Go(context));
        }

        [Test]
        public void Handle_WhenEnteredTextIsInvalid_SetCanExecuteButtonThreeComandToFalse()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new WindowTwoInitialState(viewModel);
            viewModel.EnteredText = "123";
            var context = viewModel.Context;

            state.Go(context);

            Assert.IsFalse(viewModel.CanExecuteButtonThreeCommand);
        }

        [Test]
        public void Handle_WhenEnteredTextIsInvalid_SetExpectedStateToContext()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new WindowTwoInitialState(viewModel);
            viewModel.EnteredText = "123";
            var context = viewModel.Context;

            state.Go(context);

            Assert.AreEqual(typeof(EnterInvalidTextInWindowTwoState), context.State.GetType());
        }

        [Test]
        public void Handle_WhenEnteredTextIsEmpty_RemoveViewModelFromWindowManager()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new WindowTwoInitialState(viewModel);
            var context = viewModel.Context;

            state.Go(context);

            Assert.AreEqual(0, context.WindowManager.GetActiveViewModels().Count());
        }

        [Test]
        public void Handle_WhenEnteredTextIsEmpty_SetExpectedStateToContext()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new WindowTwoInitialState(viewModel);
            var context = viewModel.Context;

            state.Go(context);

            Assert.AreEqual(typeof(WindowOneWithActiveButtonState), context.State.GetType());
        }

        //[Test]
        //public void Handle_WhenEnteredTextIsEmpty_SetCanExecuteButtonThreeComandToTrue()
        //{
        //    var viewModel = TestHelper.CreateWindowTwoViewModel();
        //    var state = new WindowTwoInitialState(viewModel);
        //    viewModel.EnteredText = Constants.ExpectedUserInput;
        //    var context = viewModel.Context;

        //    state.Go(context);

        //    Assert.IsTrue(viewModel.CanExecuteButtonThreeCommand);
        //}

        //[Test]
        //public void Handle_WhenEnteredTextIsEmpty_SetExpectedStateToContext()
        //{
        //    var viewModel = TestHelper.CreateWindowTwoViewModel();
        //    var state = new WindowTwoInitialState(viewModel);
        //    viewModel.EnteredText = Constants.ExpectedUserInput;
        //    var context = viewModel.Context;

        //    state.Go(context);

        //    Assert.AreEqual(typeof(EnterCorrectTextInWindowTwoState), context.State.GetType());
        //}
    }
}
