namespace FITQUEST.Models
{
    public class Leaderboard
    {
        public int id { get; set; }

        public int challengeId { get; set; }
    }

    public class Leaders
    {
        public int id { get; set; }

        public string userName { get; set; }

        public string title { get; set; }

        public int checkIns { get; set; }

        public bool? successful { get; set; }
    }
}
