using FITQUEST.Models;
using FITQUEST.Utils;

namespace FITQUEST.Repositories
{
    public class LeaderBoardRepository : BaseRepository, ILeaderBoardRepository
    {
        public LeaderBoardRepository(IConfiguration configuration) : base(configuration) { }

        public List<Leaders> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        SELECT u.userName, c.title, COUNT(cc.id) AS checkIns, 
                                               MAX(CASE WHEN cc.successful = 1 THEN 1 ELSE 0 END) AS successful
                                        FROM [User] u
                                        JOIN userChallenges uc ON u.id = uc.userId
                                        JOIN Challenges c ON uc.challengeId = c.id
                                        JOIN leaderBoard lb ON c.id = lb.challengeId
                                        LEFT JOIN challengeCheckIn cc ON uc.id = cc.userChallengesId
                                        GROUP BY u.userName, c.title;
                                        ";
                    var reader = cmd.ExecuteReader();

                    var leaders = new List<Leaders>();
                    while (reader.Read())
                    {
                        leaders.Add(new Leaders()
                        {
                            userName = DbUtils.GetString(reader, "username"),
                            title = DbUtils.GetString(reader, "title"),
                            checkIns = DbUtils.GetInt(reader, "checkIns"),
                            successful = reader.IsDBNull(reader.GetOrdinal("successful")) ? null : (bool?)(reader.GetInt32(reader.GetOrdinal("successful")) == 1),
                        });
                    }
                    reader.Close();

                    return leaders;
                }
            }

        }
    }
}
