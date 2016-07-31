using System.Linq;

namespace DatatehTestTask.States
{
    public class WindowTwoInitialState : IState
    {
        private readonly WindowTwoViewModel viewModel;
        public WindowTwoInitialState(WindowTwoViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.viewModel.UserMessage = "hi";
            this.viewModel.CanExecuteButtonThreeCommand = true;
        }

        public void Handle(IContext context)
        {
           // if (!this.viewModel.EnteredText.Equals(string.Empty))
            {
                this.viewModel.CanExecuteButtonThreeCommand = false;
                context.State = new EnterInvalidTextInWindowTwoState(this.viewModel);
                return;
            }
           // context.State = new WindowOneWithActiveButtonState(context.WindowManager.GetActiveViewModels().OfType<WindowOneViewModel>().Single());
           // this.viewModel.Close();
        }
    }
}