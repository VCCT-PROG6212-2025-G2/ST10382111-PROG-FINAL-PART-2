using Xunit;
using CMCS.Models;
using CMCS.Services;
using System;
using System.Linq;

namespace CMCS.Tests
{
    public class ClaimServiceTests
    {
        [Fact]
        public void AddClaim_ShouldStoreClaimWithMetadata()
        {
            // Arrange
            var service = new ClaimService();
            var claim = new Claim
            {
                LecturerName = "Khumo",
                HoursWorked = 10,
                HourlyRate = 200,
                Notes = "Test claim"
            };

            // Act
            service.Add(claim);
            var stored = service.GetAll().FirstOrDefault();

            // Assert
            Assert.NotNull(stored);
            Assert.Equal("Khumo", stored.LecturerName);
            Assert.Equal(ClaimStatus.Pending, stored.Status);
            Assert.NotEqual(Guid.Empty, stored.Id);
            Assert.True(stored.SubmittedAt > DateTime.MinValue);
        }

        [Fact]
        public void GetByStatus_ShouldReturnOnlyMatchingClaims()
        {
            // Arrange
            var service = new ClaimService();
            var pending = new Claim { LecturerName = "A", HoursWorked = 5, HourlyRate = 100, Notes = "Pending" };
            var verified = new Claim { LecturerName = "B", HoursWorked = 8, HourlyRate = 150, Notes = "Verified" };

            service.Add(pending);
            service.Add(verified);

            verified.Status = ClaimStatus.Verified;
            service.Update(verified);

            // Act
            var result = service.GetByStatus(ClaimStatus.Verified);

            // Assert
            Assert.Single(result);
            Assert.Equal("B", result[0].LecturerName);
        }

        [Fact]
        public void Update_ShouldModifyExistingClaim()
        {
            // Arrange
            var service = new ClaimService();
            var claim = new Claim { LecturerName = "C", HoursWorked = 6, HourlyRate = 120, Notes = "Initial" };
            service.Add(claim);

            var stored = service.GetAll().First();
            stored.Notes = "Updated";

            // Act
            service.Update(stored);
            var updated = service.Get(stored.Id);

            // Assert
            Assert.Equal("Updated", updated.Notes);
        }
    }
}
