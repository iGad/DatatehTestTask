using System.Windows;
using DatatehTestTask.States;

namespace DatatehTestTask
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnAppStartup(object sender, StartupEventArgs startupEventArgs)
        {
            var windowManager = new WindowManager();
            windowManager.AddPair(typeof(WindowOneViewModel), typeof(WindowOne));
            windowManager.AddPair(typeof(WindowTwoViewModel), typeof(WindowTwo));
            var stateMachine = new StateMachine(new InitialState(), windowManager);
            stateMachine.State.Handle(stateMachine);
        }
    }
}
