using System;
using System.Diagnostics;
using HtmlAgilityPack;
using VsExtensionMarketplace.Models.Parser;

namespace VsExtensionsMarketplace.Models.Parser
{

    public class MarketplaceParser
    {
        private HtmlWeb web;
        readonly private string UrlExt = @"https://marketplace.visualstudio.com/items?itemName=";
        readonly private string UrlPub = @"https://marketplace.visualstudio.com/publishers/";

        public MarketplaceParser() { }

        private string ParseMktpExt(string id)
        {
            try
            {
                web = new HtmlWeb();
                string fullUrl = UrlExt + id;
                var htmlDoc = web.Load(fullUrl);

                var vss = htmlDoc.DocumentNode.SelectSingleNode("//script[@class='vss-extension']").InnerHtml;
                return vss;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Err For id {id}:{e.ToString()}");
                return null;
            }
        }

        private string ParseMktpPublisher(string id)
        {
            try
            {
                web = new HtmlWeb();
                string fullUrl = UrlPub + id;
                var htmlDoc = web.Load(fullUrl);

                var vsp = htmlDoc.DocumentNode.SelectSingleNode("//script[@class='vscode-extensions-result']").InnerHtml;
                return vsp;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Err For id {id}:{e.ToString()}");
                return null;
            }
        }

        public PublisherRaw GetPublisherRaw(string id)
        {
            try
            {
                string vsp = ParseMktpPublisher(id);
                return PublisherRaw.FromJson(vsp);

            }
            catch
            {
                return null;
            }
        }

        public ExtensionRaw GetExtensionByIdRaw(string id)
        {
            try
            {
                string vss = ParseMktpExt(id);
                return ExtensionRaw.FromJson(vss);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Err For id {id}:{e.ToString()}");
                return null;
            }
        }

        public ExtensionSimplified GetExtensionByIdSimplified(string id)
        {
            ExtensionSimplified ext;
            try
            {
                var vss = ParseMktpExt(id);

                var toSimplify = ExtensionRaw.FromJson(vss);

                ext = new ExtensionSimplified
                {
                    ExtensionId = toSimplify.ExtensionId,
                    DisplayName = toSimplify.DisplayName,
                    Publisher = toSimplify.Publisher.DisplayName,
                    ShortDescription = toSimplify.ShortDescription,
                    ExtensionName = toSimplify.ExtensionName,
                    PublisherName = toSimplify.Publisher.PublisherName
                };
                return ext;

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Err For id {id}:{e.ToString()}");
                return null;
            }

        }
    }

}
