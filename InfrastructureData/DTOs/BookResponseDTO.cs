using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.DTOs
{
    public class BookResponseDTO:BookBaseDTO
    {
        public int Id { get; set; } 
        public string AuthorName { get; set; }  
        public string CategoryName { get; set; }
    }
}
