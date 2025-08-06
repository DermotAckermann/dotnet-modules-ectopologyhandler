using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using AA.Modules.EcTopologyHandlerModule;

namespace AA.Modules.EcTopologyHandlerModule.Tests;


public static class EcTopologyHandlerTests
{
    public static void RunAll()
    {
        TestRoundtripSerialization();
        Console.WriteLine("✅ All EcTopologyDataHandler tests passed!");
    }

    private static EcTopologyData CreateSampleTopology()
    {
        return new EcTopologyData
        {
            TopologyHash = "dsfdjjg3453",
            Topology = new()
            {
                new EcSlaveInfo
                {
                    Name = "Slave_1001",
                    VendorId = 2,
                    ProductCode = 3436,
                    InputDataInfo = new()
                    {
                        new EcVariableInfo { Name = "var1", BitOffset = 3, BitSize = 2, Type = "UINT32" }
                    }
                },
                new EcSlaveInfo
                {
                    Name = "Slave_1002",
                    VendorId = 2,
                    ProductCode = 3436,
                    InputDataInfo = new()
                    {
                        new EcVariableInfo { Name = "var1", BitOffset = 2, BitSize = 1, Type = "4BOOL" },
                        new EcVariableInfo { Name = "var2", BitOffset = 34, BitSize = 6, Type = "UINT32" }
                    }
                }
            }
        };
    }

    private static void TestRoundtripSerialization()
    {
        var original = CreateSampleTopology();

        // Serialize
        string json = EcTopologyHandler.CreateJson(original);
        Debug.Assert(!string.IsNullOrEmpty(json), "Serialization failed (empty JSON)");

        // Deserialize
        var parsed = EcTopologyHandler.ReadJson(json);
        Debug.Assert(parsed != null, "Deserialization failed (null result)");

        // Compare basic properties
        Debug.Assert(parsed.TopologyHash == original.TopologyHash, "TopologyHash mismatch");
        Debug.Assert(parsed.Topology.Count == original.Topology.Count, "Slave count mismatch");

        // Compare first slave
        var s1Original = original.Topology[0];
        var s1Parsed = parsed.Topology[0];
        Debug.Assert(s1Original.Name == s1Parsed.Name, "Slave name mismatch");
        Debug.Assert(s1Original.VendorId == s1Parsed.VendorId, "VendorId mismatch");
        Debug.Assert(s1Original.ProductCode == s1Parsed.ProductCode, "ProductCode mismatch");
        Debug.Assert(s1Original.InputDataInfo.Count == s1Parsed.InputDataInfo.Count, "Variable count mismatch");

        // Compare one variable
        var vOriginal = s1Original.InputDataInfo[0];
        var vParsed = s1Parsed.InputDataInfo[0];
        Debug.Assert(vOriginal.Name == vParsed.Name, "Variable name mismatch");
        Debug.Assert(vOriginal.BitOffset == vParsed.BitOffset, "BitOffset mismatch");
        Debug.Assert(vOriginal.BitSize == vParsed.BitSize, "BitSize mismatch");
        Debug.Assert(vOriginal.Type == vParsed.Type, "Type mismatch");
    }
}
