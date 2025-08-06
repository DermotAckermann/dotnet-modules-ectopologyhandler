using Xunit.Priority;
using AA.Modules.EcTopologyHandlerModule;

namespace AA.Modules.EcTopologyHandlerModule.TestsXUnit;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class EcTopologyHandlerTests
{
    private string path = "D:\\Work Jean\\DotNet Modules\\EC Topology Handler Git\\dotnet-modules-ectopologyhandler\\Code\\SampleFiles\\TopologyData_2b97d574d9deb036.json";
    private static EcTopologyData data;
    private List<EcSlaveInfo> slaves = new();


    [Fact, Priority(2)]
    public void TestCreateJson()
    {
        var sample = CreateSampleTopology();
        var json = EcTopologyHandler.CreateJson(sample);
        Assert.NotNull(json);
    }

    [Fact, Priority(1)]
    public void TestReadJson()
    {
        var json = File.ReadAllText(path);
        data = EcTopologyHandler.ReadJson(json);
        Assert.NotNull(data);
    }

    [Fact, Priority(2)]
    public void TestCreateFromList()
    {
        var json = EcTopologyHandler.CreateFromSlaveInfoList(data.Topology);
        Assert.NotNull(json);
    }

    [Fact, Priority(2)]
    public void TestGenerateHash()
    {
        var vidPcList = data.Topology.Select(s => (s.VendorId, s.ProductCode)).ToList();
        var topologyHash = EcTopologyHandler.GenerateTopologyHashFromVidPc(vidPcList);
        Assert.NotNull(topologyHash);
    }

    [Fact, Priority(2)]
    public void TestGenerateString()
    {
        var vidPcList = data.Topology.Select(s => (s.VendorId, s.ProductCode)).ToList();
        var topologyString = EcTopologyHandler.GenerateTopologyHashFromVidPc(vidPcList);
        Assert.NotNull(topologyString);
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

}


