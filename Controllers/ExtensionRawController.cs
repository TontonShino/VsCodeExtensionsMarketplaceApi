using Microsoft.AspNetCore.Mvc;
using VsExtensionsMarketplace.Models.Parser;

namespace VsExtensionsMarketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtensionRawController : ControllerBase
    {
        /// <summary>
        ///Search for an extension details
        /// </summary>
        /// <param name="id">Id of the extension (idPublisher.extension-name-desc)</param>
        /// <returns>Raw informations of an extension</returns>
        // GET: api/Extension/extension.id.name
        [HttpGet("{id}", Name = "GetSimplidied")]
        public IActionResult Get(string id)
        {
            MarketplaceParser mpp = new MarketplaceParser();
            var data = mpp.GetExtensionByIdRaw(id);

            if (data == null)
            {
                return NotFound();              
            }
            
            return Ok(data);
        }


    }
}
