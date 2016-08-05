using System;
using System.Linq;
using DatatehTestTask;
using DatatehTestTask.States;
using DatatehTestTask.ViewModels;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace DatatehTestTaskTests.States
{
    [TestFixture]
    public class EnterCorrectTextInWindowTwoStateTests
    {
        [Test]
        public void Constructor_WhenViewModelIsNull_ExceptionExpected()
        {
            WindowTwoViewModel viewModel = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Catch<ArgumentNullException>(() => new EnterCorrectTextInWindowTwoState(viewModel));
        }

        [Test]
        public void Handle_WhenContextIsNull_ExceptionExpected()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterCorrectTextInWindowTwoState(viewModel);
            IContext context = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.Catch<ArgumentNullException>(() => state.Handle(context));
        }

        [Test]
        public void Handle_WhenEnteredTextIsInvalid_SetCanExecuteButtonThreeComandToFalse()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterCorrectTextInWindowTwoState(viewModel);
            viewModel.EnteredText = "123";
            var context = viewModel.Context;

            state.Handle(context);

            Assert.IsFalse(viewModel.CanExecuteButtonThreeCommand);
        }

        [Test]
        public void Handle_WhenEnteredTextIsInvalid_SetExpectedStateToContext()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterCorrectTextInWindowTwoState(viewModel);
            viewModel.EnteredText = "123";
            var context = viewModel.Context;

            state.Handle(context);

            Assert.AreEqual(typeof(EnterInvalidTextInWindowTwoState), context.State.GetType());
        }

        [Test]
        public void Handle_WhenEnteredTextIsInvalid_SetExpectedUserMessage()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            viewModel.UserMessage = "123";
            var state = new EnterCorrectTextInWindowTwoState(viewModel);
            viewModel.EnteredText = "123";
            var context = viewModel.Context;

            state.Handle(context);

            Assert.AreEqual(Constants.HiTextToUser, viewModel.UserMessage);
        }

        [Test]
        public void Handle_WhenEnteredTextIsCorrect_RemoveViewModelFromWindowManager()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterCorrectTextInWindowTwoState(viewModel);
            viewModel.EnteredText = Constants.ExpectedUserInput;
            var context = viewModel.Context;

            state.Handle(context);

            Assert.AreEqual(0, context.WindowManager.GetActiveViewModels().Count());
        }
        
        [Test]
        public void Handle_WhenEnteredTextIsCorrect_SetExpectedStateToContext()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var state = new EnterCorrectTextInWindowTwoState(viewModel);
            viewModel.EnteredText = Constants.ExpectedUserInput;
            var context = viewModel.Context;

            state.Handle(context);

            Assert.AreEqual(typeof(WindowOneWithActiveButtonState), context.State.GetType());
        }
    }
}
