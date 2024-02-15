using LibraryData.Context;
using LibraryData.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class ReadersRepository
    {
        private readonly LibraryDbContext _context;
        public ReadersRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Reader>> GetReadersAsync()
        {
            try
            {
                return await _context.Readers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Reader>> AddReader(Reader reader)
        {
            try
            {
                _context.Readers.Add(reader);
                await _context.SaveChangesAsync();


                return await GetReadersAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Reader>> DeleteReader(int id)
        {
            try
            {
                var readerToRemove = _context.Readers.FirstOrDefault(x => x.Id == id);
                if (readerToRemove != null)
                {
                    _context.Readers.Remove(readerToRemove);
                    await _context.SaveChangesAsync();
                    
                }
                return await GetReadersAsync();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
