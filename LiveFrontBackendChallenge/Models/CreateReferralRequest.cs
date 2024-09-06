using System.ComponentModel.DataAnnotations;

namespace LiveFrontBackendChallenge.Models
{
    public class CreateReferralRequest
    {
        [Required]
        public int UserId { get; set; }
        [MinLength(6)]
        public string ReferralCode { get; set; } = String.Empty;
        
    }
}