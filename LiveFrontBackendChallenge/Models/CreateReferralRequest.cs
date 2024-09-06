using System.ComponentModel.DataAnnotations;

namespace LiveFrontBackendChallenge.Models
{
    public class CreateReferralRequest
    {
        [Required]
        public int UserId { get; set; }
        [MinLength(6)]
        public string ReferralCode { get; set; } = String.Empty;
        [MinLength(3)]
        public string Name { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        
    }
}