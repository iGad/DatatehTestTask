using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// Первоначальное состояние первого окна
    /// </summary>
    public class WindowOneInitialState : ViewModelState<WindowOneViewModel>
    {
        public WindowOneInitialState(WindowOneViewModel viewModel):base(viewModel)
        {
        }

        /// <summary>
        /// Выполнение действий состояния для переопределения в наследуемых классах
        /// </summary>
        /// <param name="context">Контекст</param>
        protected override void DoHandle(IContext context)
        {
            Model.CanExecuteSecondButtonCommand = true;
            context.State = new WindowOneWithActiveButtonState();
        }
    }
}
