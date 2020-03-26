using System.Threading.Tasks;
using Db;
using Microsoft.AspNetCore.Mvc;

namespace AppB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly TestAppContext _context;

        public CarsController(TestAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(_context.Cars);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddCarModel model)
        {
            _context.Cars.Add(new Car
            {
                Model = model.Model
            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class AddCarModel
    {
        public string Model { get; set; }
    }
}