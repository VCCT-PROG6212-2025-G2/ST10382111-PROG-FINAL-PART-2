using CMCS.Services;
using Microsoft.AspNetCore.Mvc;
using CMCS.Models;

namespace CMCS.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly ClaimService _service;
        private readonly IWebHostEnvironment _env;

        public ClaimsController(ClaimService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        public IActionResult Index() => RedirectToAction("Submit");

        public IActionResult Submit() => View();

        [HttpPost]
        public async Task<IActionResult> Submit(Claim claim, IFormFile document)
        {
            if (!ModelState.IsValid)
                return View(claim);

            if (document != null)
            {
                var ext = Path.GetExtension(document.FileName);
                var allowed = new[] { ".pdf", ".docx", ".xlsx" };
                if (!allowed.Contains(ext.ToLower()) || document.Length > 2_000_000)
                {
                    ModelState.AddModelError("Document", "Invalid file type or size.");
                    return View(claim);
                }

                var fileName = $"{Guid.NewGuid()}{ext}";
                var path = Path.Combine(_env.WebRootPath, "uploads", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                await document.CopyToAsync(stream);
                claim.DocumentName = fileName;
            }

            // ✅ Store the claim with metadata
            _service.Add(claim);
            return RedirectToAction("Track");
        }

      
        public IActionResult Track()
        {
            var claims = _service.GetAll();
            return View(claims);
        }
    }
}
