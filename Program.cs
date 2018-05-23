using Srpg.App.Domain.Common;
using Srpg.App.Test;
using System;

namespace Srpg
{
    class Program
    {
        static void Main(string[] args)
        {
            ICompositionRoot testRoot = new TestResolutionRoot();
            testRoot.SetUp();
            testRoot.Run();

            Console.ReadKey();
        } 
    }
}
