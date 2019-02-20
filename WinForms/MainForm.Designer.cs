using System;

namespace WinForms
{
    partial class MainForm
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
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDrivers;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.teamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grandPrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toDoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItemDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripMenuItemDrivers
            // 
            ToolStripMenuItemDrivers.Font = new System.Drawing.Font("Segoe UI", 9F);
            ToolStripMenuItemDrivers.Name = "ToolStripMenuItemDrivers";
            ToolStripMenuItemDrivers.Size = new System.Drawing.Size(50, 20);
            ToolStripMenuItemDrivers.Text = "Jezdci";
            ToolStripMenuItemDrivers.Click += new System.EventHandler(this.ToolStripMenuItemDrivers_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ToolStripMenuItemDrivers,
            this.teamsToolStripMenuItem,
            this.grandPrixToolStripMenuItem,
            this.toDoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = ToolStripMenuItemDrivers;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // teamsToolStripMenuItem
            // 
            this.teamsToolStripMenuItem.Name = "teamsToolStripMenuItem";
            this.teamsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.teamsToolStripMenuItem.Text = "Týmy";
            this.teamsToolStripMenuItem.Click += new System.EventHandler(this.teamsToolStripMenuItem_Click);
            // 
            // grandPrixToolStripMenuItem
            // 
            this.grandPrixToolStripMenuItem.Name = "grandPrixToolStripMenuItem";
            this.grandPrixToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.grandPrixToolStripMenuItem.Text = "Grand Prix";
            this.grandPrixToolStripMenuItem.Click += new System.EventHandler(this.grandPrixToolStripMenuItem_Click);
            // 
            // toDoToolStripMenuItem
            // 
            this.toDoToolStripMenuItem.Name = "toDoToolStripMenuItem";
            this.toDoToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toDoToolStripMenuItem.Text = "ToDo";
            this.toDoToolStripMenuItem.Click += new System.EventHandler(this.toDoToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "IS sezóny Formule 1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem teamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grandPrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toDoToolStripMenuItem;
    }
}