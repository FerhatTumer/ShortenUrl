using SHORTURL.Domain.Entities;
using SHORTURL.Domain.Interfaces;

namespace SHORTURL.Application.Services
{
    public class UrlService
    {
        private readonly IUrlRepository _urlRepository;
        public UrlService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<string> ShortenUrlAsync(string longUrl)
        {
            if (!Uri.TryCreate(longUrl, UriKind.Absolute, out var uriResult) || (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                throw new ArgumentException("Invalid URL format.");
            }

            string shortUrl;
            do
            {
                shortUrl = GenerateShortUrl();
            } while (await _urlRepository.GetByUrlAsync(shortUrl) != null);

            var UrlEntry = new UrlEntry { LongUrl = longUrl, ShortUrl = shortUrl };
            await _urlRepository.SaveAsync(UrlEntry);

            return shortUrl;
        }

        public async Task<string> GetLongUrlAsync(string shortUrl)
        {
            var urlEntry = await _urlRepository.GetByUrlAsync(shortUrl);
            if (urlEntry == null)
            {
                throw new ArgumentException("Short URL not found");
            }
            return urlEntry.LongUrl;
        }

        private string GenerateShortUrl()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(chars.Length)]).ToArray());
        }
    }
}
