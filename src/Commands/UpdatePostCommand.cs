using System.ComponentModel.DataAnnotations;

namespace gamestoolkit.api.Commands
{
    public class UpdatePostCommand
    {
        [Required]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public string Author { get; set; } = null!;
        [Required]
        public string ContentHtml { get; set; } = null!;
        public string? PostImage { get; set; }
    }
}
