using FITQUEST.Models;
using FITQUEST.Utils;

namespace FITQUEST.Repositories
{
    public class ChallenegeRepository : BaseRepository, IChallenegeRepository
    {
        public ChallenegeRepository(IConfiguration configuration) : base(configuration) { }


        public List<Challenge> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [id]
                                              ,[title]
                                              ,[tier]
                                          FROM [FITQUEST].[dbo].[Challenges]";
                    var reader = cmd.ExecuteReader();

                    var challenges = new List<Challenge>();
                    while (reader.Read())
                    {
                        challenges.Add(new Challenge()
                        {
                            id = DbUtils.GetInt(reader, "id"),
                            title = DbUtils.GetString(reader, "title"),
                            tier = DbUtils.GetInt(reader, "tier")
                        });
                    }

                    reader.Close();

                    return challenges;
                }
            }
        }

        public List<Challenge> GetAllByTier(int tier)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [id],[title],[tier]
                                          FROM [FITQUEST].[dbo].[Challenges]
                                          WHERE [tier] = @tier;";
                    cmd.Parameters.AddWithValue("@tier", tier);
                    var reader = cmd.ExecuteReader();
                    Challenge challenge = null;
                    List<Challenge> list = new List<Challenge>();
                    

                    while (reader.Read())
                    {
                        challenge = new Challenge()
                        {
                            id = DbUtils.GetInt(reader, "id"),
                            title = DbUtils.GetString(reader, "title"),
                            tier = DbUtils.GetInt(reader, "tier")
                        };
                        list.Add(challenge);
                    }

                    reader.Close();

                    return list;

                }
            }
        }

        public void Update(Challenge challenge) { }


    }
}
