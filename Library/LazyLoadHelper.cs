using Library.Mapping;

namespace Library
{
    public static class LazyLoadHelper
    {
        public static int? SelectById(int id, string sql, Database pDb = null)
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

            var command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@id", id);
            var reader = Database.Select(command);

            int? number = null;

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

        public static int? SelectByGpAndPosition(int gp, int position, string sql, Database pDb = null)
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

            var command = db.CreateCommand(sql);
            command.Parameters.AddWithValue("@gp", gp);
            command.Parameters.AddWithValue("@position", position);
            var reader = Database.Select(command);

            int? number = null;

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
    }
}
