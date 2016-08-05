namespace DatatehTestTask
{
    /// <summary>
    /// Абстракция для контекста
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Состояние контекста
        /// </summary>
        IState State { get; set; }

        /// <summary>
        /// Абстракция менеджера окон
        /// </summary>
        IWindowManager WindowManager { get; }
    }
}