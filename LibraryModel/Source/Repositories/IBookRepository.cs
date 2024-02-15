using InfrastructureData.DTOs;
using LibraryModel.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelClient.Source.Repositories
{
    /// <summary>
    /// The IBookRepository interface defines the operations that a book repository should support.
    /// </summary>
    public interface IBookRepository
    {
        Task<List<BookResponseDTO>> GetAllBooks();

        Task<List<BookResponseDTO>> AddBooks(AddBookRequestDTO bookRequestDTO);
        List<Book> GetBooksByAuthor(string author);
        List<Book> GetUsersBooks(int userId);
        Book GetBookById(int id);
    }
}
