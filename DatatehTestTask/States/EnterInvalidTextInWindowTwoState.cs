using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// Состояние при вводе неверного текста в поле ввода второго окна
    /// </summary>
    public class EnterInvalidTextInWindowTwoState : ViewModelState<WindowTwoViewModel>
    {
        /// <summary>
        /// Конструктор с моделью
        /// </summary>
        /// <param name="viewModel">Модель</param>
        public EnterInvalidTextInWindowTwoState(WindowTwoViewModel viewModel):base(viewModel)
        {
        }

        /// <summary>
        /// Выполнение действий состояния
        /// </summary>
        /// <param name="context">Контекст</param>
        protected override void DoHandle(IContext context)
        {
            Model.CanExecuteButtonThreeCommand = Model.EnteredText.Equals(Constants.ExpectedUserInput);
            if (Model.CanExecuteButtonThreeCommand)
            {
                Model.UserMessage = Constants.ThankYouTextToUser;
                context.State = new EnterCorrectTextInWindowTwoState(Model);
            }
        }
    }
}