using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace MyLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter ISBN number")]     
        [RegularExpression(@"\d{13}", ErrorMessage = "ISBN number must be in 13-digit format.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please select year.")]
        [Display(Name = "Publishing Year")]
        public int PublishingYear { get; set; }

        [Required(ErrorMessage = "Please select author.")]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }      

        [Required(ErrorMessage = "Please select genre.")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }      

        public virtual Genre Genre { get; set; }

    }
}