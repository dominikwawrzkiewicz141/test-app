using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AppA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsProxyController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly AppBSettings _appBSettings;

        public CarsProxyController(IHttpClientFactory clientFactory, IOptions<AppBSettings> appSettings)
        {
            _clientFactory = clientFactory;
            _appBSettings = appSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync(_appBSettings.CarsUrl);

            return Ok(response.Content.ReadAsStringAsync().Result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddCarModel model)
        {
            var client = _clientFactory.CreateClient();

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_appBSettings.CarsUrl, data);

            return Ok(response.Content.ReadAsStringAsync().Result);
        }
    }

    public class AddCarModel
    {
        public string Model { get; set; }
    }
}