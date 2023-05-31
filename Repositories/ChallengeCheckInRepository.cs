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
                    cmd.CommandText = @"SELECT  C.id,
                                                U.userName,
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
                            id = DbUtils.GetInt(reader, "id"),
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

        public ChallengeCheckIn Add(ChallengeCheckIn challengeCheckIn)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [FITQUEST].[dbo].[challengeCheckIn] 
                                        ([date],[userChallengesId],[successful])
                                        OUTPUT inserted.id
                                        VALUES (@date, @userChallengesId, @successful)
                                        ;";
                    cmd.Parameters.AddWithValue("@date", challengeCheckIn.date);
                    cmd.Parameters.AddWithValue("@userChallengesId", challengeCheckIn.userChallengesId);
                    cmd.Parameters.AddWithValue("@successful", challengeCheckIn.successful);
                    challengeCheckIn.id = (int)cmd.ExecuteScalar();
                    return challengeCheckIn;
                }
            }
        }

        public void Update(ChallengeCheckIn challengeCheckIn, int id) 
        {   
            using (var conn = Connection)
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [FITQUEST].[dbo].[challengeCheckIn] 
                                        SET date = @date, userChallengesId = @userChallengesId, successful = @successful
                                        WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@date",challengeCheckIn.date);
                    cmd.Parameters.AddWithValue("@userChallengesId", challengeCheckIn.userChallengesId);
                    cmd.Parameters.AddWithValue("@successful", challengeCheckIn.successful);
                    cmd.ExecuteScalar();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE [FITQUEST].[dbo].[challengeCheckIn] WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                } 
            }
        }

    }
}
