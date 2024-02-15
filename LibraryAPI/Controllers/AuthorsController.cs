using LibraryAPI.Repositories;
using LibraryData.Context;
using LibraryData.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly AuthorsRepository _authorsRepository;
        public AuthorsController(LibraryDbContext context) 
        {
            _context = context;
            _authorsRepository= new AuthorsRepository(context);
        }
        // GET: api/Authors/getAuthors
        //[HttpGet("/getAuthors")]
        //public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
        //{
        //    return await _authorsRepository.GetAuhtorsAsync();
        //}

        //// GET api/<AuthorsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<AuthorsController>
        //[HttpPost("/addAuthor")]
        //async public Task<ActionResult<IEnumerable<Author>>> AddAuthor( string firstName, string lastName,DateTime dateOfBirth)
        //{
        //    Author author = new Author()
        //    {
        //        FirstName = firstName, LastName = lastName, DateOfBirth = dateOfBirth
        //    };
        //    var authors = await _authorsRepository.AddAuthor(author);
        //    if (authors==null)
        //    {
        //        return NotFound();  
        //    }
        //    return Ok(authors);
        //}

       

        //// DELETE api/<AuthorsController>/5
        //[HttpDelete("/deleteAuthor/{id}")]
        //public async Task<ActionResult<IEnumerable<Author>>> DeleteAuthor(int id)
        //{
        //    var authors = await _authorsRepository.DeleteAuthor(id);
        //    if (authors == null)
        //    {
        //        return NotFound();
        //    }

        //    return  Ok(authors);
        //}
    }
}
