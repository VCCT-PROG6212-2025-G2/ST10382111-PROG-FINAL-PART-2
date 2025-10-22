using CMCS.Services;
using CMCS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMCS.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly ClaimService _service;

        public CoordinatorController(ClaimService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var pendingClaims = _service.GetByStatus(ClaimStatus.Pending);
            return View(pendingClaims);
        }


        [HttpPost]
        public IActionResult Verify(Guid id, string action)
        {
            var claim = _service.Get(id);
            if (claim != null)
            {
                claim.Status = action == "verify" ? ClaimStatus.Verified : ClaimStatus.Rejected;
                _service.Update(claim);
            }
            return RedirectToAction("Index");
        }
    }
}
