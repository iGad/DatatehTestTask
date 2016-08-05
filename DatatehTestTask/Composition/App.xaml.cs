using System.Windows;
using DatatehTestTask.States;
using DatatehTestTask.ViewModels;

namespace DatatehTestTask.Composition
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Точка компоновки, создаем реализации менеджера окон, начального состояния
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="startupEventArgs"></param>
        private void OnAppStartup(object sender, StartupEventArgs startupEventArgs)
        {
            var windowManager = new WindowManager();
            windowManager.AddPair(typeof(WindowOneViewModel), typeof(Views.WindowOne));
            windowManager.AddPair(typeof(WindowTwoViewModel), typeof(Views.WindowTwo));
            var stateMachine = new Context(new InitialState(), windowManager);
            stateMachine.State.Go(stateMachine);
        }
    }
}
