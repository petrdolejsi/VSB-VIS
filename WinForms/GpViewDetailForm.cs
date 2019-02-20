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
    public partial class GpViewDetailForm : Form
    {
        private int _gpId;
        private int? _nextId;
        private int? _prevId;
        public GpViewDetailForm()
        {
            InitializeComponent();
        }

        public bool OpenRecord(object primaryKey)
        {
            if (primaryKey == null) return false;
            var idDriver = (int)primaryKey;
            var driverMapper = new GpMapper();
            var gp = driverMapper.SelectGp(idDriver);

            labelNameEdit.Text = gp.Name;
            labelCircuitEdit.Text = gp.Circuit;
            if (gp.Date != null)
            {
                labelDateEdit.Text = ((DateTime)gp.Date).ToString("dd/MM/yyyy");
            }

            if (gp.Lenght != null)
            {
                labelLenghtEdit.Text = gp.Lenght.ToString();
            }

            if (gp.Laps != null)
            {
                labelLapsEdit.Text = gp.Laps.ToString();
            }

            gp.State = States.FindForGp(gp);
            var state = new StatesMapper().SelectState(gp.State.Id);
            labelStateEdit.Text = state.Name;

            labelHeader.Text = @"Výpis GP - " + gp.Name;
            Text = labelHeader.Text;

            _gpId = gp.Id;
            driverMapper.GetPrevNextDriver(_gpId, out _prevId, out _nextId);

            buttonGpEdit.Visible = ButtonEnable.TeamsEdit(gp.UserId, new UsersMapper().SelectUser(Logged.CurrentUser.UserRole));

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
    }
}
