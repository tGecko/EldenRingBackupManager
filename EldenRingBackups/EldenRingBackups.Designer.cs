namespace EldenRingBackups
{
    partial class EldenRingBackups
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSaveDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBackupDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontWarnOnQuickLoaddangerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playSoundWhenAutoSavingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSavetoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSaveInterval = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TmrAutoSave = new System.Windows.Forms.Timer(this.components);
            this.LstSaves = new System.Windows.Forms.ListBox();
            this.BtnLoadSelected = new System.Windows.Forms.Button();
            this.lblCreationTime = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnRename = new System.Windows.Forms.Button();
            this.enableHotkeysF5AndF9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuickSave = new System.Windows.Forms.Button();
            this.btnQuickLoad = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(261, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSaveDirectoryToolStripMenuItem,
            this.changeBackupDirectoryToolStripMenuItem,
            this.dontWarnOnQuickLoaddangerToolStripMenuItem,
            this.playSoundWhenAutoSavingToolStripMenuItem,
            this.enableHotkeysF5AndF9ToolStripMenuItem,
            this.autoSavetoolStripMenuItem1,
            this.autoSaveInterval});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // changeSaveDirectoryToolStripMenuItem
            // 
            this.changeSaveDirectoryToolStripMenuItem.Name = "changeSaveDirectoryToolStripMenuItem";
            this.changeSaveDirectoryToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.changeSaveDirectoryToolStripMenuItem.Text = "Change Save Directory";
            this.changeSaveDirectoryToolStripMenuItem.Click += new System.EventHandler(this.changeSaveDirectoryToolStripMenuItem_Click);
            // 
            // changeBackupDirectoryToolStripMenuItem
            // 
            this.changeBackupDirectoryToolStripMenuItem.Name = "changeBackupDirectoryToolStripMenuItem";
            this.changeBackupDirectoryToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.changeBackupDirectoryToolStripMenuItem.Text = "Change Backup Directory";
            this.changeBackupDirectoryToolStripMenuItem.Click += new System.EventHandler(this.changeBackupDirectoryToolStripMenuItem_Click);
            // 
            // dontWarnOnQuickLoaddangerToolStripMenuItem
            // 
            this.dontWarnOnQuickLoaddangerToolStripMenuItem.Name = "dontWarnOnQuickLoaddangerToolStripMenuItem";
            this.dontWarnOnQuickLoaddangerToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.dontWarnOnQuickLoaddangerToolStripMenuItem.Text = "Don\'t warn on Load (careful!)";
            this.dontWarnOnQuickLoaddangerToolStripMenuItem.Click += new System.EventHandler(this.dontWarnOnQuickLoaddangerToolStripMenuItem_Click);
            // 
            // playSoundWhenAutoSavingToolStripMenuItem
            // 
            this.playSoundWhenAutoSavingToolStripMenuItem.Name = "playSoundWhenAutoSavingToolStripMenuItem";
            this.playSoundWhenAutoSavingToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.playSoundWhenAutoSavingToolStripMenuItem.Text = "Play sound when auto saving";
            this.playSoundWhenAutoSavingToolStripMenuItem.Click += new System.EventHandler(this.playSoundWhenAutoSavingToolStripMenuItem_Click);
            // 
            // autoSavetoolStripMenuItem1
            // 
            this.autoSavetoolStripMenuItem1.Name = "autoSavetoolStripMenuItem1";
            this.autoSavetoolStripMenuItem1.Size = new System.Drawing.Size(285, 22);
            this.autoSavetoolStripMenuItem1.Text = "Autosave (set interval in minutes below)";
            this.autoSavetoolStripMenuItem1.Click += new System.EventHandler(this.autoSavetoolStripMenuItem1_Click);
            // 
            // autoSaveInterval
            // 
            this.autoSaveInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoSaveInterval.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20",
            "30"});
            this.autoSaveInterval.Name = "autoSaveInterval";
            this.autoSaveInterval.Size = new System.Drawing.Size(121, 23);
            this.autoSaveInterval.SelectedIndexChanged += new System.EventHandler(this.autoSaveInterval_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(261, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // TmrAutoSave
            // 
            this.TmrAutoSave.Tick += new System.EventHandler(this.TmrAutoSave_Tick);
            // 
            // LstSaves
            // 
            this.LstSaves.FormattingEnabled = true;
            this.LstSaves.Location = new System.Drawing.Point(12, 27);
            this.LstSaves.Name = "LstSaves";
            this.LstSaves.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LstSaves.Size = new System.Drawing.Size(236, 238);
            this.LstSaves.TabIndex = 12;
            this.LstSaves.SelectedIndexChanged += new System.EventHandler(this.LstSaves_SelectedIndexChanged);
            // 
            // BtnLoadSelected
            // 
            this.BtnLoadSelected.Location = new System.Drawing.Point(12, 284);
            this.BtnLoadSelected.Name = "BtnLoadSelected";
            this.BtnLoadSelected.Size = new System.Drawing.Size(236, 23);
            this.BtnLoadSelected.TabIndex = 13;
            this.BtnLoadSelected.Text = "Load selected savefile";
            this.BtnLoadSelected.UseVisualStyleBackColor = true;
            this.BtnLoadSelected.Click += new System.EventHandler(this.BtnLoadSelected_Click);
            // 
            // lblCreationTime
            // 
            this.lblCreationTime.AutoSize = true;
            this.lblCreationTime.Location = new System.Drawing.Point(12, 268);
            this.lblCreationTime.Name = "lblCreationTime";
            this.lblCreationTime.Size = new System.Drawing.Size(35, 13);
            this.lblCreationTime.TabIndex = 14;
            this.lblCreationTime.Text = "label2";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(12, 313);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(236, 23);
            this.BtnDelete.TabIndex = 15;
            this.BtnDelete.Text = "Delete selected savefile(s)";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnRename
            // 
            this.BtnRename.Location = new System.Drawing.Point(12, 342);
            this.BtnRename.Name = "BtnRename";
            this.BtnRename.Size = new System.Drawing.Size(236, 23);
            this.BtnRename.TabIndex = 16;
            this.BtnRename.Text = "Rename selected savefile(s)";
            this.BtnRename.UseVisualStyleBackColor = true;
            this.BtnRename.Click += new System.EventHandler(this.BtnRename_Click);
            // 
            // enableHotkeysF5AndF9ToolStripMenuItem
            // 
            this.enableHotkeysF5AndF9ToolStripMenuItem.Name = "enableHotkeysF5AndF9ToolStripMenuItem";
            this.enableHotkeysF5AndF9ToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.enableHotkeysF5AndF9ToolStripMenuItem.Text = "Enable Hotkeys (F5 and F9)";
            this.enableHotkeysF5AndF9ToolStripMenuItem.Click += new System.EventHandler(this.enableHotkeysF5AndF9ToolStripMenuItem_Click);
            // 
            // btnQuickSave
            // 
            this.btnQuickSave.Location = new System.Drawing.Point(166, 400);
            this.btnQuickSave.Name = "btnQuickSave";
            this.btnQuickSave.Size = new System.Drawing.Size(82, 23);
            this.btnQuickSave.TabIndex = 4;
            this.btnQuickSave.Text = "Quick Save";
            this.btnQuickSave.UseVisualStyleBackColor = true;
            this.btnQuickSave.Click += new System.EventHandler(this.btnQuickSave_Click);
            // 
            // btnQuickLoad
            // 
            this.btnQuickLoad.Location = new System.Drawing.Point(166, 371);
            this.btnQuickLoad.Name = "btnQuickLoad";
            this.btnQuickLoad.Size = new System.Drawing.Size(82, 23);
            this.btnQuickLoad.TabIndex = 5;
            this.btnQuickLoad.Text = "Quick Load";
            this.btnQuickLoad.UseVisualStyleBackColor = true;
            this.btnQuickLoad.Click += new System.EventHandler(this.btnQuickLoad_Click);
            // 
            // EldenRingBackups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 450);
            this.Controls.Add(this.BtnRename);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.lblCreationTime);
            this.Controls.Add(this.BtnLoadSelected);
            this.Controls.Add(this.LstSaves);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnQuickLoad);
            this.Controls.Add(this.btnQuickSave);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EldenRingBackups";
            this.Text = "Elden Ring Save Backup Manager v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSaveDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBackupDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontWarnOnQuickLoaddangerToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer TmrAutoSave;
        private System.Windows.Forms.ListBox LstSaves;
        private System.Windows.Forms.Button BtnLoadSelected;
        private System.Windows.Forms.Label lblCreationTime;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.ToolStripMenuItem playSoundWhenAutoSavingToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox autoSaveInterval;
        private System.Windows.Forms.ToolStripMenuItem autoSavetoolStripMenuItem1;
        private System.Windows.Forms.Button BtnRename;
        private System.Windows.Forms.ToolStripMenuItem enableHotkeysF5AndF9ToolStripMenuItem;
        private System.Windows.Forms.Button btnQuickSave;
        private System.Windows.Forms.Button btnQuickLoad;
    }
}

