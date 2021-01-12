using EmailForms.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmailForms.DAL
{
    public class UserRepository
    {
        private MailRepository _mailRepository;
        private string _connectionString;
        
        public UserRepository(MailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }
        public void Init(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<User> Get(Guid id)
        {
            User user = default;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM USERS WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("UserId", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        var userId = reader.GetGuid(0);
                        var username = reader.GetString(1);
                        var passwordHash = reader.GetString(2);
                        user = new User
                        {
                            UserId = userId,
                            Username = username,
                            PasswordHash = passwordHash
                        };
                        break;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return user;
        }

        public async Task<User> Get(string name)
        {
            User user = default;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM USERS WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("Username", name);
                try
                {
                    connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        var userId = reader.GetGuid(0);
                        var username = reader.GetString(1);
                        var passwordHash = reader.GetString(2);
                        user = new User
                        {
                            UserId = userId,
                            Username = username,
                            PasswordHash = passwordHash,
                            Mails = (await _mailRepository.GetAll(userId)).ToList()
                        };
                        break;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return user;
        }

        public async Task Create(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO USERS (UserId, Username, PasswordHash) VALUES(@UserId, @Username, @PasswordHash)", connection);
                command.Parameters.AddWithValue("UserId", user.UserId);
                command.Parameters.AddWithValue("Username", user.Username);
                command.Parameters.AddWithValue("PasswordHash", user.PasswordHash);
                try
                {
                    connection.Open();
                    var reader = await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public async Task Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE USERS SET Username = @Username, PasswordHash = @PasswordHash WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("UserId", user.UserId);
                command.Parameters.AddWithValue("Username", user.Username);
                command.Parameters.AddWithValue("PasswordHash", user.PasswordHash);
                try
                {
                    connection.Open();
                    var reader = await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public async Task Delete(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM USERS WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("UserId", id);
                try
                {
                    connection.Open();
                    var reader = await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
