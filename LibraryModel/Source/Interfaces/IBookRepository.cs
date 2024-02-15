using InfrastructureData.DTOs;
using LibraryModel.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Source.Interfaces
{
    public  interface IBookRepository
    {
        Task<List<BookResponseDTO>> GetAllBooks();
        Task<List<BookResponseDTO>> AddBooks(AddBookRequestDTO bookRequestDTO);
        List<Book> GetBooksByAuthor(string author);
        List<Book> GetUsersBooks(int userId);
        Book GetBookById(int id);
    }
}
