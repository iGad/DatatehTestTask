using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// ��������� ������� ���� � �������� ������� 2
    /// </summary>
    public class WindowOneWithActiveButtonState : StateBase
    {
        /// <summary>
        /// ���������� �������� ��������� ��� ��������������� � ����������� �������
        /// </summary>
        /// <param name="context">��������</param>
        protected override void DoHandle(IContext context)
        {
            var windowTwoViewModel = new WindowTwoViewModel(context);
            context.State = new WindowTwoInitialState(windowTwoViewModel);
            context.WindowManager.ShowWindow(windowTwoViewModel, true);
        }
    }
}