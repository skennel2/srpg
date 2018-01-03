using Srpg.App.Domain.Common;

namespace Srpg.App.Test
{
    public class TestResolutionRoot : ICompositionRoot
    {
        private Test1 test1;

        public void SetUp()
        {
            test1 = new Test1();
        }

        public void Run()
        {
            test1.OneOnOneBattleTest();
            test1.MapDrawTest();
        }
    }
}