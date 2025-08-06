using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AA.Modules.EcTopologyHandlerModule;

public class EcTopologyData
{
    [JsonPropertyName("topology_hash")]
    public string TopologyHash { get; set; }

    [JsonPropertyName("topology")]
    public List<EcSlaveInfo> Topology { get; set; } = new();
}
