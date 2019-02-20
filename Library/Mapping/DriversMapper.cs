using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Library.Models;

namespace Library.Mapping
{
    public class DriversMapper
    {
        private const string SqlSelect = "SELECT ID, FirstName, LastName FROM Drivers";
        private const string SqlSelectDetail = "SELECT ID, FirstName, LastName, Number, DateOfBirth FROM Drivers WHERE ID = @id";
        private const string SqlSelectTeam = "SELECT Team_ID FROM Drivers WHERE ID = @id";
        private const string SqlSelectState = "SELECT State_ID FROM Drivers WHERE ID = @id";
        private const string SqlSelectPrevNext = "SELECT prevID, nextID FROM ( SELECT ID, LAG(ID) OVER (order by ID) AS prevID, LEAD(ID) OVER (ORDER BY ID) AS nextID FROM Drivers ) as T WHERE ID = @id";
        private const string SqlSelectCountDrivers = "SELECT Count(*) FROM Drivers WHERE Team_ID = @id";
        private const string SqlInsert = "INSERT INTO Drivers VALUES (@first, @last, @number, @date, @teamId, @stateId)";
        private const string SqlUpdate = "UPDATE Drivers SET FirstName=@first, LastName=@last, Number=@number, DateOfBirth=@date, Team_ID=@teamId, State_ID=@stateId WHERE ID = @id";
        private const string SqlDeleteId = "DELETE FROM Drivers WHERE ID=@id";

        public int Insert(Drivers driver, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
                db.BeginTransaction();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SqlInsert);
            command.Parameters.AddWithValue("@first", driver.FirstName);
            command.Parameters.AddWithValue("@last", driver.LastName);
            command.Parameters.AddWithValue("@number", driver.Number == null ? DBNull.Value : (object)driver.Number);
            command.Parameters.AddWithValue("@date", driver.DateOfBirth);
            command.Parameters.AddWithValue("@teamId", driver.Team.Id);
            command.Parameters.AddWithValue("@stateId", driver.State.Id);
            var ret = Database.ExecuteNonQuery(command);

            if (pDb != null) return ret;
            db.EndTransaction();
            db.Close();

            return ret;
        }

        public int Edit(Drivers driver, Database pDb = null)
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

            var command = db.CreateCommand(SqlUpdate);
            command.Parameters.AddWithValue("@id", driver.Id);
            command.Parameters.AddWithValue("@first", driver.FirstName);
            command.Parameters.AddWithValue("@last", driver.LastName);
            command.Parameters.AddWithValue("@number", driver.Number == null ? DBNull.Value : (object)driver.Number);
            command.Parameters.AddWithValue("@date", driver.DateOfBirth);
            command.Parameters.AddWithValue("@teamID", driver.Team.Id);
            command.Parameters.AddWithValue("@stateID", driver.State.Id);
            var ret = Database.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public int Delete(int id, Database pDb = null) 
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

            var command = db.CreateCommand(SqlDeleteId);
            command.Parameters.AddWithValue("@id", id);
            var ret = Database.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public Collection<Drivers> SelectAll(Database pDb = null)
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

            var command = db.CreateCommand(SqlSelect);
            var reader = Database.Select(command);

            var jezdci = SelectAllReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return jezdci;
        }

        private Collection<Drivers> SelectAllReader(IDataReader reader)
        {
            var jezdci = new Collection<Drivers>();

            while (reader.Read())
            {
                var i = -1;
                var driver = new Drivers
                {
                    Id = reader.GetInt32(++i),
                    FirstName = reader.GetString(++i),
                    LastName = reader.GetString(++i)
                };

                jezdci.Add(driver);
            }
            return jezdci;
        }

        public Drivers SelectDriver(int id, Database pDb = null)
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

            var command = db.CreateCommand(SqlSelectDetail);
            command.Parameters.AddWithValue("@id", id);
            var reader = Database.Select(command);

            var jezdec = SelectDriverReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return jezdec;
        }

        private Drivers SelectDriverReader(IDataReader reader)
        {
            var driver = new Drivers();
            while (reader.Read()) { 
                var i = -1;
                driver.Id = reader.GetInt32(++i);
                driver.FirstName = reader.GetString(++i);
                driver.LastName = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    driver.Number = reader.GetInt32(i);
                }
                driver.DateOfBirth = reader.GetDateTime(++i);
            }
            return driver;
        }

        public void GetPrevNextDriver(int id, out int? prev, out int? next, Database pDb = null)
        {
            prev = null;
            next = null;
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

            var command = db.CreateCommand(SqlSelectPrevNext);
            command.Parameters.AddWithValue("@id", id);
            var reader = Database.Select(command);

            while (reader.Read())
            {
                var i = -1;
                if (!reader.IsDBNull(++i))
                {
                    prev = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    next = reader.GetInt32(i);
                }
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }
        }

        public int SelectCountDrivers(int id, Database pDb = null)
        {
            var number = 0;
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

            var command = db.CreateCommand(SqlSelectCountDrivers);
            command.Parameters.AddWithValue("@id", id);
            var reader = Database.Select(command);

            while (reader.Read())
            {
                var i = -1;
                if (!reader.IsDBNull(++i))
                {
                    number = reader.GetInt32(i);
                }
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return number;
        }

        public int? SelectState(int id, Database pDb = null)
        {
            return LazyLoadHelper.SelectById(id, SqlSelectState);
        }

        public int? SelectTeam(int id, Database pDb = null)
        {
            return LazyLoadHelper.SelectById(id, SqlSelectTeam);
        }
    }
}
