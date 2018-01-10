using System;
using System.Collections.Generic;
using Srpg.App.ConsoleApp;
using Srpg.App.Domain.Common;
using Srpg.App.Service;
using Srpg.App.Test;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

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
