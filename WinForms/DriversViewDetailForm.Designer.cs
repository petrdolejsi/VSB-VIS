namespace WinForms
{
    partial class DriversViewDetailForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.labelDateOfBirth = new System.Windows.Forms.Label();
            this.labelTeam = new System.Windows.Forms.Label();
            this.labelNationaility = new System.Windows.Forms.Label();
            this.labelFirstNameEdit = new System.Windows.Forms.Label();
            this.labelLastNameEdit = new System.Windows.Forms.Label();
            this.labelNumberEdit = new System.Windows.Forms.Label();
            this.labelDateOfBirthEdit = new System.Windows.Forms.Label();
            this.labelTeamEdit = new System.Windows.Forms.Label();
            this.labelNationailityEdit = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.buttonDriverEdit = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(726, 38);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Výpis jezdce";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelLastName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelNumber, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelDateOfBirth, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelTeam, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelNationaility, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelFirstNameEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelLastNameEdit, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelNumberEdit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelDateOfBirthEdit, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelTeamEdit, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelNationailityEdit, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelFirstName, 0, 0);
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
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(3, 48);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(48, 13);
            this.labelLastName.TabIndex = 1;
            this.labelLastName.Text = "Příjmení";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(3, 96);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(77, 13);
            this.labelNumber.TabIndex = 2;
            this.labelNumber.Text = "Startovní číslo";
            // 
            // labelDateOfBirth
            // 
            this.labelDateOfBirth.AutoSize = true;
            this.labelDateOfBirth.Location = new System.Drawing.Point(3, 144);
            this.labelDateOfBirth.Name = "labelDateOfBirth";
            this.labelDateOfBirth.Size = new System.Drawing.Size(83, 13);
            this.labelDateOfBirth.TabIndex = 3;
            this.labelDateOfBirth.Text = "Datum narození";
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Location = new System.Drawing.Point(3, 192);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(27, 13);
            this.labelTeam.TabIndex = 4;
            this.labelTeam.Text = "Tým";
            // 
            // labelNationaility
            // 
            this.labelNationaility.AutoSize = true;
            this.labelNationaility.Location = new System.Drawing.Point(3, 240);
            this.labelNationaility.Name = "labelNationaility";
            this.labelNationaility.Size = new System.Drawing.Size(56, 13);
            this.labelNationaility.TabIndex = 5;
            this.labelNationaility.Text = "Národnost";
            // 
            // labelFirstNameEdit
            // 
            this.labelFirstNameEdit.Location = new System.Drawing.Point(103, 0);
            this.labelFirstNameEdit.Name = "labelFirstNameEdit";
            this.labelFirstNameEdit.Size = new System.Drawing.Size(200, 23);
            this.labelFirstNameEdit.TabIndex = 6;
            // 
            // labelLastNameEdit
            // 
            this.labelLastNameEdit.Location = new System.Drawing.Point(103, 48);
            this.labelLastNameEdit.Name = "labelLastNameEdit";
            this.labelLastNameEdit.Size = new System.Drawing.Size(200, 23);
            this.labelLastNameEdit.TabIndex = 7;
            // 
            // labelNumberEdit
            // 
            this.labelNumberEdit.Location = new System.Drawing.Point(103, 96);
            this.labelNumberEdit.Name = "labelNumberEdit";
            this.labelNumberEdit.Size = new System.Drawing.Size(200, 23);
            this.labelNumberEdit.TabIndex = 8;
            // 
            // labelDateOfBirthEdit
            // 
            this.labelDateOfBirthEdit.Location = new System.Drawing.Point(103, 144);
            this.labelDateOfBirthEdit.Name = "labelDateOfBirthEdit";
            this.labelDateOfBirthEdit.Size = new System.Drawing.Size(200, 23);
            this.labelDateOfBirthEdit.TabIndex = 9;
            // 
            // labelTeamEdit
            // 
            this.labelTeamEdit.Location = new System.Drawing.Point(103, 192);
            this.labelTeamEdit.Name = "labelTeamEdit";
            this.labelTeamEdit.Size = new System.Drawing.Size(200, 23);
            this.labelTeamEdit.TabIndex = 10;
            // 
            // labelNationailityEdit
            // 
            this.labelNationailityEdit.Location = new System.Drawing.Point(103, 240);
            this.labelNationailityEdit.Name = "labelNationailityEdit";
            this.labelNationailityEdit.Size = new System.Drawing.Size(200, 23);
            this.labelNationailityEdit.TabIndex = 11;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(3, 0);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(38, 13);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "Jméno";
            // 
            // buttonDriverEdit
            // 
            this.buttonDriverEdit.Location = new System.Drawing.Point(755, 9);
            this.buttonDriverEdit.Name = "buttonDriverEdit";
            this.buttonDriverEdit.Size = new System.Drawing.Size(117, 23);
            this.buttonDriverEdit.TabIndex = 3;
            this.buttonDriverEdit.Text = "Upravit jezdce";
            this.buttonDriverEdit.UseVisualStyleBackColor = true;
            this.buttonDriverEdit.Visible = false;
            this.buttonDriverEdit.Click += new System.EventHandler(this.buttonDriverEdit_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(212, 61);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(75, 23);
            this.buttonPrev.TabIndex = 4;
            this.buttonPrev.Text = "Předchozí";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(318, 61);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.Text = "Další";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // DriversViewDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonDriverEdit);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.labelHeader);
            this.Name = "DriversViewDetailForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Výpis jezdce";
            this.Load += new System.EventHandler(this.DriversViewDetailForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label labelDateOfBirth;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.Label labelNationaility;
        private System.Windows.Forms.Label labelFirstNameEdit;
        private System.Windows.Forms.Label labelLastNameEdit;
        private System.Windows.Forms.Label labelNumberEdit;
        private System.Windows.Forms.Label labelDateOfBirthEdit;
        private System.Windows.Forms.Label labelTeamEdit;
        private System.Windows.Forms.Label labelNationailityEdit;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Button buttonDriverEdit;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
    }
}