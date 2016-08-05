using DatatehTestTask.Commands;
using Prism.Commands;

namespace DatatehTestTask.ViewModels
{
    /// <summary>
    /// ViewModel для первого окна
    /// </summary>
    public class WindowOneViewModel : ViewModel
    {
        private bool canExecuteSecondButtonCommand;

        /// <summary>
        /// Конструктор с контекстом
        /// </summary>
        /// <param name="context">Контекст</param>
        public WindowOneViewModel(IContext context):base(context)
        {
            FirstButtonCommand = new ButtonOneCommand();
            SecondButtonCommand = new DelegateCommand(SecondButtonClick, () => CanExecuteSecondButtonCommand);
        }
       
        /// <summary>
        /// Флаг, определяющий можно ли выполнить команду второй кнопки
        /// </summary>
        public bool CanExecuteSecondButtonCommand
        {
            get { return this.canExecuteSecondButtonCommand; }
            set
            {
                this.canExecuteSecondButtonCommand = value;
                SecondButtonCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Команда первой кнопки
        /// </summary>
        public DelegateCommand<IContext> FirstButtonCommand { get; private set; }

        /// <summary>
        /// Команда второй кнопки
        /// </summary>
        public DelegateCommand SecondButtonCommand { get; private set; }

        private void SecondButtonClick()
        {
            Context.State.Handle(Context);
        }
    }
}
