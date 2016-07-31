namespace DatatehTestTask.States
{
    public class WindowOneWithActiveButtonState : IState
    {
        private readonly WindowOneViewModel viewModel;
        public WindowOneWithActiveButtonState(WindowOneViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Handle(IContext context)
        {
            var windowTwoViewModel = new WindowTwoViewModel(context);
            
            //this.viewModel.CanExecuteSecondButtonCommand = true;
            context.State = new WindowTwoInitialState(windowTwoViewModel);
            context.WindowManager.ShowWindow(windowTwoViewModel, true);
        }
    }
}