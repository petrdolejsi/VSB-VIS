using System.Collections.ObjectModel;
using System.Data;
using Library.Models;

namespace Library.Mapping
{
    public class PointsMapper 
    {
        private const string SqlSelect = "SELECT * FROM Points ORDER BY Position";
        private const string SqlSelectPoint = "SELECT * FROM Points WHERE Position=@position";

        public Collection<Points> SelectAll(Database pDb = null)
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

            var points = SelectAllReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return points;
        }

        private Collection<Points> SelectAllReader(IDataReader reader)
        {
            var points = new Collection<Points>();

            while (reader.Read())
            {
                var i = -1;
                var point = new Points
                {
                    Position = reader.GetInt32(++i),
                    Revard = reader.GetInt32(++i)
                };

                points.Add(point);
            }
            return points;
        }

        public Points SelectPoint(int position, Database pDb = null)
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

            var command = db.CreateCommand(SqlSelectPoint);
            command.Parameters.AddWithValue("@position", position);
            var reader = Database.Select(command);

            var point = SelectPointReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return point;
        }

        private Points SelectPointReader(IDataRecord reader)
        {
            var i = -1;
            var point = new Points
            {
                Position = reader.GetInt32(++i),
                Revard = reader.GetInt32(++i)
            };
            return point;
        }
    }
}
