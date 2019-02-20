using Library.Mapping;

namespace Library.Models
{
    public class Manufacturers
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Manufacturers EmptyManufacturer()
        {
            Manufacturers manufacturer = new Manufacturers();
            manufacturer.Id = 0;
            manufacturer.Name = "";
            return manufacturer;
        }

        public static Manufacturers FindForTeam(Teams team)
        {
            var teamsMapper = new TeamsMapper();
            if (teamsMapper.SelectManufacturer(team.Id) == null) return null;
            return new ManufacturersMapper().SelectManufacturer(id: (int)teamsMapper.SelectManufacturer(team.Id));
        }
    }
}
