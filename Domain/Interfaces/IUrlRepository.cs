using SHORTURL.Domain.Entities;

namespace SHORTURL.Domain.Interfaces
{
    public interface IUrlRepository
    {
        Task<UrlEntry> GetByUrlAsync(string shortUrl);
        Task SaveAsync(UrlEntry urlEntry);
    }
}
