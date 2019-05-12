//Generated with QuickType
namespace VsExtensionMarketplace.Models.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ExtensionRaw
    {
        [JsonProperty("publisher")]
        public Publisher Publisher { get; set; }

        [JsonProperty("extensionId")]
        public Guid ExtensionId { get; set; }

        [JsonProperty("extensionName")]
        public string ExtensionName { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("flags")]
        public string Flags { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("publishedDate")]
        public DateTimeOffset PublishedDate { get; set; }

        [JsonProperty("releaseDate")]
        public DateTimeOffset ReleaseDate { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("versions")]
        public List<Version> Versions { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("statistics")]
        public List<Statistic> Statistics { get; set; }

        [JsonProperty("installationTargets")]
        public List<InstallationTarget> InstallationTargets { get; set; }

        [JsonProperty("deploymentType")]
        public long DeploymentType { get; set; }
    }

    public partial class InstallationTarget
    {
        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("targetVersion")]
        public string TargetVersion { get; set; }
    }

    public partial class Publisher
    {
        [JsonProperty("publisherId")]
        public Guid PublisherId { get; set; }

        [JsonProperty("publisherName")]
        public string PublisherName { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("flags")]
        public string Flags { get; set; }
    }

    public partial class Statistic
    {
        [JsonProperty("statisticName")]
        public string StatisticName { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public partial class Version
    {
        [JsonProperty("version")]
        public string VersionVersion { get; set; }

        [JsonProperty("flags")]
        public string Flags { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("files")]
        public List<File> Files { get; set; }

        [JsonProperty("properties")]
        public List<Property> Properties { get; set; }

        [JsonProperty("assetUri")]
        public Uri AssetUri { get; set; }

        [JsonProperty("fallbackAssetUri")]
        public Uri FallbackAssetUri { get; set; }
    }

    public partial class File
    {
        [JsonProperty("assetType")]
        public string AssetType { get; set; }

        [JsonProperty("source")]
        public Uri Source { get; set; }
    }

    public partial class Property
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class ExtensionRaw
    {
        public static ExtensionRaw FromJson(string json) => JsonConvert.DeserializeObject<ExtensionRaw>(json, VsExtensionMarketplace.Models.Parser.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ExtensionRaw self) => JsonConvert.SerializeObject(self, VsExtensionMarketplace.Models.Parser.Converter.Settings);
    }

    internal static class Converter
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
