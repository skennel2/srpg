using System;
using System.Collections.Generic;
using Srpg.App.ConsoleApp;
using Srpg.App.Domain.Common;
using Srpg.App.Domain.Map;
using Srpg.App.Service;
using Srpg.App.Test;

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
