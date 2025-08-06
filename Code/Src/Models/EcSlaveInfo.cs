using AA.Modules.EcTopologyHandlerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AA.Modules.EcTopologyHandlerModule;

public class EcSlaveInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("vendor_id")]
    public uint VendorId { get; set; }

    [JsonPropertyName("product_code")]
    public uint ProductCode { get; set; }

    [JsonPropertyName("input_data_info")]
    public List<EcVariableInfo> InputDataInfo { get; set; } = new();
}
