using DatatehTestTask.ViewModels;

namespace DatatehTestTask.States
{
    /// <summary>
    /// ���������, ����� ������ ���������� ����� � ���� ����� ������� ����
    /// </summary>
    public class EnterCorrectTextInWindowTwoState : ViewModelState<WindowTwoViewModel>
    {
        /// <summary>
        /// ����������� � �������
        /// </summary>
        /// <param name="viewModel">������</param>
        public EnterCorrectTextInWindowTwoState(WindowTwoViewModel viewModel):base(viewModel)
        {
        }


        /// <summary>
        /// ���������� �������� ��������� ��� ��������������� � ����������� �������
        /// </summary>
        /// <param name="context">��������</param>
        protected override void DoHandle(IContext context)
        {
            Model.CanExecuteButtonThreeCommand = Model.EnteredText.Equals(Constants.ExpectedUserInput);
            if (Model.CanExecuteButtonThreeCommand)
            {
                Model.Close();
                context.State = new WindowOneWithActiveButtonState();
                return;
            }
            Model.UserMessage = Constants.HiTextToUser;
            context.State = new EnterInvalidTextInWindowTwoState(Model);
        }
    }
}