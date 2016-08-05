using DatatehTestTask;
using DatatehTestTask.ViewModels;

namespace DatatehTestTaskTests
{
    internal class IStateSubstitute : IState
    {
        public void Handle(IContext context)
        {
            IsHandleCalled = true;
        }

        public bool IsHandleCalled { get; private set; }
    }

    internal static class TestHelper
    {

        public static IState CreateIStateSubstitute()
        {
            return new IStateSubstitute();
        }

        public static IContext CreateTestContext()
        {
            return new Context(CreateIStateSubstitute(), new WindowManagerMock());
        }

        public static WindowOneViewModel CreateWindowOneViewModel()
        {
            return new WindowOneViewModel(CreateTestContext());
        }

        public static WindowTwoViewModel CreateWindowTwoViewModel()
        {
            return new WindowTwoViewModel(CreateTestContext());
        }
    }
}
