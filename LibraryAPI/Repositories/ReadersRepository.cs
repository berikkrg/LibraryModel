using LibraryData.Context;
using LibraryData.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    /// <summary>
    /// The ReadersRepository class provides methods for interacting with the readers in the database.
    /// </summary>
    public class ReadersRepository
    {
        private readonly LibraryDbContext _context;
        /// <summary>
        /// The constructor for the ReadersRepository class.
        /// </summary>
        /// <param name="context">The DbContext that represents the database.</param>
        public ReadersRepository(LibraryDbContext context) 
        {
            _context = context;
        }
        /// <summary>
        /// The GetReadersAsync method retrieves all readers from the database.
        /// </summary>
        /// <returns> a list of all readers.</returns>
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

        // <summary>
        /// The AddReader method adds a new reader to the database.
        /// </summary>
        /// <param name="reader">The reader object to be added.</param>
        /// <returns>a list of all readers after adding the new reader.</returns>
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
        /// <summary>
        /// The DeleteReader method deletes a reader from the database.
        /// </summary>
        /// <param name="id">The ID of the reader to be deleted.</param>
        /// <returns> a list of all readers after deleting the reader.</returns>
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
