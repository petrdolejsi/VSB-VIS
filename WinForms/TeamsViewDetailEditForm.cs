using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Classes;
using Library.Mapping;
using Library.Models;

namespace WinForms
{
    public partial class TeamsViewDetailEditForm : Form
    {
        private int _teamId;
        public TeamsViewDetailEditForm()
        {
            InitializeComponent();
        }

        public bool OpenRecord(object primaryKey)
        {
            InsertItems.ToStatesNames(comboBoxState);
            InsertItems.Manufacturers(comboBoxManufacturer);

            if (primaryKey == null) return false;
            _teamId = (int)primaryKey;
            var team = new TeamsMapper().SelectTeam(_teamId);

            textBoxName.Text = team.Name;
            textBoxTyres.Text = team.Tyres;


            team.Manufacturer = Manufacturers.FindForTeam(team);
            if (team.Manufacturer != null)
            {
                comboBoxManufacturer.SelectedIndex = team.Manufacturer.Id;
            }
            else
            {
                comboBoxManufacturer.SelectedIndex = -1;
            }

            team.State = States.FindForTeam(team);
            if (team.State != null)
            {
                comboBoxState.SelectedIndex = team.State.Id;
            }
            else
            {
                comboBoxState.SelectedIndex = -1;
            }

            labelHeader.Text = @"Úprava týmu - " + team.Name;
            Text = labelHeader.Text;

            return true;
        }

        private void buttonTeamSave_Click(object sender, EventArgs e)
        {
            var teamsMapper = new TeamsMapper();
            var manufacturersMapper = new ManufacturersMapper();

            var teamFromDb = teamsMapper.SelectTeam(_teamId);
            teamFromDb.State = States.FindForTeam(teamFromDb);

            var totalCount = manufacturersMapper.SelectTotalCount();
            var count = manufacturersMapper.SelectCountId(comboBoxManufacturer.SelectedIndex);

            if (totalCount / 2 < count)
            {
                labelError.Text = @"Dodavatel motorů nesmí dodávat motory více, jak polovině týmů.";
                return;
            }

            var team = new Teams();
            team.Id = _teamId;
            team.Name = textBoxName.Text;
            team.Tyres = textBoxTyres.Text;

            if (comboBoxManufacturer.SelectedIndex == 0)
            {
                team.Manufacturer = null;
            }
            else
            {
                team.Manufacturer = new Manufacturers() { Id = comboBoxManufacturer.SelectedIndex };
            }

            team.State = new States { Id = comboBoxState.SelectedIndex };
            if (team.State.Id < 1)
            {
                labelError.Text = @"Tým musí mít vybraný stát";
                return;
            }

            teamsMapper.Edit(team);

            Close();
        }
    }
}
