using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// Состояние, когда введен корректный текст в поле ввода второго окна
    /// </summary>
    public class EnterCorrectTextInWindowTwoState : ViewModelState<WindowTwoViewModel>
    {
        /// <summary>
        /// Конструктор с моделью
        /// </summary>
        /// <param name="viewModel">Модель</param>
        public EnterCorrectTextInWindowTwoState(WindowTwoViewModel viewModel):base(viewModel)
        {
        }


        /// <summary>
        /// Выполнение действий состояния для переопределения в наследуемых классах
        /// </summary>
        /// <param name="context">Контекст</param>
        protected override void DoHandle(IContext context)
        {
            Model.CanExecuteButtonThreeCommand = Model.EnteredText.Equals(Constants.ExpectedUserInput);
            if (Model.CanExecuteButtonThreeCommand)
            {
                Model.Close();
                context.State = new WindowOneWithActiveButtonState();
                return;
            }
            Model.UserMessage = Constants.HiTextToUser;
            context.State = new EnterInvalidTextInWindowTwoState(Model);
        }
    }
}