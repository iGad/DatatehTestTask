using System.Linq;

namespace DatatehTestTask.States
{
    public class EnterCorrectTextInWindowTwoState : IState
    {
        private readonly WindowTwoViewModel viewModel;
        public EnterCorrectTextInWindowTwoState(WindowTwoViewModel viewModel)
        {
            this.viewModel = viewModel;
            //this.viewModel.UserMessage = "thank you";
            //this.viewModel.CanExecuteButtonThreeCommand = true;
        }

        public void Handle(IContext context)
        {
            this.viewModel.CanExecuteButtonThreeCommand = this.viewModel.EnteredText.Equals("hello");
            if (this.viewModel.CanExecuteButtonThreeCommand)
            {
                this.viewModel.Close();
                context.State = new WindowOneWithActiveButtonState(context.WindowManager.GetActiveViewModels().OfType<WindowOneViewModel>().Single());
                return;
            }
            this.viewModel.UserMessage = "hi";
            context.State = new EnterInvalidTextInWindowTwoState(this.viewModel);
            
        }
    }
}