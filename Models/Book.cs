using System.ComponentModel.DataAnnotations;

namespace product.Models
{
    public class Book
    {
        [Key]
        public int BookID {get; set;}

        public string BookName {get;set;}
        
         public int AuthorID {get; set;}

      public Authors authors {get; set;}

     
    }
}