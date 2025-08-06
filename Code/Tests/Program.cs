// See https://aka.ms/new-console-template for more information



using AA.Modules.EcTopologyHandlerModule;
using AA.Modules.EcTopologyHandlerModule.Tests;

namespace EcMasterAcontisApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting  Test...");

        EcTopologyHandlerTests.RunAll();



        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }
}