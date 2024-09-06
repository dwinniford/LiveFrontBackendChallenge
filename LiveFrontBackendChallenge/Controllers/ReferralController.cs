using LiveFrontBackendChallenge.Models;
using LiveFrontBackendChallenge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiveFrontBackendChallenge.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ReferralController: ControllerBase
    {
        private readonly IUserService userService;

        public ReferralController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateReferral(CreateReferralRequest createReferralRequest) {

            // look up user from mock user service and return 404 if not found. return 400 if referral code does not match users referral code
            User? user = await userService.GetUser(createReferralRequest.UserId);
            if (user == null) {
                return NotFound($"User not found for userId {createReferralRequest.UserId}");
            };
            if (user.ReferralCode != createReferralRequest.ReferralCode)
            {
                return BadRequest("User id or Referral code is incorrect");
            }
            // Get Deferred link from mock service.  input referral code

            // save referral in mock store

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