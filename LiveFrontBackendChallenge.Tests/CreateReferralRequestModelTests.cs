using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using LiveFrontBackendChallenge.Models;
namespace LiveFrontBackendChallenge.Tests;

public class CreateReferralRequestModelTests
{
    [Fact]
    public void CreateReferralRequest_Model_RequiresFields()
    {
        var createReferralRequest = new CreateReferralRequest();
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(createReferralRequest, null, null);
        Validator.TryValidateObject(createReferralRequest, context, validationResults, true);
        validationResults.FirstOrDefault(v => v.MemberNames.Contains("ReferralCode")).Should().NotBeNull();
        validationResults.FirstOrDefault(v => v.MemberNames.Contains("ReferralCode"))?.ErrorMessage.Should().Contain("minimum length");
    }
}