using Microsoft.AspNetCore.Mvc;
using VsExtensionsMarketplace.Models.Parser;

namespace VsExtensionsMarketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherRawController : ControllerBase
    {
        /// <summary>
        /// Search of all extensions by publisher.
        /// </summary>
        /// <param name="id">The human id of publisher (ex: microsoft)</param>
        /// <returns>Return all extensions published by the concerned publisher.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            MarketplaceParser mpp = new MarketplaceParser();
            var data = mpp.GetPublisherRaw(id);

            if(data==null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}