namespace gamestoolkit.api.ViewModels
{
    public class PostWithoutContent
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Author { get; set; } = null!;
        public string? PostImage { get; set; }
    }
}
