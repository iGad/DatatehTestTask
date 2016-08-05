using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// �������������� ��������� ������� ����
    /// </summary>
    public class WindowTwoInitialState : ViewModelState<WindowTwoViewModel>
    {
        /// <summary>
        /// ����������� � �������
        /// </summary>
        /// <param name="viewModel">������</param>
        public WindowTwoInitialState(WindowTwoViewModel viewModel):base(viewModel)
        {
        }

        /// <summary>
        /// ���������� �������� ��������� ��� ��������������� � ����������� �������
        /// </summary>
        /// <param name="context">��������</param>
        protected override void DoGo(IContext context)
        {
            if (!Model.EnteredText.Equals(string.Empty))
            {
                Model.CanExecuteButtonThreeCommand = false;
                context.State = new EnterInvalidTextInWindowTwoState(Model);
                return;
            }
            context.State = new WindowOneWithActiveButtonState();
            Model.Close();
        }
    }
}