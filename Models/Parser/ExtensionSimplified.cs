using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VsExtensionsMarketplace.Models.Parser
{
    public class ExtensionSimplified
    {
        public string Publisher { get; set; }
        public Guid ExtensionId { get; set; }
        public string PublisherName { get; set; }
        public string ExtensionName { get; set; }
        public string ShortDescription { get; set; }
        public string DisplayName { get; set; }
    }
}
