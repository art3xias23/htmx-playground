using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_htmx.DB
{
    public class Contact
    {
        [Key]
public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string Error { get; set; }
    }
}
