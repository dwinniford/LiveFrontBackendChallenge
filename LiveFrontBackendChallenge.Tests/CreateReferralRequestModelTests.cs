using System.ComponentModel.DataAnnotations;
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
        Assert.True(validationResults.Any(v => v.MemberNames.Contains("ReferralCode") && v.ErrorMessage.Contains("minimum length")));


    }
}