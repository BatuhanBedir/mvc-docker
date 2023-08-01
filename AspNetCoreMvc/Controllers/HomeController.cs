using AspNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;

namespace AspNetCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IFileProvider _fileProvider;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IFileProvider fileProvider, IConfiguration configuration)
        {
            _logger = logger;
            _fileProvider = fileProvider;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.MySqlCon = _configuration["MySqlCon"];
            //ilk önce ENV'den kontrol eder böyle bir değişken var mı yoksa appsettings'e bakar.
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ImageShow()
        {
            var images = _fileProvider.GetDirectoryContents("wwwroot/images").ToList().Select(x => x.Name);

            return View(images);
        }

        [HttpPost]
        public IActionResult ImageShow(string name)
        {
            var file = _fileProvider.GetDirectoryContents("wwwroot/images").ToList().First(x => x.Name == name);
            System.IO.File.Delete(file.PhysicalPath);
            return RedirectToAction("ImageShow");
        }

        [HttpGet]
        public IActionResult ImageSave()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ImageSave(IFormFile imageFile)
        {
            if (imageFile is not null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}