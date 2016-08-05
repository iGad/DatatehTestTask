using System;
using DatatehTestTask;
using DatatehTestTask.States;
using DatatehTestTask.ViewModels;
using NUnit.Framework;

namespace DatatehTestTaskTests.States
{
    [TestFixture]
    public class EnterInvalidTextInWindowTwoStateTests
    {
        [Test]
        public void Constructor_WhenViewModelIsNull_ExceptionExpected()
        {
            WindowTwoViewModel viewModel = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Catch<ArgumentNullException>(() => new EnterInvalidTextInWindowTwoState(viewModel));
        }

        [Test]
        public void Handle_WhenContextIsNull_ExceptionExpected()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterInvalidTextInWindowTwoState(viewModel);
            IContext context = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.Catch<ArgumentNullException>(() => state.Handle(context));
        }

        [Test]
        public void Handle_WhenEnteredTextIsInvalid_SetCanExecuteButtonThreeComandToFalse()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterInvalidTextInWindowTwoState(viewModel);
            viewModel.EnteredText = "123";
            var context = viewModel.Context;

            state.Handle(context);

            Assert.IsFalse(viewModel.CanExecuteButtonThreeCommand);
        }

        [Test]
        public void Handle_WhenEnteredTextIsInvalid_NotChangeCurrentState()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterInvalidTextInWindowTwoState(viewModel);
            viewModel.EnteredText = "123";
            var context = viewModel.Context;
            var expectedState = context.State;

            state.Handle(context);

            Assert.AreEqual(expectedState, context.State);
        }

        [Test]
        public void Handle_WhenEnteredTextIsCorrect_SetCanExecuteButtonThreeComandToTrue()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterInvalidTextInWindowTwoState(viewModel);
            viewModel.EnteredText = Constants.ExpectedUserInput;
            var context = viewModel.Context;

            state.Handle(context);

            Assert.IsTrue(viewModel.CanExecuteButtonThreeCommand);
        }

        [Test]
        public void Handle_WhenEnteredTextIsCorrect_SetExpectedTextToUserMessage()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterInvalidTextInWindowTwoState(viewModel);
            viewModel.EnteredText = Constants.ExpectedUserInput;
            var context = viewModel.Context;

            state.Handle(context);

            Assert.AreEqual(Constants.ThankYouTextToUser, viewModel.UserMessage);
        }

        [Test]
        public void Handle_WhenEnteredTextIsCorrect_SetExpectedStateToContext()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterInvalidTextInWindowTwoState(viewModel);
            viewModel.EnteredText = Constants.ExpectedUserInput;
            var context = viewModel.Context;

            state.Handle(context);

            Assert.AreEqual(typeof(EnterCorrectTextInWindowTwoState), context.State.GetType());
        }
    }
}
