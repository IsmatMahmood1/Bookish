using System.ComponentModel.DataAnnotations;

namespace Bookish.Models
{
    public class AddMemberViewModel
    {
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "ActiveStatus")]
        public bool ActiveStatus { get; set; }
       
    }
}