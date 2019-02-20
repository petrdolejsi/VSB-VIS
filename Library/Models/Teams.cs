using Library.Mapping;

namespace Library.Models
{
    public class Teams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tyres { get; set; }
        public Manufacturers Manufacturer { get; set; }
        public States State { get; set; }
        public int? UserId { get; set; }

        public Teams EmptyTeam()
        {
            Teams team = new Teams();
            team.Id = 0;
            team.Name = "";
            return team;
        }

        public static Teams FindForDriver(Drivers driver)
        {
            var driversMapper = new DriversMapper();
            if (driversMapper.SelectTeam(driver.Id) == null) return null;
            return new TeamsMapper().SelectTeam((int)driversMapper.SelectTeam(driver.Id));
        }
    }    
}
