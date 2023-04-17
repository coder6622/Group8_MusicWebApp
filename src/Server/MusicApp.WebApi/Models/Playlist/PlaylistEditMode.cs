namespace MusicApp.WebApi.Models
{
    public class CategoryEditMode
    {
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string User { get; set; }
        public string Artists { get; set; }
        public string Tags { get; set; }

    }
}
