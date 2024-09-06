namespace LiveFrontBackendChallenge.Models
{
    public class ReferralDto
    {
        public int ReferralId { get; set; }
        public int UserId { get; set; }
        public string ReferralCode { get; set; } = String.Empty;
        public string DeferredLink { get; set; } = String.Empty;
        public bool Activated { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }
}