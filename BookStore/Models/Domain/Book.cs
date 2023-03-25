using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models.Domain
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int Pages { get; set; }

        [Required]
        public int AuthorID { get; set; }
        [Required]
        public int PublisherID { get; set; }
        [Required]
        public int GenreID { get; set; }

        [NotMapped]
        public string? AuthorName { get; set; }
        [NotMapped]
        public string? GenreName { get; set; }
        [NotMapped]
        public string? PublisherName { get; set; }
        
        [NotMapped]
        public List<SelectListItem>? AuthorList { get; set;}
        [NotMapped]
        public List<SelectListItem>? GenreList { get; set; }
        [NotMapped]
        public List<SelectListItem>? PublisherList { get; set; }
    }
}