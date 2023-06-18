using SHORTURL.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using SHORTURL.Domain.Entities;


namespace SHORTURL.Infrastructure.Data
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlDbContext _dbContext;
        public UrlRepository(UrlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UrlEntry> GetByUrlAsync(string shortUrl)
        {
            return await _dbContext.UrlEntries.FirstAsync(u=>u.ShortUrl == shortUrl);
        }

        public async Task SaveAsync(UrlEntry urlEntry)
        {
            _dbContext.UrlEntries.Add(urlEntry);
            await _dbContext.SaveChangesAsync();
        }
    }
}
