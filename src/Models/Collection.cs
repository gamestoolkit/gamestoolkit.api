using System.ComponentModel.DataAnnotations;

namespace gamestoolkit.api.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public virtual List<PostCollection> PostCollections { get; } = [];
        // Note: This is an skip-navigations, because they skip over the join entity to provide direct access to the other side of the many-to-many relationship
        //public virtual List<Post> Posts { get; } = [];
    }
}
