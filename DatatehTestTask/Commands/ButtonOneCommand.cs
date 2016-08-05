using DatatehTestTask.States;
using Prism.Commands;

namespace DatatehTestTask.Commands
{
    /// <summary>
    /// Команда активации второй кнопки
    /// </summary>
    public class ButtonOneCommand : DelegateCommand<IContext>
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ButtonOneCommand() : base(ExecuteMethod)
        {
        }

        private static void ExecuteMethod(IContext context)
        {
            if (context.State is WindowOneInitialState)
            {
                context.State.Go(context);
            }
        }
    }
}
