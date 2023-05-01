using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MusicApp.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.Core.Entities;

namespace MusicApp.Services.Musics.GroupTags
{
    public class GroupTagsRepository : IGroupTagsRepository
    {
        private readonly MusicDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public GroupTagsRepository(MusicDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<bool> IsGrTagSlugExistedAsync(Guid grtagID, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.GroupTags.AnyAsync(
                x => x.Id != grtagID && x.UrlSlug == slug, cancellationToken);
        }

        public async Task<GroupTag> AddOrUpdateGrTag(GroupTag grTag, CancellationToken cancellationToken = default)
        {
            if (_context.Set<GroupTag>().Any(t => t.Id == grTag.Id)) 
            {
                _context.Entry(grTag).State = EntityState.Modified;
            }
            else
            {
                _context.GroupTags.Add(grTag);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return grTag;
        }

        public async Task<bool> DeleteGrTagById(Guid id, CancellationToken cancellationToken = default)
        {
            var grTag = _context.Set<GroupTag>().FirstOrDefault(t => t.Id == id);
            if(grTag != null) 
            {
                _context.GroupTags.Remove(grTag);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
