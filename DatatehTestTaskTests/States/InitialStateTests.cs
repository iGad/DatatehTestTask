using System;
using System.Linq;
using DatatehTestTask;
using DatatehTestTask.States;
using DatatehTestTask.ViewModels;
using NUnit.Framework;

namespace DatatehTestTaskTests.States
{
    [TestFixture]
    public class InitialStateTests
    {
        [Test]
        public void Handle_WhenContextIsNull_ExceptionExpected()
        {
            var state =  new InitialState();
            IContext context = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.Catch<ArgumentNullException>(() => state.Go(context));
        }

        [Test]
        public void Handle_WhenContextIsCorrect_CreateViewModel()
        {
            var state = new InitialState();
            var context = TestHelper.CreateTestContext();

            state.Go(context);

            Assert.AreEqual(typeof(WindowOneViewModel), context.WindowManager.GetActiveViewModels().First().GetType());
        }

        [Test]
        public void Handle_WhenContextIsCorrect_SetExpectedStateToContext()
        {
            var state = new InitialState();
            var context = TestHelper.CreateTestContext();

            state.Go(context);

            Assert.AreEqual(typeof(WindowOneInitialState), context.State.GetType());
        }
    }
}
