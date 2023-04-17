using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MusicApp.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.Core.Entities;

namespace MusicApp.Services.Musics.Tags
{
    public class TagsRepository : ITagsRepository
    {
        private readonly MusicDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public TagsRepository(MusicDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<bool> IsTagSlugExistedAsync(Guid tagId, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Tags.AnyAsync(
                x => x.Id != tagId && x.UrlSlug == slug, cancellationToken);
        }

        public async Task<Tag> AddOrUpdateTag(Tag tag, CancellationToken cancellationToken = default)
        {
            if (_context.Set<Tag>().Any(t => t.Id == tag.Id)) 
            {
                _context.Entry(tag).State = EntityState.Modified;
            }
            else
            {
                _context.Tags.Add(tag);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return tag;          
        }
        public async Task<bool> DeleteTagById(Guid id, CancellationToken cancellationToken = default)
        {
            var tag = _context.Set<Tag>().FirstOrDefault(t => t.Id == id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
