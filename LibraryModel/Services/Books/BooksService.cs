using InfrastructureData.DTOs;
using InfrastructureData.Http;
using LibraryModel.Source.Interfaces;
using LibraryModel.Source.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Services.Books
{
    public class BooksService:IBookRepository
    {
        private HttpBase _httpBase;   
        public BooksService() 
        {
            _httpBase = new HttpBase();
        }

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


        public async Task<List<BookResponseDTO>> AddBooks(AddBookRequestDTO requestDTO)
        {
            List<BookResponseDTO> books = new List<BookResponseDTO>();
            //var response = _httpBase.HttpClient.GetAsync("getAllBooks");
            var client = _httpBase.HttpClient;
            var request = new AddBookRequestDTO() { AuthorName = requestDTO.AuthorName, CategoryId = requestDTO.CategoryId, Title = requestDTO.Title, IsAvailable=true, ReaderId = null, ReturnDate = null, YearOfIssue = requestDTO.YearOfIssue};
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            // Отправка POST-запроса
            var response = client.PostAsync("addBook", content).Result;


            

            //var response = await client.GetAsync("getAllBooks");

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

        public async Task<List<BookResponseDTO>> UpdateBook(UpdateBookDTO requestDTO)
        {
            List<BookResponseDTO> books = new List<BookResponseDTO>();
            //var response = _httpBase.HttpClient.GetAsync("getAllBooks");
            var client = _httpBase.HttpClient;
            var jsonRequest = JsonConvert.SerializeObject(requestDTO);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            // Отправка POST-запроса
            var response = client.PostAsync("updateBook", content).Result;




            //var response = await client.GetAsync("getAllBooks");

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


        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        //public List<Book> GetBooks()
        //{
           
        //}

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
