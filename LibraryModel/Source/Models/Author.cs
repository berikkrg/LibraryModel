using LibraryModel.Source.Abstrcats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Source.Models
{
    public class Author:Person
    {
        public Author()
        {
            Books = new List<Book>();
        }
        public List<Book> Books { get; set; }

        public string GetName () { return this.FirstName; }
        public int GetYearOfBirth () { return (int)this.DateOfBirth.Year; }
    }
}
