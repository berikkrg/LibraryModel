using LibraryData.Context;
using LibraryData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LibraryAPI.Repositories
{
    public class AuthorsRepository
    {
        /// <summary>
        /// Dummy repository for further versions of projects
        /// </summary>
        private readonly LibraryDbContext _context;
        public AuthorsRepository(LibraryDbContext context)
        {
            _context = context;
        }

        //public async Task<List<Author>> GetAuhtorsAsync()
        //{
        //    try
        //    {
        //        return await _context.Authors.AsNoTracking().ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<List<Author>> AddAuthor(Author author)
        //{
        //    try
        //    {
        //        _context.Authors.Add(author); 
        //        await _context.SaveChangesAsync();  
                
                
        //        return await GetAuhtorsAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<List<Author>> DeleteAuthor(int id)
        //{
        //    try
        //    {
        //        var authorToRemove = _context.Authors.FirstOrDefault(x=>x.Id == id);
        //        if (authorToRemove!=null)
        //        {
        //            _context.Authors.Remove(authorToRemove);
        //            await _context.SaveChangesAsync(); 
        //            return await GetAuhtorsAsync();
        //        }

        //        return await _context.Authors.AsNoTracking().ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
