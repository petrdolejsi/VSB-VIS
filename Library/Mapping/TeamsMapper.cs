using System.Collections.ObjectModel;
using System.Data;
using Library.Models;

namespace Library.Mapping
{
    public class TeamsMapper
    {
        private const string SqlSelect = "SELECT ID, Name FROM Teams";
        private const string SqlSelectDetail = "SELECT * FROM Teams WHERE ID = @id";
        private const string SqlSelectDetailByUser = "SELECT * FROM Teams WHERE User_ID = @id";
        private const string SqlSelectPrevNext = "SELECT prevID, nextID FROM ( SELECT ID, LAG(ID) OVER (order by ID) AS prevID, LEAD(ID) OVER (ORDER BY ID) AS nextID FROM Teams ) as T WHERE ID = @id";
        private const string SqlSelectManufacturer = "SELECT Manufacturer_ID FROM Teams WHERE ID = @id";
        private const string SqlSelectState = "SELECT State_ID FROM Teams WHERE ID = @id";
        private const string SqlSelectUser = "SELECT User_ID FROM Teams WHERE ID = @id";
        private const string SqlUpdate = "UPDATE Teams SET Name=@name, Tyres=@tyres, Manufacturer_ID=@manufacturerId, State_ID=@stateId WHERE ID = @id";

        public int Edit(Teams team, Database pDb = null)
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
            command.Parameters.AddWithValue("@id", team.Id);
            command.Parameters.AddWithValue("@name", team.Name);
            command.Parameters.AddWithValue("@tyres", team.Tyres);
            command.Parameters.AddWithValue("@manufacturerId", team.Manufacturer.Id);
            command.Parameters.AddWithValue("@stateId", team.State.Id);
            var ret = Database.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public Collection<Teams> SelectAll(Database pDb = null)
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

            var teams = SelectAllReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return teams;
        }

        public Teams SelectTeam(int id, bool byUser = false, Database pDb = null)
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

            var command = db.CreateCommand(byUser ? SqlSelectDetailByUser : SqlSelectDetail);
            command.Parameters.AddWithValue("@id", id);
            var reader = Database.Select(command);

            var teams = SelectTeamReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return teams;
        }

        private Teams SelectTeamReader(IDataReader reader)
        {
            var team = new Teams();
            while (reader.Read())
            {
                var i = -1;
                team.Id = reader.GetInt32(++i);
                team.Name = reader.GetString(++i);
                team.Tyres = reader.GetString(++i);
                i += 2;
                if (!reader.IsDBNull(++i))
                {
                    team.UserId = reader.GetInt32(i);
                }
            }
            return team;
        }

        private Collection<Teams> SelectAllReader(IDataReader reader)
        {
            var teams = new Collection<Teams>();

            while (reader.Read())
            {
                var i = -1;
                var team = new Teams
                {
                    Id = reader.GetInt32(++i),
                    Name = reader.GetString(++i)
                };

                teams.Add(team);
            }
            return teams;
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

        public int? SelectManufacturer(int id, Database pDb = null)
        {
            return LazyLoadHelper.SelectById(id, SqlSelectManufacturer);
        }

        public int? SelectState(int id, Database pDb = null)
        {
            return LazyLoadHelper.SelectById(id, SqlSelectState);
        }
        public int? SelectUser(int id, Database pDb = null)
        {
            return LazyLoadHelper.SelectById(id, SqlSelectUser);
        }
    }
}
