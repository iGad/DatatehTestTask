namespace DatatehTestTask.States
{
    public class EnterInvalidTextInWindowTwoState : IState
    {
        private readonly WindowTwoViewModel viewModel;
        public EnterInvalidTextInWindowTwoState(WindowTwoViewModel viewModel)
        {
            this.viewModel = viewModel;
            //this.viewModel.UserMessage = "hi";
            //this.viewModel.CanExecuteButtonThreeCommand = false;
            
        }

        public void Handle(IContext context)
        {
            this.viewModel.CanExecuteButtonThreeCommand = this.viewModel.EnteredText.Equals("hello");
            if (this.viewModel.CanExecuteButtonThreeCommand)
            {
                this.viewModel.UserMessage = "thank you";
                context.State = new EnterCorrectTextInWindowTwoState(this.viewModel);
            }
        }
    }
}