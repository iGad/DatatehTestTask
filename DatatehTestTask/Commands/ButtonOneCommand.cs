using DatatehTestTask.States;
using DatatehTestTask.ViewModels;
using Prism.Commands;

namespace DatatehTestTask.Commands
{
    public class ButtonOneCommand : DelegateCommand<IContext>
    {
        public ButtonOneCommand() : base(ExecuteMethod)
        {
        }

        private static void ExecuteMethod(IContext context)
        {
            if (context.State is WindowOneInitialState)
            {
                context.State.Handle(context);
            }
        }
    }
}
