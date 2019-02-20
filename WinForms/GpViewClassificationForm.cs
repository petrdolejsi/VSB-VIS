using System;
using System.ComponentModel;
using System.Windows.Forms;
using Library.Classes;
using Library.Mapping;
using Library.Models;

namespace WinForms
{
    public partial class GpViewClassificationForm : Form
    {
        private int _gpId;
        private int? _nextId;
        private int? _prevId;
        public GpViewClassificationForm()
        {
            InitializeComponent();
        }

        public bool OpenRecord(object primaryKey)
        {
            if (primaryKey == null) return false;
            var idGp = (int)primaryKey;
            var gpMapper = new GpMapper();
            var classificationMapper = new ClassificationMapper();
            var gp = gpMapper.SelectGp(idGp);
            var drivers = new DriversMapper().SelectAll();

            var bindingList = new BindingList<Drivers>(drivers);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Rows.Clear();
            foreach (var driver in bindingList)
            {
                var rowIndex = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[rowIndex];

                row.Cells["Position"].Value = classificationMapper.SelectGpDriver(gp.Id, driver.Id);
                row.Cells["LastName"].Value = driver.LastName;
                row.Cells["FirstName"].Value = driver.FirstName;
                row.Cells["ID"].Value = driver.Id;
            }

            if (classificationMapper.SelectGpCount(gp.Id) == 0)
            {
                labelError.Text = @"Výsledky pro tuto GP ještě neexistují.";
            }
            else
            {
                labelError.Text = "";
            }

            labelHeader.Text = @"Zobrazení výsledků GP - " + gp.Name;
            Text = labelHeader.Text;

            _gpId = idGp;
            gpMapper.GetPrevNextDriver(_gpId, out _prevId, out _nextId);

            buttonGpEdit.Visible = ButtonEnable.TeamsEdit(gp.UserId, new UsersMapper().SelectUser(Logged.CurrentUser.UserRole));

            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            OpenRecord(_prevId);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            OpenRecord(_nextId);
        }

        private void buttonGpEdit_Click(object sender, EventArgs e)
        {
            var gpViewClassificationEditForm = new GpViewClassificationEditForm();
            if (!gpViewClassificationEditForm.OpenRecord(_gpId)) return;
            Close();
            gpViewClassificationEditForm.ShowDialog();
        }
    }
}
