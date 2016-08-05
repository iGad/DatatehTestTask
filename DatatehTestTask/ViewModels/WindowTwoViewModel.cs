using Prism.Commands;

namespace DatatehTestTask.ViewModels
{
    /// <summary>
    /// ViewModel для второго окна
    /// </summary>
    public class WindowTwoViewModel : ViewModel
    {
        private string userMessage;
        private string enteredText;
        private bool canExecuteButtonThreeCommand;

        /// <summary>
        /// Конструктор с контекстом
        /// </summary>
        /// <param name="context"></param>
        public WindowTwoViewModel(IContext context):base(context)
        {
            this.userMessage = Constants.HiTextToUser;
            this.enteredText = string.Empty;
            this.canExecuteButtonThreeCommand = true;
            ButtonThreeCommand = new DelegateCommand(ButtonThreeClick, CanExecuteButtonThreeClick);
        }
        
        /// <summary>
        /// Сообщение, показываемое пользователю
        /// </summary>
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

        /// <summary>
        /// Флаг, определяющий возможность выполнения команды третьей кнопки
        /// </summary>
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

        /// <summary>
        /// Вводимый пользователем текст
        /// </summary>
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

        /// <summary>
        /// Команда третьей кнопки
        /// </summary>
        public DelegateCommand ButtonThreeCommand { get; private set; }

        private bool CanExecuteButtonThreeClick()
        {
            return CanExecuteButtonThreeCommand;
        }

        private void ButtonThreeClick()
        {
            Context.State.Handle(Context);
        }
    }
}
