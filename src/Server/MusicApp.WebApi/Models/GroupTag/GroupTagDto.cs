using MusicApp.Core.Entities;

namespace MusicApp.WebApi.Models.GroupTag
{
    public class GroupTagDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }

        public IList<Tag> Tags { get; set; }
}
}
