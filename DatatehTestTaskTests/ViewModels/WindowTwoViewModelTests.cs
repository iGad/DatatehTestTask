using System;
using DatatehTestTask;
using DatatehTestTask.ViewModels;
using NUnit.Framework;

namespace DatatehTestTaskTests.ViewModels
{
    [TestFixture]
    public class WindowTwoViewModelTests
    {
        [Test]
        public void Constructor_WhenIContextIsNull_ExceptionExpected()
        {
            IContext context = null;

            Assert.Catch<ArgumentNullException>(() => new WindowTwoViewModel(context));
        }

        [Test]
        public void SetUserMessage_WhenDifferentValue_SetValue()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var expectedValue = viewModel.UserMessage + "1";

            viewModel.UserMessage = expectedValue;

            Assert.AreEqual(expectedValue, viewModel.UserMessage);
        }

        [Test]
        public void SetUserMessage_WhenSameValue_NotRaisePropertyChanged()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            bool isRaised = false;
            viewModel.PropertyChanged += (sender, args) => isRaised = true;

            viewModel.UserMessage = viewModel.UserMessage;

            Assert.IsFalse(isRaised);
        }

        [Test]
        public void SetEnteredText_WhenDifferentValue_SetValue()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            var expectedValue = viewModel.UserMessage + "1";

            viewModel.EnteredText = expectedValue;

            Assert.AreEqual(expectedValue, viewModel.EnteredText);
        }

        [Test]
        public void SetEnteredText_WhenSameValue_NotRaisePropertyChanged()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            bool isRaised = false;
            viewModel.PropertyChanged += (sender, args) => isRaised = true;

            viewModel.EnteredText = viewModel.EnteredText;

            Assert.IsFalse(isRaised);
        }

        [Test]
        public void CanExecuteSecondButtonCommand_WhenChangeValue_SetSameValueToCanExecuteInSecondCommand()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();

            viewModel.CanExecuteButtonThreeCommand = !viewModel.CanExecuteButtonThreeCommand;

            Assert.AreEqual(viewModel.CanExecuteButtonThreeCommand, viewModel.ButtonThreeCommand.CanExecute());
        }

        [Test]
        public void ExecuteSecondButtonCommand_ByDefault_ExecuteStateHandle()
        {
            var viewModel = TestHelper.CreateWindowTwoViewModel();
            viewModel.CanExecuteButtonThreeCommand = true;
            var state = (IStateSubstitute)viewModel.Context.State;

            viewModel.ButtonThreeCommand.Execute().Wait();

            Assert.IsTrue(state.IsHandleCalled);
        }
    }
}
