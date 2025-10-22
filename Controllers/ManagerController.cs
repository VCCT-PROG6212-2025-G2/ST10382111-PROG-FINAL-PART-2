using CMCS.Services;
using CMCS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMCS.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ClaimService _service;

        public ManagerController(ClaimService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var verifiedClaims = _service.GetByStatus(ClaimStatus.Verified);
            return View(verifiedClaims);
        }


        [HttpPost]
        public IActionResult Approve(Guid id, string action)
        {
            var claim = _service.Get(id);
            if (claim != null)
            {
                claim.Status = action == "approve" ? ClaimStatus.Approved : ClaimStatus.Rejected;
                _service.Update(claim);
            }
            return RedirectToAction("Index");
        }
    }
}
