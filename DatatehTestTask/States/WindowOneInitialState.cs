namespace DatatehTestTask.States
{
    public class WindowOneInitialState : IState
    {
        private readonly WindowOneViewModel viewModel;
        public WindowOneInitialState(WindowOneViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Handle(IContext context)
        {
            this.viewModel.CanExecuteSecondButtonCommand = true;
            context.State = new WindowOneWithActiveButtonState(this.viewModel);
        }
    }
}
