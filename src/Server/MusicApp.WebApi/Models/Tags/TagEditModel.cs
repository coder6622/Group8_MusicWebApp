namespace MusicApp.WebApi.Models.Tags
{
    public class TagEditModel
    {
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public bool Enable { get; set; }
        public Guid GroupTagId { get; set; }
    }
}
