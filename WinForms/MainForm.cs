
using System.Windows.Forms;

namespace WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItemDrivers_Click(object sender, System.EventArgs e)
        {
            OpeningForms<DriversViewForm>();
        }

        private void teamsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpeningForms<TeamsViewForm>();
        }

        private void grandPrixToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpeningForms<GpViewForm>();
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }

        private void toDoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpeningForms<ToDoForm>();
        }

        private void OpeningForms<T>() where T : Form, new()
        {
            var form = new T();
            foreach (Form form2 in Application.OpenForms)
            {
                if (form2.GetType() != typeof(T)) continue;
                form2.Activate();
                return;
            }
            form.MdiParent = this;
            form.Show();
        }
    }
}
