using System.Collections.ObjectModel;
using System.Data;
using Library.Models;

namespace Library.Mapping
{
    public class GpMapper
    {
        private const string SqlSelect = "SELECT ID, Name, Circuit, Date FROM GP";
        private const string SqlSelectDetail = "SELECT * FROM GP WHERE ID = @id";
        private const string SqlSelectState = "SELECT State_ID FROM GP WHERE ID = @id";
        private const string SqlSelectUser = "SELECT User_ID FROM GP WHERE ID = @id";
        private const string SqlSelectPrevNext = "SELECT prevID, nextID FROM ( SELECT ID, LAG(ID) OVER (order by ID) AS prevID, LEAD(ID) OVER (ORDER BY ID) AS nextID FROM GP ) as T WHERE ID = @id";

        public Collection<Gp> SelectAll(Database pDb = null)
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

            var gp = SelectAllReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return gp;
        }

        private Collection<Gp> SelectAllReader(IDataReader reader)
        {
            var gps = new Collection<Gp>();

            while (reader.Read())
            {
                var i = -1;
                var gp = new Gp
                {
                    Id = reader.GetInt32(++i),
                    Name = reader.GetString(++i),
                    Circuit = reader.GetString(++i)
                };
                if (!reader.IsDBNull(++i))
                {
                    gp.Date = reader.GetDateTime(i);
                }

                gps.Add(gp);
            }
            return gps;
        }

        public Gp SelectGp(int id,Database pDb = null)
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

            var gp = SelectGpReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return gp;
        }
        private Gp SelectGpReader(IDataReader reader)
        {
            var gp = new Gp();

            if (!reader.Read()) return gp;

            var i = -1;
            gp.Id = reader.GetInt32(++i);
            gp.Name = reader.GetString(++i);
            gp.Circuit = reader.GetString(++i);
            if (!reader.IsDBNull(++i))
            {
                gp.Date = reader.GetDateTime(i);
            }
            if (!reader.IsDBNull(++i))
            {
                gp.Lenght = reader.GetDouble(i);
            }
            if (!reader.IsDBNull(++i))
            {
                gp.Laps = reader.GetInt32(i);
            }
            i++;
            if (!reader.IsDBNull(++i))
            {
                gp.UserId = reader.GetInt32(i);
            }
            return gp;
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
