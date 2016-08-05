namespace DatatehTestTask
{
    /// <summary>
    /// Интерфейс для состояния
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Переход к следующему состоянию
        /// </summary>
        /// <param name="context">Контекст</param>
        void Go(IContext context);
    }
}
