using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsAvailable { get; set; }
        public int YearOfIssue { get; set; }
        public string  AuthorName { get; set; }
        public int? ReaderId { get; set; }
        public int CategoryId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Category Category { get; set; }
        public Reader Reader { get; set; }
    }
}
