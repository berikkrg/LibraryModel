using InfrastructureData.DTOs;
using InfrastructureData.Http;
using LibraryModel.Source.Models;
using LibraryModelClient.Source.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Services.Books
{
    /// <summary>
    /// The BooksService class implements the IBookRepository interface and provides a service for managing books.
    /// </summary>
    public class BooksService:IBookRepository
    {
        // An instance of HttpBase to handle HTTP requests.
        private HttpBase _httpBase;
        /// <summary>
        /// The constructor for the BooksService initializes the HttpBase instance.
        /// </summary>
        public BooksService() 
        {
            _httpBase = new HttpBase();
        }

        /// <summary>
        /// The GetAllBooks method retrieves all books from the server.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation. The task result contains a list of books.</returns>
        public async Task<List<BookResponseDTO>> GetAllBooks()
        {
            List<BookResponseDTO> books = new List<BookResponseDTO>();
            //var response = _httpBase.HttpClient.GetAsync("getAllBooks");

            var client = _httpBase.HttpClient;

            var response = await client.GetAsync("getAllBooks");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                books = JsonConvert.DeserializeObject<List<BookResponseDTO>>(jsonResponse);

            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            return books;
        }


        /// <summary>
        /// The AddBooks method sends query to LibraryAPI to add books to Database
        /// </summary>
        /// <param name = "requestDTO">The request that sends to API</param>
        /// <returns>a list of bookResponseDTO from LibraryAPI</returns>
        public async Task<List<BookResponseDTO>> AddBooks(AddBookRequestDTO requestDTO)
        {
            List<BookResponseDTO> books = new List<BookResponseDTO>();
            //var response = _httpBase.HttpClient.GetAsync("getAllBooks");
            var client = _httpBase.HttpClient;
            var request = new AddBookRequestDTO() { AuthorName = requestDTO.AuthorName, CategoryId = requestDTO.CategoryId, Title = requestDTO.Title, IsAvailable=true, ReaderId = null, ReturnDate = null, YearOfIssue = requestDTO.YearOfIssue};
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = client.PostAsync("addBook", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                books = JsonConvert.DeserializeObject<List<BookResponseDTO>>(jsonResponse);

            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            return books;
        }

        /// <summary>
        /// The UpdateBook method sends a POST request to the server to update a book's details.
        /// </summary>
        /// <param name="requestDTO">The request object containing the new details of the book.</param>
        /// <returns>A Task that represents the asynchronous operation. The task result contains a list of books.</returns>
        public async Task<List<BookResponseDTO>> UpdateBook(UpdateBookDTO requestDTO)
        {
            List<BookResponseDTO> books = new List<BookResponseDTO>();
            var client = _httpBase.HttpClient;
            var jsonRequest = JsonConvert.SerializeObject(requestDTO);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = client.PostAsync("updateBook", content).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                books = JsonConvert.DeserializeObject<List<BookResponseDTO>>(jsonResponse);

            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            return books;
        }

        /// <summary>
        /// The DeleteBook method sends a DELETE request to the server to delete a book.
        /// </summary>
        /// <param name="id">The ID of the book to be deleted.</param>
        /// <returns>A Task that represents the asynchronous operation. The task result contains a list of books.</returns>
        public async Task<List<BookResponseDTO>> DeleteBook(int id)
        {
            List<BookResponseDTO> books = new List<BookResponseDTO>();
            var client = _httpBase.HttpClient;
            var response = await client.DeleteAsync($"api/Books/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                books = JsonConvert.DeserializeObject<List<BookResponseDTO>>(jsonResponse);

            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            return books;
        }

        // placeholder methods for further versions of project
        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetUsersBooks(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
