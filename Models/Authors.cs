using System.ComponentModel.DataAnnotations;

namespace product.Models
{
    public class Authors
    {
         [Key]
        public int AuthorID {get; set;}

        public string AuthorName {get; set;}

        public ICollection<Book> books {get; set;}
    }
}