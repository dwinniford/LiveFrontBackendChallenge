using LiveFrontBackendChallenge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiveFrontBackendChallenge
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ReferralController: ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateReferral(CreateReferralRequest createReferralRequest) {

            var referral  = await Task.FromResult<ReferralDto>(new ReferralDto
            {
                ReferralId = 1,
                UserId = createReferralRequest.UserId,
                ReferralCode = createReferralRequest.ReferralCode,
                DeferredLink = "somelink.com",
                Activated = false

            });
            return Ok(referral);
        }
    }
}