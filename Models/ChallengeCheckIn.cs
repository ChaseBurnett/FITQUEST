namespace FITQUEST.Models
{
    public class ChallengeCheckIn
    {
        public int id { get; set; }

        public DateTime? date { get; set; }

        public int userChallengesId {get; set;}

        public bool? successful { get; set;}

    }

    public class UserChallengeCheckIn
    {
        public string userName { get; set; }

        public string imgUrl { get; set; }

        public string title { get; set; }

        public DateTime? date { get; set; }

        public bool? successful { get; set; }

        public int id { get; set; }

        public int ccid { get; set; }

    }
}
