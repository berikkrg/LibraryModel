using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class BookBaseDTO
    {
        public string Title { get; set; }
        public bool IsAvailable { get; set; }
        public int YearOfIssue { get; set; }
        public string AuthorName { get; set; }
        public int? ReaderId { get; set; }
        public int CategoryId { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
