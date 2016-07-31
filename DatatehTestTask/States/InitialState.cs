namespace DatatehTestTask.States
{
    public class InitialState : IState
    {
        public void Handle(IContext context)
        {
            var viewModel = new WindowOneViewModel(context);
            context.WindowManager.ShowWindow(viewModel, false);
            context.State = new WindowOneInitialState(viewModel);
        }
    }
}