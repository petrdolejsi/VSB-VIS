using System;
using System.Linq;
using System.Windows.Forms;
using Library.Classes;
using Library.Mapping;
using Library.Models;

namespace WinForms
{
    public partial class DriversViewDetailEditForm : Form
    {
        private int _driverId;
        public DriversViewDetailEditForm()
        {
            InitializeComponent();
        }

        public bool OpenRecord(object primaryKey)
        {
            InsertItems.ToStatesNationality(comboBoxNationality);
            InsertItems.ToTeams(comboBoxTeam);

            if (primaryKey == null) return false;
            var idDriver = (int)primaryKey;
            var driver =new  DriversMapper().SelectDriver(idDriver);

            textBoxFirstName.Text = driver.FirstName;
            textBoxLastName.Text = driver.LastName;
            if (driver.Number != null) numericUpDownNumber.Value = (int) driver.Number;
            if (driver.DateOfBirth != null)
            {
                dateTimePickerDateOfbirth.Value = (DateTime)driver.DateOfBirth;
            }

            driver.Team = Teams.FindForDriver(driver);
            if (driver.Team != null)
            {
                comboBoxTeam.SelectedIndex = driver.Team.Id;
            }
            else
            {
                comboBoxTeam.SelectedIndex = -1;
            }

            driver.State = States.FindForDriver(driver);
            if (driver.State != null)
            {
                comboBoxNationality.SelectedIndex = driver.State.Id;
            }
            else
            {
                comboBoxNationality.SelectedIndex = -1;
            }

            labelHeader.Text = @"Úprava jezdce - " + driver.FirstName + @" " + driver.LastName;
            Text = labelHeader.Text;

            _driverId = driver.Id;

            return true;
        }

        private void ButtonDriverEdit_Click(object sender, EventArgs e)
        {
            var count = 0;

            var driversMapper = new DriversMapper();

            var driverFromDb = driversMapper.SelectDriver(_driverId);
            driverFromDb.Team = Teams.FindForDriver(driverFromDb);

            var driver = new Drivers
            {
                Id = _driverId,
                FirstName = textBoxFirstName.Text,
                LastName = textBoxLastName.Text
            };

            if (driver.FirstName.Any(char.IsDigit) || driver.LastName.Any(char.IsDigit))
            {
                labelError.Text = @"Jméno nebo příjmení obsahuje číslice";
                return;
            }

            driver.Number = (int)numericUpDownNumber.Value;
            driver.DateOfBirth = dateTimePickerDateOfbirth.Value;

            if ((DateTime.Now - (DateTime)driver.DateOfBirth).TotalDays < (365*15))
            {
                labelError.Text = @"Jezdec nesmí mít méně, než 15 let";
                return;
            }

            if (comboBoxTeam.SelectedIndex == 0)
            {
                driver.Team = null;
            }
            else
            {
                driver.Team = new Teams {Id = comboBoxTeam.SelectedIndex};
                count = driversMapper.SelectCountDrivers(comboBoxTeam.SelectedIndex);
            }

            if (driver.Team != null && (count >= 2 && driverFromDb.Team.Id != driver.Team.Id))
            {
                labelError.Text = @"Tým již má přidělené 2 jezdce";
                return;
            }

            driver.State = new States {Id = comboBoxNationality.SelectedIndex};
            if (driver.State.Id < 1)
            {
                labelError.Text = @"Uživatel musí m9t vybranou národnost";
                return;
            }

            driversMapper.Edit(driver);

            Close();
        }
    }
}
