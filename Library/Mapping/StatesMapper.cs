using System.Collections.ObjectModel;
using System.Data;
using Library.Models;

namespace Library.Mapping
{
    public class StatesMapper
    {
        private const string SqlSelect = "SELECT * FROM States";
        private const string SqlSelectState = "SELECT * FROM States WHERE ID = @id";

        public Collection<States> SelectAll(Database pDb = null)
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

            var states = SelectAllReader(reader);
            reader.Close();
            
            if (pDb == null)
            {
                db.Close();
            }

            return states;
        }

        private Collection<States> SelectAllReader(IDataReader reader)
        {
            var states = new Collection<States>();

            while (reader.Read())
            {
                var i = -1;
                var state = new States
                {
                    Id = reader.GetInt32(++i),
                    Name = reader.GetString(++i),
                    Nationality = reader.GetString(++i)
                };

                states.Add(state);
            }
            return states;
        }

        public States SelectState(int id, Database pDb = null)
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

            var command = db.CreateCommand(SqlSelectState);
            command.Parameters.AddWithValue("@id", id);
            var reader = Database.Select(command);

            var states = SelectStateReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return states;
        }

        private States SelectStateReader(IDataReader reader)
        {
            var state = new States();

            while (reader.Read())
            {
                var i = -1;
                state.Id = reader.GetInt32(++i);
                state.Name = reader.GetString(++i);
                state.Nationality = reader.GetString(++i);
            }

            return state;
        }
    }
}
