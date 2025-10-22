using CMCS.Models;

namespace CMCS.Services
{
    public class ClaimService
    {
        private readonly List<Claim> _claims = new();

        public void Add(Claim claim)
        {
            claim.Id = Guid.NewGuid();
            claim.Status = ClaimStatus.Pending;
            claim.SubmittedAt = DateTime.Now;
            _claims.Add(claim);
        }

        public List<Claim> GetAll() => _claims;

        public Claim Get(Guid id) => _claims.FirstOrDefault(c => c.Id == id);

        public void Update(Claim updated)
        {
            var index = _claims.FindIndex(c => c.Id == updated.Id);
            if (index != -1)
                _claims[index] = updated;
        }

        public List<Claim> GetByStatus(ClaimStatus status) =>
            _claims.Where(c => c.Status == status).ToList();
    }
}
