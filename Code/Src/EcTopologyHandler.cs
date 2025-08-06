using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AA.Modules.EcTopologyHandlerModule;



public static class EcTopologyHandler
{
    //*** Class data

    #region Fields & Properties
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = null // We'll use explicit JsonPropertyName
    };
    #endregion

    //*** Constructors


    //*** Methods public

    public static string CreateJson(EcTopologyData topologyData)
    {
        var root = new EcTopologyDataRoot { TopologyData = topologyData };

        return JsonSerializer.Serialize(root, Options);
    }

    public static EcTopologyData ReadJson(string json)
    {
        var root = JsonSerializer.Deserialize<EcTopologyDataRoot>(json, Options)!;
        return root.TopologyData;
    }

    public static EcTopologyData CreateFromSlaveInfoList(List<EcSlaveInfo> slaves)
    {
        if (slaves == null || slaves.Count == 0)
            throw new ArgumentException("Slave list cannot be null or empty.");

        // Extract (VendorId, ProductCode) pairs
        var vidPcList = slaves
            .Select(s => (s.VendorId, s.ProductCode))
            .ToList();

        // Generate hash
        string topologyHash = GenerateTopologyHashFromVidPc(vidPcList);

        // Construct and return EcTopologyData
        return new EcTopologyData
        {
            TopologyHash = topologyHash,
            Topology = slaves
        };
    }

    public static string GenerateTopologyHashFromVidPc(List<(uint vendorId, uint productCode)> slaves)
    {

        var topologyString = GenerateTopologyStringFromVidPc(slaves);

        // Compute FNV-1a 64-bit hash
        ulong fnvPrime = 1099511628211UL;
        ulong hash64 = 1469598103934665603UL; // FNV offset basis

        foreach (byte b in Encoding.UTF8.GetBytes(topologyString))
        {
            hash64 ^= b;
            hash64 *= fnvPrime;
        }

        // Return 16-char lowercase hex
        string hash = hash64.ToString("x16");

        return (hash);
    }

    public static string GenerateTopologyStringFromVidPc(List<(uint vendorId, uint productCode)> slaves)
    {
        if (slaves == null || !slaves.Any())
            throw new ArgumentException("Slave list cannot be empty");

        // Build readable topology string
        var sb = new StringBuilder();
        foreach (var s in slaves)
        {
            if (sb.Length > 0)
                sb.Append("_");
            sb.AppendFormat("{0:X8}-{1:X8}", s.vendorId, s.productCode);
        }

        string topologyString = sb.ToString();

        return topologyString;
    }


}
