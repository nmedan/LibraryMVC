using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyLibrary.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter author's first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter author's last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }

        }

    }

}