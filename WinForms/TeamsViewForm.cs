using System.ComponentModel;
using System.Windows.Forms;
using Library.Classes;
using Library.Mapping;
using Library.Models;

namespace WinForms
{
    public partial class TeamsViewForm : Form
    {
        public TeamsViewForm()
        {
            InitializeComponent();
            if (Logged.CurrentUser.UserRole == "Admin")
            {
                buttonTeamAdd.Visible = true;
            }

            RefreshData();
        }

        private void RefreshData()
        {
            var auctions = new TeamsMapper().SelectAll();
            var bindingList = new BindingList<Teams>(auctions);
            dataGridViewTeams.AutoGenerateColumns = false;
            dataGridViewTeams.Rows.Clear();
            foreach (var team in bindingList)
            {
                var rowIndex = dataGridViewTeams.Rows.Add();
                var row = dataGridViewTeams.Rows[rowIndex];

                row.Cells["NameOfTeam"].Value = team.Name;
                row.Cells["ID"].Value = team.Id;
            }
        }

        private void dataGridViewTeams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var teamsViewDetailForm = new TeamsViewDetailForm();
            var row = dataGridViewTeams.Rows[e.RowIndex];
            if (!teamsViewDetailForm.OpenRecord(row.Cells["ID"].Value)) return;
            teamsViewDetailForm.ShowDialog();
            RefreshData();
        }
    }
}
