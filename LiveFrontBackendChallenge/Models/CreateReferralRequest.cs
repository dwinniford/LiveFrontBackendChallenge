using System.ComponentModel.DataAnnotations;

namespace LiveFrontBackendChallenge.Models
{
    public class CreateReferralRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ReferralCode { get; set; } = String.Empty;
        
    }
}