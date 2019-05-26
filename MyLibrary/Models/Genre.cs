using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter genres name")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}