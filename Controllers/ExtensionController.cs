using Microsoft.AspNetCore.Mvc;
using VsExtensionsMarketplace.Models.Parser;

namespace VsExtensionsMarketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtensionController : ControllerBase
    {
        /// <summary>
        /// Search for an extension simplified
        /// </summary>
        /// <param name="id">Id of the extension (idPublisher.extension-name-desc)</param>
        /// <returns>informations of an extension (simplified)</returns>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            MarketplaceParser mpp = new MarketplaceParser();
            var res = mpp.GetExtensionByIdSimplified(id);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }
    }
}