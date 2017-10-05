
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aarvani.ChannelAdvisor.Entities
{
    public class ODataResponse<T>
    {
        [JsonProperty("@odata.context")]
        public string context { get; set; }
        public  IEnumerable<T> value { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string nextlink { get; set; }
    }
}
