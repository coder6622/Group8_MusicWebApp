namespace MusicApp.WebApi.Models.GroupTag
{
    public class GroupTagEditModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public bool Enable { get; set; }
    }
}
