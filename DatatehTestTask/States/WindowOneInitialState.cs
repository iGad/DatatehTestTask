using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// Первоначальное состояние первого окна
    /// </summary>
    public class WindowOneInitialState : ViewModelState<WindowOneViewModel>
    {
        /// <summary>
        /// Конструктор с моделью
        /// </summary>
        /// <param name="viewModel">Модель</param>
        public WindowOneInitialState(WindowOneViewModel viewModel):base(viewModel)
        {
        }

        /// <summary>
        /// Выполнение действий состояния для переопределения в наследуемых классах
        /// </summary>
        /// <param name="context">Контекст</param>
        protected override void DoGo(IContext context)
        {
            Model.CanExecuteSecondButtonCommand = true;
            context.State = new WindowOneWithActiveButtonState();
        }
    }
}
