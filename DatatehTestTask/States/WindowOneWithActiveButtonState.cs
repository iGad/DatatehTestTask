using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// Состояние первого окна с активной кнопкой 2
    /// </summary>
    public class WindowOneWithActiveButtonState : StateBase
    {
        /// <summary>
        /// Выполнение действий состояния для переопределения в наследуемых классах
        /// </summary>
        /// <param name="context">Контекст</param>
        protected override void DoHandle(IContext context)
        {
            var windowTwoViewModel = new WindowTwoViewModel(context);
            context.State = new WindowTwoInitialState(windowTwoViewModel);
            context.WindowManager.ShowWindow(windowTwoViewModel, true);
        }
    }
}