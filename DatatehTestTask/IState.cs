namespace DatatehTestTask
{
    /// <summary>
    /// 
    /// </summary>
    public interface IState
    {
        void Handle(IContext context);
    }
}
