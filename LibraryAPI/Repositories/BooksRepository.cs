using LibraryData.Context;
using LibraryData.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace LibraryAPI.Repositories
{
    /// <summary>
    /// The BooksRepository class provides methods for interacting with the books entity in the database.
    /// </summary>
    public class BooksRepository
    {
        private readonly LibraryDbContext _context;

        /// <summary>
        /// The constructor for the BooksRepository class.
        /// </summary>
        /// <param name="context">The DbContext that represents the database.</param>
        public BooksRepository(LibraryDbContext context)
        {
            _context = context;
        }

        // <summary>
        /// The GetBooksAsync method retrieves all books from the database.
        /// </summary>
        /// <returns>a list of all books.</returns>
        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {   
                var books =  await _context.Books.AsNoTracking().ToListAsync();

                foreach (var book in books)
                {
                    //book.Author = await _context.Authors.FindAsync(book.AuthorId);
                    book.Category = await _context.Categories.FindAsync(book.CategoryId);
                }
                return books;
            }
            catch (Exception ex )
            {
                throw new Exception( ex.Message);
            }
        }

        /// <summary>
        /// The GetBooksByAuthor method retrieves books by a specific author from the database.
        /// </summary>
        /// <param name="authorName">The name of the author to find his books in database.</param>
        /// <returns>result contains a list of books by the specified author.</returns>
        public async Task<List<Book>>GetBooksByAuthor(string authorName)
        {
            try
            {
                return await _context.Books.AsNoTracking().Where(x=>x.AuthorName==authorName).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// The GetBooksByReader method retrieves books loaned by a specific reader from the database.
        /// </summary>
        /// <param name="readerId">The ID of the reader.</param>
        /// <returns>the result contains a list of books owned by the exact reader.</returns>
        public async Task<List<Book>> GetBooksByReader(int readerId)
        {
            try
            {
                return await _context.Books.AsNoTracking().Where(x => x.ReaderId == readerId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// The GetBooksByCategory method retrieves books that has a specified category from the database.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>the result contains a list of books with specific category.</returns>
        public async Task<List<Book>> GetBooksByCategory(int categoryId)
        {
            try
            {
                return await _context.Books.AsNoTracking().Where(x => x.CategoryId== categoryId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// The GetBookById method retrieves exact book by id
        /// </summary>
        /// <param name="bookId">The ID of the book to retrieve.</param>
        /// <returns>the books with a specific id.</returns>
        public async Task<Book> GetBookById(int bookId)
        {
            try
            {
                return await _context.Books.AsNoTracking().FirstAsync(x=>x.Id==bookId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// The UpdateBook method updates a book's details in the database.
        /// </summary>
        /// <param name="bookId">The ID of the book to be updated.</param>
        /// <param name="book">The book object containing the new details of the book.</param>
        /// <returns>a list of all books after updating the book.</returns>
        public async Task<List<Book>>UpdateBook(int bookId, Book book)
        {
            try
            {
                var bookToUpdate = await _context.Books.AsNoTracking().FirstAsync(x => x.Id == bookId);
                if (bookToUpdate != null)
                {
                    if (book.IsAvailable != bookToUpdate.IsAvailable)
                    {
                        bookToUpdate.IsAvailable = book.IsAvailable;
                    }
                    if (book.ReturnDate!=bookToUpdate.ReturnDate)
                    {
                        bookToUpdate.ReturnDate = book.ReturnDate;
                    }
                    if (book.YearOfIssue!=bookToUpdate.YearOfIssue)
                    {
                        bookToUpdate.YearOfIssue = book.YearOfIssue;
                    }
                    if (book.ReaderId!=bookToUpdate.ReaderId)
                    {
                        bookToUpdate.ReaderId = book.ReaderId;
                    }
                    if (book.CategoryId != bookToUpdate.CategoryId)
                    {
                        bookToUpdate.CategoryId = book.CategoryId;
                    }
                    if (book.AuthorName==bookToUpdate.AuthorName)
                    {
                        bookToUpdate.AuthorName = book.AuthorName;
                    }
                    if (book.Title!=bookToUpdate.Title)
                    {
                        bookToUpdate.Title = book.Title;
                    }
                }
                _context.Books.Update(bookToUpdate);
                await _context.SaveChangesAsync();
                return await GetBooksAsync();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// The DeleteBook method deletes a book from the database.
        /// </summary>
        /// <param name="bookId">The ID of the book to be deleted.</param>
        /// <returns>a list of all books after deleting the book.</returns>
        public async Task<List<Book>> DeleteBook(int bookId)
        {
            try
            {
                var bookToDelete = await _context.Books.AsNoTracking().FirstAsync(x => x.Id == bookId);
                _context.Books.Remove(bookToDelete);
                await _context.SaveChangesAsync();
                return await GetBooksAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// The AddBookAsync method adds a new book to the database.
        /// </summary>
        /// <param name="book">The book object to be added.</param>
        /// <returns> a list of all books after adding the new book.</returns>
        public async Task<List<Book>>AddBookAsync(Book book)
        {
            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return await GetBooksAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
    }
}
