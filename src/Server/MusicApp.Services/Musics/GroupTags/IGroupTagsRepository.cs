using MusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services.Musics.GroupTags
{
    public interface IGroupTagsRepository
    {
        Task<bool> IsGrTagSlugExistedAsync(
            Guid id, string slug, CancellationToken cancellationToken = default);

        Task<GroupTag> AddOrUpdateGrTag(GroupTag grTag, CancellationToken cancellationToken = default);

        Task<bool> DeleteGrTagById(Guid id, CancellationToken cancellationToken = default);
    }

 
}
