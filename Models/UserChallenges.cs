namespace FITQUEST.Models
{
    public class UserChallenges
    {
        public int id { get; set; }

        public int userId { get; set; }

        public User? User { get; set; }

        public int challengeId { get; set; }

        public Challenge? Challenge { get; set; }

        public bool? achieved { get; set; } 

    }
}
