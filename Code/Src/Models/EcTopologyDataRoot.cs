using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AA.Modules.EcTopologyHandlerModule;

public class EcTopologyDataRoot
{
    [JsonPropertyName("topology_data")]
    public EcTopologyData TopologyData { get; set; }
}
