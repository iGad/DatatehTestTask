namespace DatatehTestTask
{
    /// <summary>
    /// Контекст выполнения программы
    /// </summary>
    public class Context : IContext
    {
        /// <summary>
        /// Конструктор с инициализацией свойств
        /// </summary>
        /// <param name="initialState">Исходное состояние</param>
        /// <param name="windowManager">Менеджер по созданию окон</param>
        public Context(IState initialState, IWindowManager windowManager)
        {
            State = initialState;
            WindowManager = windowManager;
        }

        /// <summary>
        /// Текущее состояние
        /// </summary>
        public IState State { get; set; }

        /// <summary>
        /// Менеджер по созданию окон
        /// </summary>
        public IWindowManager WindowManager { get; private set; }
    }
}
