using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace gamestoolkit.api.Models
{
    [PrimaryKey(nameof(PostId), nameof(CollectionId))]
    public class PostCollection
    {
        public int PostId { get; set; }
        public int CollectionId { get; set; }
        public virtual Post Post { get; set; } = null!;
        public virtual Collection Collection { get; set; } = null!;
    }
}
