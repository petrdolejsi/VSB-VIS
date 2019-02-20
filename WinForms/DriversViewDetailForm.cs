using System;
using System.Windows.Forms;
using Library.Classes;
using Library.Mapping;
using Library.Models;

namespace WinForms
{
    public partial class DriversViewDetailForm : Form
    {
        private int _driverId;
        private int? _nextId;
        private int? _prevId;
        public DriversViewDetailForm()
        {
            InitializeComponent();
        }

        public bool OpenRecord(object primaryKey)
        {
            if (primaryKey == null) return false;
            var idDriver = (int)primaryKey;
            var driverMapper = new DriversMapper();
            var driver = driverMapper.SelectDriver(idDriver);

            labelFirstNameEdit.Text = driver.FirstName;
            labelLastNameEdit.Text = driver.LastName;
            labelNumberEdit.Text = driver.Number.ToString();

            if (driver.DateOfBirth != null)
            {
                labelDateOfBirthEdit.Text = ((DateTime)driver.DateOfBirth).ToString("dd/MM/yyyy");
            }

            driver.Team = Teams.FindForDriver(driver);
            if (driver.Team != null)
            {
                var team = new TeamsMapper().SelectTeam(driver.Team.Id);
                labelTeamEdit.Text = team.Name;
            }
            else
            {
                labelTeamEdit.Text = @"N/A";
            }

            driver.State = States.FindForDriver(driver);
            var state = new StatesMapper().SelectState(driver.State.Id);
            labelNationailityEdit.Text = state.Nationality;

            labelHeader.Text = @"Výpis jezdce - " + driver.FirstName + @" " + driver.LastName;
            Text = labelHeader.Text;

            _driverId = driver.Id;
            driverMapper.GetPrevNextDriver(_driverId, out _prevId, out _nextId);

            buttonDriverEdit.Visible = driver.Team != null && ButtonEnable.TeamsEdit(driver.Team.UserId,new UsersMapper().SelectUser(Logged.CurrentUser.UserRole));

            return true;
        }

        private void DriversViewDetailForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonDriverEdit_Click(object sender, EventArgs e)
        {
            var driversViewDetailEditForm = new DriversViewDetailEditForm();
            if (!driversViewDetailEditForm.OpenRecord(_driverId)) return;
            Close();
            driversViewDetailEditForm.ShowDialog();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            OpenRecord(_prevId);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            OpenRecord(_nextId);
        }
    }
}
