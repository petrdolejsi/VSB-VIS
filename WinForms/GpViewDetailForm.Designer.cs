namespace WinForms
{
    partial class GpViewDetailForm
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
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonGpEdit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCircuit = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelLenght = new System.Windows.Forms.Label();
            this.labelLaps = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.labelNameEdit = new System.Windows.Forms.Label();
            this.labelCircuitEdit = new System.Windows.Forms.Label();
            this.labelDateEdit = new System.Windows.Forms.Label();
            this.labelLenghtEdit = new System.Windows.Forms.Label();
            this.labelLapsEdit = new System.Windows.Forms.Label();
            this.labelStateEdit = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(318, 61);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 10;
            this.buttonNext.Text = "Další";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(212, 61);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(75, 23);
            this.buttonPrev.TabIndex = 9;
            this.buttonPrev.Text = "Předchozí";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonGpEdit
            // 
            this.buttonGpEdit.Enabled = false;
            this.buttonGpEdit.Location = new System.Drawing.Point(755, 9);
            this.buttonGpEdit.Name = "buttonGpEdit";
            this.buttonGpEdit.Size = new System.Drawing.Size(117, 23);
            this.buttonGpEdit.TabIndex = 8;
            this.buttonGpEdit.Text = "Upravit GP";
            this.buttonGpEdit.UseVisualStyleBackColor = true;
            this.buttonGpEdit.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelCircuit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelDate, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelLenght, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelLaps, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelState, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelNameEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCircuitEdit, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelDateEdit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelLenghtEdit, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelLapsEdit, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelStateEdit, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(58, 124);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 292);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // labelCircuit
            // 
            this.labelCircuit.AutoSize = true;
            this.labelCircuit.Location = new System.Drawing.Point(3, 48);
            this.labelCircuit.Name = "labelCircuit";
            this.labelCircuit.Size = new System.Drawing.Size(36, 13);
            this.labelCircuit.TabIndex = 1;
            this.labelCircuit.Text = "Okruh";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(3, 96);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(38, 13);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "Datum";
            // 
            // labelLenght
            // 
            this.labelLenght.AutoSize = true;
            this.labelLenght.Location = new System.Drawing.Point(3, 144);
            this.labelLenght.Name = "labelLenght";
            this.labelLenght.Size = new System.Drawing.Size(65, 13);
            this.labelLenght.TabIndex = 3;
            this.labelLenght.Text = "Déla okruhu";
            // 
            // labelLaps
            // 
            this.labelLaps.AutoSize = true;
            this.labelLaps.Location = new System.Drawing.Point(3, 192);
            this.labelLaps.Name = "labelLaps";
            this.labelLaps.Size = new System.Drawing.Size(52, 13);
            this.labelLaps.TabIndex = 4;
            this.labelLaps.Text = "Počet kol";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(3, 240);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(26, 13);
            this.labelState.TabIndex = 5;
            this.labelState.Text = "Stát";
            // 
            // labelNameEdit
            // 
            this.labelNameEdit.Location = new System.Drawing.Point(103, 0);
            this.labelNameEdit.Name = "labelNameEdit";
            this.labelNameEdit.Size = new System.Drawing.Size(200, 23);
            this.labelNameEdit.TabIndex = 6;
            // 
            // labelCircuitEdit
            // 
            this.labelCircuitEdit.Location = new System.Drawing.Point(103, 48);
            this.labelCircuitEdit.Name = "labelCircuitEdit";
            this.labelCircuitEdit.Size = new System.Drawing.Size(200, 23);
            this.labelCircuitEdit.TabIndex = 7;
            // 
            // labelDateEdit
            // 
            this.labelDateEdit.Location = new System.Drawing.Point(103, 96);
            this.labelDateEdit.Name = "labelDateEdit";
            this.labelDateEdit.Size = new System.Drawing.Size(200, 23);
            this.labelDateEdit.TabIndex = 8;
            // 
            // labelLenghtEdit
            // 
            this.labelLenghtEdit.Location = new System.Drawing.Point(103, 144);
            this.labelLenghtEdit.Name = "labelLenghtEdit";
            this.labelLenghtEdit.Size = new System.Drawing.Size(200, 23);
            this.labelLenghtEdit.TabIndex = 9;
            // 
            // labelLapsEdit
            // 
            this.labelLapsEdit.Location = new System.Drawing.Point(103, 192);
            this.labelLapsEdit.Name = "labelLapsEdit";
            this.labelLapsEdit.Size = new System.Drawing.Size(200, 23);
            this.labelLapsEdit.TabIndex = 10;
            // 
            // labelStateEdit
            // 
            this.labelStateEdit.Location = new System.Drawing.Point(103, 240);
            this.labelStateEdit.Name = "labelStateEdit";
            this.labelStateEdit.Size = new System.Drawing.Size(200, 23);
            this.labelStateEdit.TabIndex = 11;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Název";
            // 
            // labelHeader
            // 
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(726, 38);
            this.labelHeader.TabIndex = 6;
            this.labelHeader.Text = "Výpis GP";
            // 
            // GpViewDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonGpEdit);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.labelHeader);
            this.Name = "GpViewDetailForm";
            this.Text = "Výpis GP";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonGpEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelCircuit;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelLenght;
        private System.Windows.Forms.Label labelLaps;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label labelNameEdit;
        private System.Windows.Forms.Label labelCircuitEdit;
        private System.Windows.Forms.Label labelDateEdit;
        private System.Windows.Forms.Label labelLenghtEdit;
        private System.Windows.Forms.Label labelLapsEdit;
        private System.Windows.Forms.Label labelStateEdit;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelHeader;
    }
}