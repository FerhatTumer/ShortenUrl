using Microsoft.AspNetCore.Mvc;
using SHORTURL.Application.Services;
using SHORTURL.Domain;
using System.Text.Json;

namespace SHORTURL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly UrlService _urlService;
        public UrlController(UrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> Shorten([FromBody] ShortenUrlRequest body)
        {
            try 
            {
                var shortUrl = await _urlService.ShortenUrlAsync(body.longUrl);
                return Created(shortUrl, shortUrl);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> Redirect(string shortUrl)
        {
            try
            {
                var longUrl = await _urlService.GetLongUrlAsync(shortUrl);
                return await Redirect(longUrl);
            }
            catch (ArgumentException ex) 
            { 
                return NotFound();
            }
        }

    }
}
