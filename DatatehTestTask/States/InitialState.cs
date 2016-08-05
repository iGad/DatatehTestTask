using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    public class InitialState : StateBase
    {
        protected override void DoHandle(IContext context)
        {
            var viewModel = new WindowOneViewModel(context);
            context.WindowManager.ShowWindow(viewModel, false);
            context.State = new WindowOneInitialState(viewModel);
        }
    }
}