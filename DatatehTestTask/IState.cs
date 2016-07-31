namespace DatatehTestTask
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Состояние контекста
        /// </summary>
        IState State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IWindowManager WindowManager { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IState
    {
        void Handle(IContext context);
    }
}
