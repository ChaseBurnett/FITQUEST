using FITQUEST.Models;
using FITQUEST.Utils;


namespace FITQUEST.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public User AddUser(User userDetails)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [User](
                                      [userName]
                                      , [email]
                                      , [imgUrl])
	                                  OUTPUT inserted.id
	                                  VALUES
	                                  (@userName
                                      , @email
                                      , @imgUrl);";
                    DbUtils.AddParameter(cmd, "@userName", userDetails.userName);
                    DbUtils.AddParameter(cmd, "@email", userDetails.email);
                    DbUtils.AddParameter(cmd, "@imgUrl", userDetails.imgUrl);

                    userDetails.id = (int)cmd.ExecuteScalar();
                    return userDetails;
                }
            }
        }

        public User GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [id], [userName], [email], [imgUrl]
                                        FROM [FITQUEST].[dbo].[User]
                                        WHERE id = @id;";
                    cmd.Parameters.AddWithValue("id", id);
                    var reader = cmd.ExecuteReader();
                    User user = null;

                    if(reader.Read())
                    {
                        user = new User()
                        {
                            id = DbUtils.GetInt(reader, "id"),
                            userName = DbUtils.GetString(reader, "username"),
                            email = DbUtils.GetString(reader, "email"),
                            imgUrl = DbUtils.GetString(reader, "imgUrl"),
                        };
                    }
                    reader.Close();
                    return user;
                }
            }
        }

        public void DeleteUser(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Delete FROM [FITQUEST].[dbo].[User] where id = @id";
                    DbUtils.AddParameter(cmd, "id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(User userDetails)
        {
            using (var conn = Connection) 
            { 
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [FITQUEST].[dbo].[User]
                                        SET [userName] = @userName,
	                                        [email] = @email,
	                                        [imgUrl] = @imgUrl
                                        WHERE id = @id;";
                    DbUtils.AddParameter(cmd, "@userName", userDetails.userName);
                    DbUtils.AddParameter(cmd, "@email", userDetails.email);
                    DbUtils.AddParameter(cmd, "@imgUrl", userDetails.imgUrl);
                    DbUtils.AddParameter(cmd, "@id", userDetails.id);

                    cmd.ExecuteNonQuery();
                }
            
            }
        }

    }
}
