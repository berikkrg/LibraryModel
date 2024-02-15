using LibraryModel.Source.Abstrcats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Source.Models
{
    public class Reader:Person
    {
        public Reader() 
        {
            Books = new List<Book>();
        
        }
        public List<Book> Books { get; set; }   
    }
}
