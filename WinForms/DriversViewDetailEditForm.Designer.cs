namespace WinForms
{
    partial class DriversViewDetailEditForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxNationality = new System.Windows.Forms.ComboBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.labelDateOfBirth = new System.Windows.Forms.Label();
            this.labelTeam = new System.Windows.Forms.Label();
            this.labelNationaility = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.numericUpDownNumber = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerDateOfbirth = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.buttonDriverEdit = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxNationality, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxLastName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelLastName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelNumber, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelDateOfBirth, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelTeam, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelNationaility, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelFirstName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFirstName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownNumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerDateOfbirth, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTeam, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(63, 92);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 292);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // comboBoxNationality
            // 
            this.comboBoxNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNationality.Location = new System.Drawing.Point(103, 243);
            this.comboBoxNationality.Name = "comboBoxNationality";
            this.comboBoxNationality.Size = new System.Drawing.Size(120, 21);
            this.comboBoxNationality.TabIndex = 11;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(103, 51);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(120, 20);
            this.textBoxLastName.TabIndex = 7;
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
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(3, 0);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(38, 13);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "Jméno";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(103, 3);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(120, 20);
            this.textBoxFirstName.TabIndex = 6;
            // 
            // numericUpDownNumber
            // 
            this.numericUpDownNumber.Location = new System.Drawing.Point(103, 99);
            this.numericUpDownNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumber.Name = "numericUpDownNumber";
            this.numericUpDownNumber.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNumber.TabIndex = 8;
            this.numericUpDownNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dateTimePickerDateOfbirth
            // 
            this.dateTimePickerDateOfbirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateOfbirth.Location = new System.Drawing.Point(103, 147);
            this.dateTimePickerDateOfbirth.Name = "dateTimePickerDateOfbirth";
            this.dateTimePickerDateOfbirth.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDateOfbirth.TabIndex = 9;
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeam.Location = new System.Drawing.Point(103, 195);
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(120, 21);
            this.comboBoxTeam.TabIndex = 10;
            // 
            // labelHeader
            // 
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(726, 38);
            this.labelHeader.TabIndex = 4;
            this.labelHeader.Text = "Úprava jezdce";
            // 
            // buttonDriverEdit
            // 
            this.buttonDriverEdit.Location = new System.Drawing.Point(755, 9);
            this.buttonDriverEdit.Name = "buttonDriverEdit";
            this.buttonDriverEdit.Size = new System.Drawing.Size(117, 23);
            this.buttonDriverEdit.TabIndex = 6;
            this.buttonDriverEdit.Text = "Uložit úpravu";
            this.buttonDriverEdit.UseVisualStyleBackColor = true;
            this.buttonDriverEdit.Click += new System.EventHandler(this.ButtonDriverEdit_Click);
            // 
            // labelError
            // 
            this.labelError.ForeColor = System.Drawing.Color.Maroon;
            this.labelError.Location = new System.Drawing.Point(63, 61);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(320, 23);
            this.labelError.TabIndex = 7;
            this.labelError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DriversViewDetailEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.buttonDriverEdit);
            this.Name = "DriversViewDetailEditForm";
            this.Text = "Úprava jezdce";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label labelDateOfBirth;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.Label labelNationaility;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button buttonDriverEdit;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.ComboBox comboBoxNationality;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.NumericUpDown numericUpDownNumber;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateOfbirth;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.Label labelError;
    }
}