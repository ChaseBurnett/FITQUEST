using FITQUEST.Models;
using FITQUEST.Utils;
using System.Security.Cryptography;


namespace FITQUEST.Repositories
{
    public class UserChallengesRepository : BaseRepository, IUserChallengesRepository
    {
        public UserChallengesRepository(IConfiguration configuration) : base(configuration) { }

        public UserChallenges GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT [id],[userId],[challengeId],[achieved]
                                        FROM [FITQUEST].[dbo].[userChallenges]
                                        WHERE id = @id;";
                    cmd.Parameters.AddWithValue("id", id);
                    var reader = cmd.ExecuteReader();
                    UserChallenges uc = null;
                    if (reader.Read())
                    {
                        uc = new UserChallenges()
                        {
                            id = DbUtils.GetInt(reader, "id"),
                            userId = DbUtils.GetInt(reader, "userId"),
                            challengeId = DbUtils.GetInt(reader, "challengeId"),
                            achieved = DbUtils.GetNullableBool(reader, "achieved")
                        };
                    }
                    reader.Close();
                    return uc;

                }
            }
        }

        public UserChallenges Add(UserChallenges userChallenges)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [userChallenges] (userId,challengeId,achieved)
                                      OUTPUT INSERTED.id
                                      VALUES (@userId,@challengeId,@achieved);";
                    cmd.Parameters.AddWithValue("@userId", userChallenges.userId);
                    cmd.Parameters.AddWithValue("@challengeId", userChallenges.challengeId);
                    cmd.Parameters.AddWithValue("@achieved", userChallenges.achieved);
                    userChallenges.id = (int)cmd.ExecuteScalar();
                    return userChallenges;
                }
            }
        }

        public void Update(UserChallenges userChallenges)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [userChallenges]
                                          SET achieved = @achieved
                                          WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id",userChallenges.id);
                    cmd.Parameters.AddWithValue("@achieved", userChallenges.achieved);
                    cmd.ExecuteNonQuery();
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
                    cmd.CommandText = @"DELETE FROM [FITQUEST].[dbo].[userChallenges] WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
