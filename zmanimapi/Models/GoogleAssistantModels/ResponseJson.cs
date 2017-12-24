
using Newtonsoft.Json;

namespace zmanimapi.Models.GoogleAssistantModels
{

    public class ResponseJson
    {
        [JsonProperty("speech")]
        public string Speech { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("contextOut")]
        public object[] ContextOut { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

}