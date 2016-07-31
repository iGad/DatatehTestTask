﻿using System.Linq;
using System.Windows;
using DatatehTestTask;
using DatatehTestTask.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatatehTestTaskTests
{
    [TestClass]
    public class IntegratedTests
    {
        private class WindowManagerMock : WindowManager
        {
            public override Window ShowWindow(ViewModel viewModel, bool asDialog)
            {
                Subscribe(viewModel);
                ActiveWindows.Add(viewModel, null);
                return null;
            }
        }

        [TestMethod]
        public void FullScenario()
        {
            IContext context = new StateMachine(new InitialState(), new WindowManagerMock());
            context.State.Handle(context);
            Assert.AreEqual(typeof(WindowOneInitialState), context.State.GetType());
            Assert.AreEqual(1, context.WindowManager.GetActiveViewModels().Count());

            var firstViewModel = (WindowOneViewModel)context.WindowManager.GetActiveViewModels().First();
            firstViewModel.FirstButtonCommand.Execute().Wait();
            Assert.AreEqual(typeof(WindowOneWithActiveButtonState), context.State.GetType());
            Assert.IsTrue(firstViewModel.SecondButtonCommand.CanExecute());

            firstViewModel.SecondButtonCommand.Execute().Wait();
            Assert.AreEqual(typeof(WindowTwoInitialState), context.State.GetType());
            Assert.AreEqual(2, context.WindowManager.GetActiveViewModels().Count());

            var secondViewModel = context.WindowManager.GetActiveViewModels().OfType<WindowTwoViewModel>().First();
            Assert.AreEqual("hi", secondViewModel.UserMessage);
            Assert.IsTrue(secondViewModel.ButtonThreeCommand.CanExecute());
            secondViewModel.EnteredText = " ";
            Assert.AreEqual(typeof(EnterInvalidTextInWindowTwoState), context.State.GetType());
            Assert.IsFalse(secondViewModel.ButtonThreeCommand.CanExecute());

            secondViewModel.EnteredText = "hello";
            Assert.AreEqual(typeof(EnterCorrectTextInWindowTwoState), context.State.GetType());
            Assert.IsTrue(secondViewModel.ButtonThreeCommand.CanExecute());

            secondViewModel.EnteredText = "hello1";
            Assert.AreEqual(typeof(EnterInvalidTextInWindowTwoState), context.State.GetType());
            Assert.IsFalse(secondViewModel.ButtonThreeCommand.CanExecute());

            secondViewModel.EnteredText = "hello";
            Assert.AreEqual(typeof(EnterCorrectTextInWindowTwoState), context.State.GetType());
            Assert.IsTrue(secondViewModel.ButtonThreeCommand.CanExecute());

            secondViewModel.ButtonThreeCommand.Execute().Wait();
            Assert.AreEqual(typeof(WindowOneWithActiveButtonState), context.State.GetType());
            Assert.AreEqual(1, context.WindowManager.GetActiveViewModels().Count());
        }

        [TestMethod]
        public void PressButtonThreeWithoutEnterText()
        {
            IContext context = new StateMachine(new InitialState(), new WindowManagerMock());
            context.State.Handle(context);
            Assert.AreEqual(typeof(WindowOneInitialState), context.State.GetType());
            Assert.AreEqual(1, context.WindowManager.GetActiveViewModels().Count());

            var firstViewModel = (WindowOneViewModel)context.WindowManager.GetActiveViewModels().First();
            firstViewModel.FirstButtonCommand.Execute().Wait();
            Assert.AreEqual(typeof(WindowOneWithActiveButtonState), context.State.GetType());
            Assert.IsTrue(firstViewModel.SecondButtonCommand.CanExecute());

            firstViewModel.SecondButtonCommand.Execute().Wait();
            Assert.AreEqual(typeof(WindowTwoInitialState), context.State.GetType());
            Assert.AreEqual(2, context.WindowManager.GetActiveViewModels().Count());

            var secondViewModel = context.WindowManager.GetActiveViewModels().OfType<WindowTwoViewModel>().First();
            Assert.AreEqual("hi", secondViewModel.UserMessage);
            Assert.IsTrue(secondViewModel.ButtonThreeCommand.CanExecute());

            secondViewModel.ButtonThreeCommand.Execute().Wait();
            Assert.AreEqual(typeof(WindowOneWithActiveButtonState), context.State.GetType());
            Assert.AreEqual(1, context.WindowManager.GetActiveViewModels().Count());
        }
    }
}