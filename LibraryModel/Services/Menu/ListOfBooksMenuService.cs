using InfrastructureData.DTOs;
using LibraryModel.Services.Books;
using LibraryModel.Source.Interfaces;
using LibraryModel.Source.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Services.Menu
{
    public class ListOfBooksMenuService : BaseMenuService
    {
        private BooksService _booksService;
        private List<BookResponseDTO> _books = new List<BookResponseDTO>();
        public ListOfBooksMenuService()
        {
            _booksService = new BooksService();
            Console.WriteLine("Библиотека\\Список книг\n" +
                       "_____________________________________________\n");
            var myTask = ShowListOfBooks();
            myTask.Wait();
            MenuText = "ОБНОВЛЕНИЕ ДАННЫХ ПО БИБЛИОТЕКЕ\n" +
                       "\tВыберите операцию:\n" +
                       "\t1. Добавить книгу\n" +
                       "\t2. Удалить книгу\n" +
                       "\t3. Исправить данные по книге\n" +
                       "\t4. Отсортировать по названию\n" +
                       "\t5. Отсортировать по году выпуска\n" +
                       "\t6. Вернуться в главное меню\n";
            AmountOfMenuItems = 6;
            DrawMenu();
            CheckMenuInput();
            Navigate();
        }

        private async Task ShowListOfBooks()
        {
            Console.WriteLine("\tId\t|Name\t\t\t|Year\t|Author\t\t\t|Is Available\t|Return Date");
            Console.WriteLine("________________________________________________________________________________________________________");

            _books = await _booksService.GetAllBooks();

            foreach (var book in _books)
            {
                string availability = book.IsAvailable ? "Yes" : "No";
                string returnDate = "";
                if (book.ReturnDate!=null)
                {
                    returnDate = book.ReturnDate.GetValueOrDefault().ToShortDateString();
                }
                else
                {
                    returnDate = "--";
                }    
                Console.WriteLine($"\t{book.Id}\t|{book.Title.PadRight(20)}\t|{book.YearOfIssue}\t|{book.AuthorName.PadRight(20)}\t|{availability.PadRight(20)}\t|{returnDate}");
            }

            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine();

        }

        protected override async void Navigate()
        {
            if (Choice == 1)
            {
                AddBookRequestDTO request = new AddBookRequestDTO();
                CheckBookInputs(request);
                _books = await _booksService.AddBooks(request);
                if (_books != null)
                {
                    Console.Clear();
                    await ShowListOfBooks();
                    Console.WriteLine("Книга успешно добавлена");
                    DrawMenu();
                    CheckMenuInput();
                    Navigate();
                }

            }
            else if (Choice == 2)
            {
                Console.WriteLine("\nВведите Id книги");
                //TODO: validate input
                int id = int.Parse(Console.ReadLine());
               _books = await _booksService.DeleteBook(id);
                if (_books != null)
                {
                    Console.Clear();
                    await ShowListOfBooks();
                    Console.WriteLine("Книга успешно удалена");
                    DrawMenu();
                    CheckMenuInput();
                    Navigate();
                }
            }
            else if (Choice==3)
            {
                UpdateBookDTO update = new UpdateBookDTO();
                CheckUpdateBookInputs(update);
                _books = await _booksService.UpdateBook(update);
                if (_books != null)
                {
                    Console.Clear();
                    await ShowListOfBooks();
                    Console.WriteLine("Книга вручена пользователю.");
                    DrawMenu();
                    CheckMenuInput();
                    Navigate();
                }
            }
            else if (Choice == 4)
            {
                if (_books!=null)
                {
                    _books.OrderBy(x => x.Title);
                    Console.Clear();
                    var myTask = ShowListOfBooks();
                    myTask.Wait();
                    Console.WriteLine("Список отсортирован по названию");
                    DrawMenu();
                    CheckMenuInput();
                    Navigate();
                }
            }
            else if (Choice==5)
            {
                if (_books != null)
                {
                    _books.OrderBy(x => x.YearOfIssue);
                    Console.Clear();
                    var myTask = ShowListOfBooks();
                    myTask.Wait();
                    Console.WriteLine("Список отсортирован по году выпуска");
                    DrawMenu();
                    CheckMenuInput();
                    Navigate();
                }
            }
            else if (Choice==6)
            {
                Console.Clear();
                MainMenuService mainMenuService = new MainMenuService();
            }



            base.Navigate();
            //}
        }

        private void CheckBookInputs(AddBookRequestDTO request)
        {
            Console.WriteLine("Введите название книги");
            request.Title = Console.ReadLine();
            Console.WriteLine("Введите автора книги");
            request.AuthorName = Console.ReadLine();
            Console.WriteLine("Введите год выпуска книги");
            //TODO Validation of year
            int year = int.Parse(Console.ReadLine());
            request.YearOfIssue = year;
            Console.WriteLine("Выберите категорию книги: 1 -Antiutopy 2 - Fantasy  3 - Classical 4 - Detective 5 - Non-fiction 6 - Other ");
            //TODO Validation of category
            int category = int.Parse(Console.ReadLine());
            request.CategoryId = category;

        }

        private void CheckUpdateBookInputs(UpdateBookDTO request)
        {
            request.Id = ChooseBookToGive();
            BookResponseDTO choosenBook = _books.FirstOrDefault(x => x.Id == request.Id);
            if(!choosenBook.IsAvailable)
            {
                do
                {
                    Console.WriteLine("Выбранная книга уже выдана");
                    
                    request.Id=ChooseBookToGive();
                    choosenBook = _books.FirstOrDefault(x => x.Id == request.Id);
                }
                while (!choosenBook.IsAvailable);
            }
            //TODO: by default, after realising readerService add method to choose reader
            request.ReaderId = 1;
            request.ReturnDate = DateTime.Now.AddDays(30);
            request.IsAvailable = false;
            request.YearOfIssue = choosenBook.YearOfIssue;
            request.AuthorName = choosenBook.AuthorName;
            request.CategoryId = choosenBook.CategoryId;    
            request.Title = choosenBook.Title;

        }

        private int ChooseBookToGive()
        {
            Console.WriteLine("Выберите книгу");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

    }
}
