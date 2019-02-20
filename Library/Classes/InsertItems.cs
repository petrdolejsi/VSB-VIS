using System.Windows.Forms;
using Library.Mapping;

namespace Library.Classes
{
    public static class InsertItems
    {
        public static void ToStatesNationality(ComboBox box)
        {
            var states = new StatesMapper().SelectAll();
            box.Items.Insert(0, "");
            foreach (var state in states)
            {
                box.Items.Insert(state.Id, state.Nationality);
            }
        }

        public static void ToStatesNames(ComboBox box)
        {
            var states = new StatesMapper().SelectAll();
            box.Items.Insert(0, "");
            foreach (var state in states)
            {
                box.Items.Insert(state.Id, state.Name);
            }
        }

        public static void ToTeams(ComboBox box)
        {
            var teams = new TeamsMapper().SelectAll();
            box.Items.Insert(0, "");
            foreach (var team in teams)
            {
                box.Items.Insert(team.Id, team.Name);
            }
        }

        public static void Manufacturers(ComboBox box)
        {
            var manufacturers = new ManufacturersMapper().SelectAll();
            box.Items.Insert(0,"");
            foreach (var manufacturer in manufacturers)
            {
                box.Items.Insert(manufacturer.Id, manufacturer.Name);
            }
        }
    }
}
