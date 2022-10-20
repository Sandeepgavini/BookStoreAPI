using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Modals
{
    public class Book
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsLicensed { get; set; }
        public double Price { get; set; }
        public string Genre { get; set; }
        
        public string HiddenKey { get; set; }
    }
}
