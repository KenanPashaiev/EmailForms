using EmailForms.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EmailForms.DAL
{
    public class MailRepository
    {
        private string _connectionString;

        public void Init(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Mail> Get(Guid id)
        {
            Mail mail = default;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM MAILS WHERE MailId = @MailId", connection);
                command.Parameters.AddWithValue("MailId", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        var mailId = reader.GetGuid(0);
                        var name = reader.GetString(1);
                        var server = reader.GetString(2);
                        var password = reader.GetString(3);
                        mail = new Mail
                        {
                            Id = mailId,
                            EncryptedName = name,
                            EncryptedServer = server,
                            EncryptedPassword = password
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

            return mail;
        }

        public async Task<IEnumerable<Mail>> GetAll(Guid userId)
        {
            var mails = new List<Mail>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM MAILS WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("UserId", userId);
                try
                {
                    connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        var mailId = reader.GetGuid(0);
                        var name = reader.GetString(1);
                        var server = reader.GetString(2);
                        var password = reader.GetString(3);
                        mails.Add(new Mail
                        {
                            Id = mailId,
                            EncryptedName = name,
                            EncryptedServer = server,
                            EncryptedPassword = password
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return mails;
        }

        public async Task Create(Guid userId, Mail mail)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO MAILS (MailId, Name, Server, Password, UserId) VALUES(@MailId, @Name, @Server, @Password, @UserId)", connection);
                command.Parameters.AddWithValue("MailId", mail.Id);
                command.Parameters.AddWithValue("Name", mail.EncryptedName);
                command.Parameters.AddWithValue("Server", mail.EncryptedServer);
                command.Parameters.AddWithValue("Password", mail.EncryptedPassword);
                command.Parameters.AddWithValue("UserId", userId);
                try
                {
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public async Task Update(Mail mail)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE MAILS SET Name = @Name, Server = @Server, Password = @Password WHERE MailId = @MailId", connection);
                command.Parameters.AddWithValue("MailId", mail.Id);
                command.Parameters.AddWithValue("Name", mail.EncryptedName);
                command.Parameters.AddWithValue("Server", mail.EncryptedServer);
                command.Parameters.AddWithValue("Password", mail.EncryptedPassword);
                try
                {
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
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
                SqlCommand command = new SqlCommand("DELETE FROM MAILS WHERE MailId = @MailId", connection);
                command.Parameters.AddWithValue("MailId", id);
                try
                {
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
