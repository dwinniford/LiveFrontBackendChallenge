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
        public Task<ReferralDto> CreateReferral(CreateReferralRequest createReferralRequest) {
            
            
            throw new NotImplementedException();
        }
    }
}