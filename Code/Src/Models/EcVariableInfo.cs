using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AA.Modules.EcTopologyHandlerModule;

public class EcVariableInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("bit_offset")]
    public int BitOffset { get; set; }

    [JsonPropertyName("bit_size")]
    public int BitSize { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}