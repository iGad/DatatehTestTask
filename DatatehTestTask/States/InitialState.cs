using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// Первоначальное состояние системы
    /// </summary>
    public class InitialState : StateBase
    {
        /// <summary>
        /// Показывает первое окно
        /// </summary>
        /// <param name="context"></param>
        protected override void DoGo(IContext context)
        {
            var viewModel = new WindowOneViewModel(context);
            context.WindowManager.ShowWindow(viewModel, false);
            context.State = new WindowOneInitialState(viewModel);
        }
    }
}