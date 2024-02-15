using LibraryAPI.Repositories;
using LibraryData.Context;
using LibraryData.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly ReadersRepository _readersRepository;
        public ReadersController(LibraryDbContext context)
        {
            _context = context;
            _readersRepository = new ReadersRepository(context);
        }

        [HttpGet("/getReaders")]
        public async Task<ActionResult<IEnumerable<Reader>>> GetAllReaders()
        {
            return await _readersRepository.GetReadersAsync();
        }


        // POST api/<ReadersController>
        [HttpPost("/addReader")]
        async public Task<ActionResult<IEnumerable<Reader>>> AddReader( string firstName, string lastName,DateTime dateOfBirth)
        {
            Reader reader = new Reader()
            {
                FirstName = firstName, LastName = lastName, DateOfBirth = dateOfBirth
            };
            var readers = await _readersRepository.AddReader(reader);
            if (readers==null)
            {
                return NotFound();  
            }
            return Ok(readers);
        }

       

        // DELETE api/<ReadersController>/5
        [HttpDelete("/deleteReader/{id}")]
        public async Task<ActionResult<IEnumerable<Reader>>> DeleteReader(int id)
        {
            var readers = await _readersRepository.DeleteReader(id);
            if (readers == null)
            {
                return NotFound();
            }

            return  Ok(readers);
        }
    }
}
