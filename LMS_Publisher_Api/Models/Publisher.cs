using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryReact.Models
{
    public class Publisher
    {   
        [Key]
        public string PublisherID { get; set; }
        public string PublisherName { get; set; }

    }
}
