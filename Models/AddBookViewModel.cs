using System.ComponentModel.DataAnnotations;

namespace Bookish.Models
{
    public class AddBookViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
               
        [Display(Name = "YearPublished")]
        public int YearPublished { get; set; }
               
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }
        [Required]
        [Display(Name = "AuthorFirstName")]
        public string AuthorFirstName { get; set; }
        [Required]
        [Display(Name = "AuthorLastName")]
        public string AuthorLastName { get; set; }
        [Required]
        [Display(Name ="NumberOfCopies")]
        public int NumberOfCopies { get; set; }
    }
}