using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// �������������� ��������� �������
    /// </summary>
    public class InitialState : StateBase
    {
        /// <summary>
        /// ���������� ������ ����
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