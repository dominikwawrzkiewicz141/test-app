using System.Threading.Tasks;
using Db;
using Microsoft.AspNetCore.Mvc;

namespace AppA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly TestAppContext _context;

        public FilmsController(TestAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(_context.Films);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddFilmModel model)
        {
            _context.Films.Add(new Film
            {
                Title = model.Title
            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class AddFilmModel
    {
        public string Title { get; set; }
    }
}