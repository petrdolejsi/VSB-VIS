namespace WinForms
{
    partial class TeamsViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelHeader = new System.Windows.Forms.Label();
            this.buttonTeamAdd = new System.Windows.Forms.Button();
            this.dataGridViewTeams = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(726, 38);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Výpis týmů";
            // 
            // buttonTeamAdd
            // 
            this.buttonTeamAdd.Enabled = false;
            this.buttonTeamAdd.Location = new System.Drawing.Point(755, 9);
            this.buttonTeamAdd.Name = "buttonTeamAdd";
            this.buttonTeamAdd.Size = new System.Drawing.Size(117, 23);
            this.buttonTeamAdd.TabIndex = 2;
            this.buttonTeamAdd.Text = "Přidat tým";
            this.buttonTeamAdd.UseVisualStyleBackColor = true;
            this.buttonTeamAdd.Visible = false;
            // 
            // dataGridViewTeams
            // 
            this.dataGridViewTeams.AllowUserToAddRows = false;
            this.dataGridViewTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NameOfTeam,
            this.Button});
            this.dataGridViewTeams.Location = new System.Drawing.Point(17, 50);
            this.dataGridViewTeams.Name = "dataGridViewTeams";
            this.dataGridViewTeams.Size = new System.Drawing.Size(855, 499);
            this.dataGridViewTeams.TabIndex = 3;
            this.dataGridViewTeams.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTeams_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // NameOfTeam
            // 
            this.NameOfTeam.HeaderText = "Název";
            this.NameOfTeam.Name = "NameOfTeam";
            // 
            // Button
            // 
            this.Button.HeaderText = "";
            this.Button.Name = "Button";
            this.Button.Text = "Zobrazit tým";
            this.Button.UseColumnTextForButtonValue = true;
            // 
            // TeamsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.dataGridViewTeams);
            this.Controls.Add(this.buttonTeamAdd);
            this.Controls.Add(this.labelHeader);
            this.Name = "TeamsViewForm";
            this.Text = "Výpis týmů";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button buttonTeamAdd;
        private System.Windows.Forms.DataGridView dataGridViewTeams;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfTeam;
        private System.Windows.Forms.DataGridViewButtonColumn Button;
    }
}