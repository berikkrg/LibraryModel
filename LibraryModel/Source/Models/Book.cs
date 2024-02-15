using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Source.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsAvailable { get; set; }
        public int YearOfIssue { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int AuthorId { get; set; }  
        public int CategoryId { get; set; }
        public string StatusCode { get; set; }
        public string AuthorName { get; set; }
        public string CategoryString { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }


    }
}
