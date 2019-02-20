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
    public partial class TeamsViewDetailForm : Form
    {
        private int _teamId;
        private int? _nextId;
        private int? _prevId;

        public TeamsViewDetailForm()
        {
            InitializeComponent();
        }

        public bool OpenRecord(object primaryKey)
        {
            if (primaryKey == null) return false;
            var idTeam = (int)primaryKey;
            var teamsMapper = new TeamsMapper();
            var team = teamsMapper.SelectTeam(idTeam);

            labelName.Text = team.Name;
            labelTyres.Text = team.Tyres;

            team.Manufacturer = Manufacturers.FindForTeam(team);
            if (team.Manufacturer != null)
            {
                var manufacturer = new ManufacturersMapper().SelectManufacturer(team.Manufacturer.Id);
                labelManufacturer.Text = manufacturer.Name;
            }
            else
            {
                labelManufacturer.Text = @"N/A";
            }

            team.State = States.FindForTeam(team);
            var state = new StatesMapper().SelectState(team.State.Id);
            labelState.Text = state.Name;

            labelHeader.Text = @"Výpis týmu - " + team.Name;
            Text = labelHeader.Text;

            _teamId = team.Id;
            teamsMapper.GetPrevNextDriver(_teamId, out _prevId, out _nextId);

            buttonTeamEdit.Visible = ButtonEnable.TeamsEdit(team.UserId, new UsersMapper().SelectUser(Logged.CurrentUser.UserRole));

            return true;
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            OpenRecord(_prevId);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            OpenRecord(_nextId);
        }

        private void buttonTeamEdit_Click(object sender, EventArgs e)
        {
            var teamsViewDetailEditForm = new TeamsViewDetailEditForm();
            if (!teamsViewDetailEditForm.OpenRecord(_teamId)) return;
            Close();
            teamsViewDetailEditForm.ShowDialog();
        }
    }
}
