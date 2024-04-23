using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace gamestoolkit.api.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public string Author { get; set; } = null!;
        [Required]
        public string ContentHtml { get; set; } = null!;
        public string? PostImage { get; set; }
        public virtual List<PostCollection> PostCollections { get; } = [];
        // Note: This is an skip-navigations, because they skip over the join entity to provide direct access to the other side of the many-to-many relationship
        //public virtual List<Collection> Collections { get; } = [];

    }
}
