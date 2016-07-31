using Prism.Commands;

namespace DatatehTestTask
{
    public class WindowOneViewModel : ViewModel
    {
        private readonly IWindowManager windowManager;
        private bool canExecuteSecondButtonCommand;

        public WindowOneViewModel(IContext context):base(context)
        {
            this.windowManager = context.WindowManager;
            FirstButtonCommand = new DelegateCommand(FirstButtonClick);
            SecondButtonCommand = new DelegateCommand(SecondButtonClick, CanSecondButtonClick);
        }

        private bool CanSecondButtonClick()
        {
            return CanExecuteSecondButtonCommand;
        }

        private void SecondButtonClick()
        {
            Context.State.Handle(Context);
            //var model = new WindowTwoViewModel(Context);
            //this.windowManager.ShowWindow(model);
        }

        private void FirstButtonClick()
        {
            Context.State.Handle(Context);
        }

        public bool CanExecuteSecondButtonCommand
        {
            get { return this.canExecuteSecondButtonCommand; }
            set
            {
                this.canExecuteSecondButtonCommand = value;
                SecondButtonCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand FirstButtonCommand { get; private set; }

        public DelegateCommand SecondButtonCommand { get; private set; }
    }
}
