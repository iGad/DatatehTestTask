using System;
using DatatehTestTask;
using DatatehTestTask.States;
using DatatehTestTask.ViewModels;
using NUnit.Framework;

namespace DatatehTestTaskTests.ViewModels
{
    [TestFixture]
    public class WindowOneViewModelTests
    {
        [Test]
        public void Constructor_WhenIContextIsNull_ExceptionExpected()
        {
            IContext context = null;

            Assert.Catch<ArgumentNullException>(() => new WindowOneViewModel(context));
        }

        [Test]
        public void CanExecuteSecondButtonCommand_WhenSetTrue_SetSameValueToCanExecuteInSecondCommand()
        {
            var viewModel = TestHelper.CreateWindowOneViewModel();

            viewModel.CanExecuteSecondButtonCommand = !viewModel.CanExecuteSecondButtonCommand;

            Assert.AreEqual(viewModel.CanExecuteSecondButtonCommand, viewModel.SecondButtonCommand.CanExecute());
        }

        [Test]
        public void ExecuteFirstButtonCommand_WhenContextStateIsNotWOIS_NotChangeContextState()
        {
            var viewModel = TestHelper.CreateWindowOneViewModel();
            var state = viewModel.Context.State;

            viewModel.FirstButtonCommand.Execute(viewModel.Context).Wait();

            Assert.AreEqual(state, viewModel.Context.State);
        }

        [Test]
        public void ExecuteFirstButtonCommand_WhenContextStateIsWOIS_SetExpectedStateToContext()
        {
            var viewModel = TestHelper.CreateWindowOneViewModel();
            viewModel.Context.State = new WindowOneInitialState(viewModel);

            viewModel.FirstButtonCommand.Execute(viewModel.Context).Wait();

            Assert.AreEqual(typeof(WindowOneWithActiveButtonState),viewModel.Context.State.GetType());
        }

        [Test]
        public void ExecuteSecondButtonCommand_ByDefault_ExecuteStateHandle()
        {
            var viewModel = TestHelper.CreateWindowOneViewModel();
            viewModel.CanExecuteSecondButtonCommand = true;
            var state = (IStateSubstitute)viewModel.Context.State;

            viewModel.SecondButtonCommand.Execute().Wait();

            Assert.IsTrue(state.IsHandleCalled);
        }
    }
}
