using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using Library.Models;

namespace Library.Mapping
{
    public class ClassificationMapper
    {
        private const string SqlInsert = "INSERT INTO Classifications VALUES (@gp, @position, @driver)";
        private const string SqlUpdate = "UPDATE Classifications SET Position=@position WHERE GP_ID=@gp AND Driver_ID=@driver";
        private const string SqlDelete = "DELETE FROM Classifications WHERE GP_ID=@gp AND Position=@position";
        private const string SqlSelectGp = "SELECT GP_ID, Position, Driver_ID FROM Classifications WHERE GP_ID=@gp ORDER BY CASE Position WHEN 0 THEN 2 ELSE 1 END, Position";
        private const string SqlSelectGpDriver = "SELECT Position FROM Classifications WHERE GP_ID=@gp AND Driver_ID=@driver ORDER BY CASE Position WHEN 0 THEN 2 ELSE 1 END, Position";
        private const string SqlSelectDriver = "SELECT Driver_ID FROM Classifications WHERE GP_ID=@gp AND Position=@position";
        private const string SqlCount = "SELECT Count(*) FROM Classifications WHERE GP_ID=@gp";

        public int Insert(int gpId, int driver, int position, Database pDb = null)
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

            var command = db.CreateCommand(SqlInsert);
            command.Parameters.AddWithValue("@gp", gpId);
            command.Parameters.AddWithValue("@position", position);
            command.Parameters.AddWithValue("@driver", driver);
            var ret = Database.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public int Edit(int gpId, int driver, int position, Database pDb = null)
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
            command.Parameters.AddWithValue("@gp", gpId);
            command.Parameters.AddWithValue("@position", position);
            command.Parameters.AddWithValue("@driver", driver);
            var ret = Database.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public int Delete(Classification classification, Database pDb = null)
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

            var command = db.CreateCommand(SqlDelete);
            command.Parameters.AddWithValue("@gp", classification.Gp.Id);
            command.Parameters.AddWithValue("@position", classification.Position);
            var ret = Database.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public Dictionary<int, Classification> SelectAll(int gp, Database pDb = null)
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

            var command = db.CreateCommand(SqlSelectGp);
            command.Parameters.AddWithValue("@gp", gp);
            var reader = Database.Select(command);

            var classifications = SelectRead(reader, gp);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return classifications;
        }

        private Dictionary<int, Classification> SelectRead(IDataReader reader, int gp)
        {
            var classifications = new Dictionary<int, Classification>();
            var gpMapper = new GpMapper();

            var driversMapper = new DriversMapper();

            while (reader.Read())
            {
                var i = 0;
                var classification = new Classification();
                classification.Gp = gpMapper.SelectGp(gp);
                classification.Position = reader.GetInt32(++i);
                classification.Driver = driversMapper.SelectDriver(reader.GetInt32(++i));

                classifications.Add(classification.Driver.Id, classification);
            }

            return classifications;
        }

        public int? SelectGpDriver(int gp, int driver, Database pDb = null)
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

            var command = db.CreateCommand(SqlSelectGpDriver);
            command.Parameters.AddWithValue("@gp", gp);
            command.Parameters.AddWithValue("@driver", driver);
            var reader = Database.Select(command);

            var classification = SelectSelectGpDriver(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return classification;
        }

        public int? SelectGpPosition(int gp, int position, Database pDb = null)
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

            var command = db.CreateCommand(SqlSelectDriver);
            command.Parameters.AddWithValue("@gp", gp);
            command.Parameters.AddWithValue("@position", position);
            var reader = Database.Select(command);

            var classification = SelectSelectGpDriver(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return classification;
        }

        private int? SelectSelectGpDriver(IDataReader reader)
        {
            int? number = null;

            while (reader.Read())
            {
                number = reader.GetInt32(0);
            }
            return number;
        }

        public int? SelectGpCount(int gp, Database pDb = null)
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

            var command = db.CreateCommand(SqlCount);
            command.Parameters.AddWithValue("@gp", gp);
            var reader = Database.Select(command);

            var classification = SelectSelectGpDriver(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return classification;
        }
    }
}
