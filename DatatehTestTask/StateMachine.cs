namespace DatatehTestTask
{
    /// <summary>
    /// 
    /// </summary>
    public class StateMachine : IContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialState"></param>
        /// <param name="windowManager"></param>
        public StateMachine(IState initialState, IWindowManager windowManager)
        {
            State = initialState;
            WindowManager = windowManager;
        }

        /// <summary>
        /// Состояние машины
        /// </summary>
        public IState State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IWindowManager WindowManager { get; private set; }
    }
}
