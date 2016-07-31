using Prism.Commands;

namespace DatatehTestTask
{
    public class WindowTwoViewModel : ViewModel
    {
        private string userMessage;
        private string enteredText;
        private readonly IContext context;
        private bool canExecuteButtonThreeCommand;

        public WindowTwoViewModel(IContext context):base(context)
        {
            this.context = context;
            this.userMessage = string.Empty;
            this.enteredText = string.Empty;
            ButtonThreeCommand = new DelegateCommand(ButtonThreeClick, CanExecuteButtonThreeClick);
        }

        private bool CanExecuteButtonThreeClick()
        {
            return CanExecuteButtonThreeCommand;
        }

        private void ButtonThreeClick()
        {
            Context.State.Handle(Context);
        }

        public string UserMessage
        {
            get { return this.userMessage; }
            set
            {
                if (!UserMessage.Equals(value))
                {
                    this.userMessage = value;
                    OnPropertyChanged(() => UserMessage);
                }
            }
        }

        public bool CanExecuteButtonThreeCommand
        {
            get { return this.canExecuteButtonThreeCommand; }
            set
            {
                if (CanExecuteButtonThreeCommand != value)
                {
                    this.canExecuteButtonThreeCommand = value;
                    ButtonThreeCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string EnteredText
        {
            get { return this.enteredText; }
            set
            {
                if (!EnteredText.Equals(value))
                {
                    this.enteredText = value;
                    Context.State.Handle(Context);
                    OnPropertyChanged(() => EnteredText);
                }
            }
        }

        public DelegateCommand ButtonThreeCommand { get; private set; }
    }
}
