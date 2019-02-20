using Library.Mapping;

namespace Library.Models
{
    public class States
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        public States EmptyState()
        {
            States state = new States();
            state.Id = 0;
            state.Name = "";
            state.Nationality = "";
            return state;
        }

        public static States FindForDriver(Drivers driver)
        {
            var driversMapper = new DriversMapper();
            if (driversMapper.SelectTeam(driver.Id) == null) return null;
            return new StatesMapper().SelectState((int)driversMapper.SelectState(driver.Id));
        }

        public static States FindForTeam(Teams team)
        {
            var teamsMapper = new TeamsMapper();
            if (teamsMapper.SelectState(team.Id) == null) return null;
            return new StatesMapper().SelectState((int)teamsMapper.SelectState(team.Id));
        }

        public static States FindForGp(Gp gp)
        {
            var gpMapper = new GpMapper();
            if (gpMapper.SelectState(gp.Id) == null) return null;
            return new StatesMapper().SelectState((int)gpMapper.SelectState(gp.Id));
        }
    }
}
