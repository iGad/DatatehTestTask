using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// Первоначальное состояние второго окна
    /// </summary>
    public class WindowTwoInitialState : ViewModelState<WindowTwoViewModel>
    {
        /// <summary>
        /// Конструктор с моделью
        /// </summary>
        /// <param name="viewModel">Модель</param>
        public WindowTwoInitialState(WindowTwoViewModel viewModel):base(viewModel)
        {
        }

        /// <summary>
        /// Выполнение действий состояния для переопределения в наследуемых классах
        /// </summary>
        /// <param name="context">Контекст</param>
        protected override void DoGo(IContext context)
        {
            if (!Model.EnteredText.Equals(string.Empty))
            {
                Model.CanExecuteButtonThreeCommand = false;
                context.State = new EnterInvalidTextInWindowTwoState(Model);
                return;
            }
            context.State = new WindowOneWithActiveButtonState();
            Model.Close();
        }
    }
}