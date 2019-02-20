using System.ComponentModel;
using System.Windows.Forms;
using Library.Mapping;
using Library.Models;

namespace WinForms
{
    public partial class ToDoForm : Form
    {
        public ToDoForm()
        {
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            var todos = new ToDoMapper().GetAll();
            var bindingList = new BindingList<ToDo>(todos);
            dataGridViewToDo.AutoGenerateColumns = false;
            dataGridViewToDo.Rows.Clear();
            foreach (var item in bindingList)
            {
                var rowIndex = dataGridViewToDo.Rows.Add();
                var row = dataGridViewToDo.Rows[rowIndex];

                row.Cells["Title"].Value = item.Title;
                row.Cells["TextOfItem"].Value = item.Text;
            }
        }
    }
}
