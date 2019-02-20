using System.ComponentModel;
using System.Windows.Forms;
using Library.Classes;
using Library.Mapping;
using Library.Models;

namespace WinForms
{
    public partial class GpViewForm : Form
    {
        public GpViewForm()
        {
            InitializeComponent();
            if (Logged.CurrentUser.UserRole == "Admin")
            {
                buttonGpAdd.Visible = true;
            }

            RefreshData();
        }

        private void RefreshData()
        {
            var auctions = new GpMapper().SelectAll();
            var bindingList = new BindingList<Gp>(auctions);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Rows.Clear();
            foreach (var gp in bindingList)
            {
                var rowIndex = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[rowIndex];

                row.Cells["NameOfGp"].Value = gp.Name;
                row.Cells["ID"].Value = gp.Id;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var row = dataGridView1.Rows[e.RowIndex];
            if (senderGrid.Columns[e.ColumnIndex].Name == "Detail")
            {
                var gpViewDetailForm = new GpViewDetailForm();
                if (!gpViewDetailForm.OpenRecord(row.Cells["ID"].Value)) return;
                gpViewDetailForm.ShowDialog();
                RefreshData();
            }
            else if (senderGrid.Columns[e.ColumnIndex].Name == "Classification")
            {
                var gpViewClassificationForm = new GpViewClassificationForm();
                if (!gpViewClassificationForm.OpenRecord(row.Cells["ID"].Value)) return;
                gpViewClassificationForm.ShowDialog();
                RefreshData();
            }

        }
    }
}
