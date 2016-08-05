using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatatehTestTask;
using DatatehTestTask.ViewModels;

namespace DatatehTestTaskTests
{
    internal class IStateSubstitute : IState
    {
        public void Handle(IContext context)
        {
            
        }
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
