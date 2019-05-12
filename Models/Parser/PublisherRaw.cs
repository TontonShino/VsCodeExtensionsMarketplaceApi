
namespace VsExtensionMarketplace.Models.Parser
{
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PublisherRaw
    {
        [JsonProperty("extensions")]
        public List<ExtensionRaw> Extensions { get; set; }

        [JsonProperty("pagingToken")]
        public object PagingToken { get; set; }

        [JsonProperty("resultMetadata")]
        public List<ResultMetadatum> ResultMetadata { get; set; }
    }

    public partial class ResultMetadatum
    {
        [JsonProperty("metadataType")]
        public string MetadataType { get; set; }

        [JsonProperty("metadataItems")]
        public List<MetadataItem> MetadataItems { get; set; }
    }

    public partial class MetadataItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public partial class PublisherRaw
    {
        public static PublisherRaw FromJson(string json) => JsonConvert.DeserializeObject<PublisherRaw>(json, VsExtensionMarketplace.Models.Parser.Converter.Settings);
    }

    public static class SerializePub
    {
        public static string ToJson(this PublisherRaw self) => JsonConvert.SerializeObject(self, VsExtensionMarketplace.Models.Parser.Converter.Settings);
    }

    internal static class ConverterPub
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
