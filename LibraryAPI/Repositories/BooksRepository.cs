using LibraryData.Context;
using LibraryData.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace LibraryAPI.Repositories
{
    public class BooksRepository
    {
        private readonly LibraryDbContext _context;

        public BooksRepository(LibraryDbContext context)
        {
            _context = context;
        }

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
