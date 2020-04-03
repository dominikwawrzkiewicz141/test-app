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
    public class FilmsProxyController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly AppASettings _appASettings;

        public FilmsProxyController(IHttpClientFactory clientFactory, IOptions<AppASettings> appSettings)
        {
            _clientFactory = clientFactory;
            _appASettings = appSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync(_appASettings.FilmsUrl);

            return Ok(response.Content.ReadAsStringAsync().Result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddFilmModel model)
        {
            var client = _clientFactory.CreateClient();

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_appASettings.FilmsUrl, data);

            return Ok(response.Content.ReadAsStringAsync().Result);
        }
    }

    public class AddFilmModel
    {
        public string Title { get; set; }
    }
}