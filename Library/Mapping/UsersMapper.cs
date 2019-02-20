using System;
using System.Data.Common;
using Library.Models;

namespace Library.Mapping
{
    public class UsersMapper
    {
        private const string SqlSelectUser = "SELECT ID, Login, Type FROM Users WHERE Login=@login";
        private const string SqlSelectToLogin = "SELECT ID, Login, Type FROM Users WHERE Login=@login AND Password=@password";

        public Users SelectToLogin(string login, string password, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            var command = db.CreateCommand(SqlSelectToLogin);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);
            var reader = Database.Select(command);

            var user = SelectToLoginReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return user;
        }

        public Users SelectUser(string login, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            var command = db.CreateCommand(SqlSelectUser);
            command.Parameters.AddWithValue("@login", login);
            var reader = Database.Select(command);

            var user = SelectToLoginReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return user;
        }

        private Users SelectToLoginReader(DbDataReader reader)
        {
            Users user = null;
            var i = -1;

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new Users
                        {
                            Id = reader.GetInt32(++i),
                            Login = reader.GetString(++i),
                            Type = reader.GetString(++i)
                        };
                    }
                }
            }
            catch (Exception)
            {
                user = null;
            }

            return user;
        }
    }
}
