using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Library.Mapping;
using Library.Models;

namespace WinForms
{
    public partial class GpViewClassificationEditForm : Form
    {
        private int _gpId;
        public GpViewClassificationEditForm()
        {
            InitializeComponent();
        }

        public bool OpenRecord(object primaryKey)
        {
            try
            {
                if (primaryKey == null) return false;
                _gpId = (int)primaryKey;
                var gpMapper = new GpMapper();
                var classificationMapper = new ClassificationMapper();
                var results = classificationMapper.SelectAll(_gpId);
                var gp = gpMapper.SelectGp(_gpId);
                var drivers = new DriversMapper().SelectAll();

                var positions = new PointsMapper().SelectAll();

                var bindingList = new BindingList<Drivers>(drivers);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Rows.Clear();

                foreach (var driver in bindingList)
                {
                    var rowIndex = dataGridView1.Rows.Add();
                    var row = dataGridView1.Rows[rowIndex];

                    row.Cells["Position"].ValueType = typeof(int);

                    ((DataGridViewComboBoxCell)row.Cells["Position"]).Items.Insert(0, "");

                    foreach (var position in positions)
                    {
                        ((DataGridViewComboBoxCell)row.Cells["Position"]).Items.Insert(position.Position, position.Position);
                    }

                    try
                    {
                        if (results.ContainsKey(driver.Id))
                        {
                            row.Cells["Position"].Value = results[driver.Id].Position;
                        }
                    }
                    catch
                    {
                        // ignored
                    }

                    row.Cells["LastName"].Value = driver.LastName;
                    row.Cells["FirstName"].Value = driver.FirstName;
                    row.Cells["ID"].Value = driver.Id;
                }

                labelError.Text = "";
                if (results.Count == 0)
                {
                    labelError.Text += @"Výsledky pro tuto GP ještě neexistují. ";
                }
                if (gp.Date.AddHours(1) > DateTime.Now)
                {
                    labelError.Text += @"Výsledky lze uložit nejdříve 1 hodinu po startu GP. ";
                }

                labelHeader.Text = @"Úprava výsledků GP - " + gp.Name;
                Text = labelHeader.Text;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return true;
        }

        private void buttonGpSave_Click(object sender, EventArgs e)
        {
            try
            {
                var gpMapper = new GpMapper();
                var gp = gpMapper.SelectGp(_gpId);

                if (gp.Date.AddHours(1) > DateTime.Now)
                {
                    labelError.Text = @"Výsledky nelze vložit, protože neuběhla nejméně 1 hodina od startu. ";
                    return;
                }

                var classificationMapper = new ClassificationMapper();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (ReferenceEquals(row.Cells["Position"].Value, "")) continue;

                    var driver = (int)row.Cells["ID"].Value;
                    
                    var position = (int?)row.Cells["Position"].Value;
                    var classification = classificationMapper.SelectGpDriver(_gpId, driver);

                    if (position == null || position == 0) continue;
                    if (classification == null)
                    {
                        classificationMapper.Insert(_gpId, driver, (int)position);
                    }
                    else
                    {
                        classificationMapper.Edit(_gpId, driver, (int)position);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
