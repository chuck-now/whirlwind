using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ayo.API.Controllers
{
    /// <summary>
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return Redirect("swagger");
        }

        [HttpGet]
        [Route("swagger-gen")]
        public async Task<ActionResult> GenerateSwaggerDocs()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"http://{Request.Host}/swagger/v1/swagger.json");
            var content = await response.Content.ReadAsStringAsync();

            if (content.IsNotEmpty())
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles\\swagger\\v1\\swagger.json");

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);

                    using FileStream fs = new FileStream(filePath, FileMode.CreateNew);
                    byte[] data = Encoding.UTF8.GetBytes(content);

                    fs.Write(data, 0, data.Length);
                }
            }
            return new ContentResult();
        }
    }
}