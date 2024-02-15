using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryData.Context;
using LibraryData.Entities;
using LibraryAPI.Repositories;
using InfrastructureData.DTOs;
using Serilog;
using NuGet.Protocol;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly BooksRepository _booksRepository;

        public BooksController(LibraryDbContext context)
        {
            _context = context;
            _booksRepository = new BooksRepository(_context);
        }

        // GET: api/Books
        [HttpGet("/getAllBooks")]
        public async Task<ActionResult<IEnumerable<BookResponseDTO>>> GetAllBooks()
        {
            List<BookResponseDTO > responseDTO = new List<BookResponseDTO>();
            var books =  await _booksRepository.GetBooksAsync();

            foreach (var book in books)
            {
                responseDTO.Add(new BookResponseDTO
                {
                    AuthorName = book.AuthorName,
                    Id = book.Id,
                    IsAvailable = book.IsAvailable,
                    CategoryId = book.CategoryId,
                    CategoryName = book.Category.Name,
                    Title = book.Title,
                    YearOfIssue = book.YearOfIssue,
                    ReaderId = book.ReaderId,
                    ReturnDate = book.ReturnDate,
                }) ;
            }
            return responseDTO;
        }




        // GET: api/Books/getBookById/5
        [HttpGet("/getBookById/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {

            var book = await _booksRepository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("/getBooksByAuthorId/{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(string name)
        {

            var books = await _booksRepository.GetBooksByAuthor(name);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        [HttpGet("/getBooksByCategoryId/{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByCategory(int id)
        {

            var books = await _booksRepository.GetBooksByCategory(id);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        // POST: api/Books//addBook
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/addBook/")]
        public async Task<ActionResult<IEnumerable<BookResponseDTO>>> AddBook(AddBookRequestDTO requestDTO)
        {
            Book bookToAdd = new Book()
            {
                AuthorName = requestDTO.AuthorName,
                Title = requestDTO.Title,
                YearOfIssue = requestDTO.YearOfIssue,
                IsAvailable = requestDTO.IsAvailable,
                ReaderId = requestDTO.ReaderId,
                ReturnDate = requestDTO.ReturnDate,
                CategoryId = requestDTO.CategoryId,
            };

           var books = await _booksRepository.AddBookAsync(bookToAdd);
            if (books == null)
            {
                return NotFound();
            }

            List<BookResponseDTO> responseDTO = new List<BookResponseDTO>();
            foreach (var book in books)
            {
                responseDTO.Add(new BookResponseDTO
                {
                    AuthorName = book.AuthorName,
                    Id = book.Id,
                    IsAvailable = book.IsAvailable,
                    CategoryId = book.CategoryId,
                    CategoryName = book.Category.Name,
                    Title = book.Title,
                    YearOfIssue = book.YearOfIssue,
                    ReaderId = book.ReaderId,
                    ReturnDate = book.ReturnDate,
                });
            }
            return responseDTO;
        }


        [HttpPost("/updateBook/")]
        public async Task<ActionResult<IEnumerable<BookResponseDTO>>> UpdateBook(UpdateBookDTO requestDTO)
        {
            Book bookRequest = new Book()
            {
                Id = requestDTO.Id,
                AuthorName = requestDTO.AuthorName,
                Title = requestDTO.Title,
                YearOfIssue = requestDTO.YearOfIssue,
                IsAvailable = requestDTO.IsAvailable,
                ReaderId = requestDTO.ReaderId,
                ReturnDate = requestDTO.ReturnDate,
                CategoryId = requestDTO.CategoryId,
            };

            var books = await _booksRepository.UpdateBook(requestDTO.Id, bookRequest);
            if (books == null)
            {
                return NotFound();
            }

            List<BookResponseDTO> responseDTO = new List<BookResponseDTO>();
            foreach (var book in books)
            {
                responseDTO.Add(new BookResponseDTO
                {
                    AuthorName = book.AuthorName,
                    Id = book.Id,
                    IsAvailable = book.IsAvailable,
                    CategoryId = book.CategoryId,
                    CategoryName = book.Category.Name,
                    Title = book.Title,
                    YearOfIssue = book.YearOfIssue,
                    ReaderId = book.ReaderId,
                    ReturnDate = book.ReturnDate,
                });
            }
            return responseDTO;
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<BookResponseDTO>>> DeleteBook(int id)
        {
            var books = await _booksRepository.DeleteBook(id);
            if (books==null)
            {
                return NotFound();
            }

            List<BookResponseDTO> responseDTO = new List<BookResponseDTO>();
            foreach (var book in books)
            {
                responseDTO.Add(new BookResponseDTO
                {
                    AuthorName = book.AuthorName,
                    Id = book.Id,
                    IsAvailable = book.IsAvailable,
                    CategoryId = book.CategoryId,
                    CategoryName = book.Category.Name,
                    Title = book.Title,
                    YearOfIssue = book.YearOfIssue,
                    ReaderId = book.ReaderId,
                    ReturnDate = book.ReturnDate,
                });
            }
            return responseDTO;

            //return books;
        }
        
    }
}
