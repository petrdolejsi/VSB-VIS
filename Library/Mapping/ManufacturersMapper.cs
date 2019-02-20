using System.Collections.ObjectModel;
using System.Data;
using Library.Models;

namespace Library.Mapping
{
    public class ManufacturersMapper
    {
        private const string SqlSelect = "SELECT * FROM Manufacturers";
        private const string SqlSelectManufacturer = "SELECT * FROM Manufacturers WHERE ID = @id";
        private const string SqlSelectCountId = "SELECT Count(*) FROM Manufacturers WHERE ID = @id";
        private const string SqlSelectTotalCount = "SELECT Count(*) FROM Manufacturers";

        public Collection<Manufacturers> SelectAll(Database pDb = null)
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

            var manufacturerses = SelectAllReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return manufacturerses;
        }

        private Collection<Manufacturers> SelectAllReader(IDataReader reader)
        {
            var manufacturers = new Collection<Manufacturers>();

            while (reader.Read())
            {
                var i = -1;
                var manufacturer = new Manufacturers
                {
                    Id = reader.GetInt32(++i),
                    Name = reader.GetString(++i)
                };

                manufacturers.Add(manufacturer);
            }
            return manufacturers;
        }

        public Manufacturers SelectManufacturer(int id, Database pDb = null)
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

            var command = db.CreateCommand(SqlSelectManufacturer);
            command.Parameters.AddWithValue("@id", id);
            var reader = Database.Select(command);

            var manufacturerses = SelectManufacturerReader(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return manufacturerses;
        }

        private Manufacturers SelectManufacturerReader(IDataReader reader)
        {
            
            var manufacturer = new Manufacturers();

            while (reader.Read())
            {
                var i = -1;
                manufacturer.Id = reader.GetInt32(++i);
                manufacturer.Name = reader.GetString(++i);
            }

            return manufacturer;
        }

        public int SelectCountId(int id, Database pDb = null)
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

            var command = db.CreateCommand(SqlSelectCountId);
            command.Parameters.AddWithValue("@id", id);
            var reader = Database.Select(command);

            var manufacturerses = SelectOneItem(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return manufacturerses;
        }

        public int SelectTotalCount(Database pDb = null)
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

            var command = db.CreateCommand(SqlSelectTotalCount);
            var reader = Database.Select(command);

            var manufacturerses = SelectOneItem(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return manufacturerses;
        }

        private int SelectOneItem(IDataReader reader)
        {
            int number = 0;

            while (reader.Read())
            {
                var i = -1;
                number = reader.GetInt32(++i);
            }

            return number;
        }
    }
}
