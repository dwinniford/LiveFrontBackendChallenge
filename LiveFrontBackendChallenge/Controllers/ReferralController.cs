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
        private readonly IDeferredLinkService deferredLinkService;
        private readonly IReferralService referralService;

        public ReferralController(IUserService userService, IDeferredLinkService deferredLinkService, IReferralService referralService)
        {
            this.userService = userService;
            this.deferredLinkService = deferredLinkService;
            this.referralService = referralService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateReferral(CreateReferralRequest createReferralRequest) {

            // look up user from mock user repository
            User? user = await userService.GetUser(createReferralRequest.UserId);
            if (user == null) {
                return NotFound($"User not found for userId {createReferralRequest.UserId}");
            };
            if (user.ReferralCode != createReferralRequest.ReferralCode)
            {
                return BadRequest("User id or Referral code is incorrect");
            }
            if(createReferralRequest.Phone.Length == 0 && createReferralRequest.Email.Length == 0)
            {
                return BadRequest("Phone or email is required");
            }
            // Get Deferred link from mock http service.
            var deferredLink = await deferredLinkService.GetDeferredLink(createReferralRequest.ReferralCode);
            // save referral in mock repository
            var referral = await referralService.CreateReferral(
                createReferralRequest.UserId, 
                createReferralRequest.ReferralCode, 
                deferredLink, 
                createReferralRequest.Name,
                createReferralRequest.Phone,
                createReferralRequest.Email
            );

            return Ok(referral);
        }
    }
}