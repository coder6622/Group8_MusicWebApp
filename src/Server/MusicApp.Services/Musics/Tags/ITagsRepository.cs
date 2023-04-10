using MusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services.Musics.Tags
{
    public interface ITagsRepository
    {
       Task<bool> IsTagSlugExistedAsync(
            Guid id,
            string slug,
            CancellationToken cancellationToken = default);

        Task<Tag> AddOrUpdateTag(Tag tag, CancellationToken cancellationToken = default);
        Task<bool> DeleteTagById(Guid id, CancellationToken cancellationToken = default);
    }
}
