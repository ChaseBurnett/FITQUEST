using FITQUEST.Models;
using FITQUEST.Utils;

namespace FITQUEST.Repositories
{
    public class ChallengeCheckInRepository : BaseRepository, IChallengeCheckInRepository
    {
        public ChallengeCheckInRepository(IConfiguration configuration) : base(configuration) { }

        public List<UserChallengeCheckIn> GetAllByUserId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT U.userName,
		                                        U.imgUrl,
		                                        C.title,
		                                        C.tier,
		                                        CCI.date,
		                                        CCI.successful

		                                        FROM challengeCheckIn CCI

		                                        JOIN userChallenges UC
		                                        ON UC.id = CCI.userChallengesId

		                                        JOIN [User] U
		                                        ON UC.userId = U.id

		                                        JOIN Challenges C
		                                        ON UC.challengeId = C.id

		                                        WHERE U.id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    List<UserChallengeCheckIn> challengeCheckIns = new List<UserChallengeCheckIn>();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UserChallengeCheckIn challengeCheck = new UserChallengeCheckIn()
                        {
                            userName = DbUtils.GetString(reader, "userName"),
                            imgUrl = DbUtils.GetString(reader, "imgUrl"),
                            title = DbUtils.GetString(reader, "title"),
                            date = DbUtils.GetDateTime(reader, "date"),
                            successful = DbUtils.GetNullableBool(reader, "successful")
                        };
                        challengeCheckIns.Add(challengeCheck);
                    };
                    reader.Close();
                    return challengeCheckIns;
                }
            }
        }

    }
}
