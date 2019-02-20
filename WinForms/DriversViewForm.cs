using System.ComponentModel;
using System.Windows.Forms;
using Library.Classes;
using Library.Mapping;
using Library.Models;

namespace WinForms
{
    public partial class DriversViewForm : Form
    {
        public DriversViewForm()
        {
            InitializeComponent();
            if (Logged.CurrentUser.UserRole == "Admin")
            {
                buttonDriverAdd.Visible = true;
            }

            RefreshData();
        }

        private void RefreshData()
        {
            var auctions = new DriversMapper().SelectAll();
            var bindingList = new BindingList<Drivers>(auctions);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Rows.Clear();
            foreach (var driver in bindingList)
            {
                var rowIndex = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[rowIndex];

                row.Cells["FirstName"].Value = driver.FirstName;
                row.Cells["LastName"].Value = driver.LastName;
                row.Cells["ID"].Value = driver.Id;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var driversViewDetailForm = new DriversViewDetailForm();
            var row = dataGridView1.Rows[e.RowIndex];
            if (!driversViewDetailForm.OpenRecord(row.Cells["ID"].Value)) return;
            driversViewDetailForm.ShowDialog();
            RefreshData();
        }
    }
}
