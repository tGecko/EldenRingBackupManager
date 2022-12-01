using EldenRingBackups.Properties;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace EldenRingBackups
{
    public partial class EldenRingBackups : Form
    {
        public EldenRingBackups()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        
        Timer tmr;
        const int TimerInterval = 3000;
        FileInfo[] backupFiles;
        long backupDirSize;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            tmr = new Timer();
            tmr.Interval = TimerInterval;
            string EldenRingFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EldenRing");

            if (Properties.Settings.Default.saveDir == String.Empty)
            {
                //Apparently first start. Find Save Folder
                DirectoryInfo di = new DirectoryInfo(EldenRingFolder);
                DirectoryInfo[] directories = di.GetDirectories();
                int numFolders = 0;
                foreach (DirectoryInfo dinfo in directories)
                {
                    if (dinfo.Name.StartsWith("7656"))
                        numFolders++;
                    //Steam IDs always start with 7656(?)

                }
                if (numFolders == 1)
                {
                    Properties.Settings.Default.saveDir = directories[0].FullName;
                    Properties.Settings.Default.Save();
                    SettingsChanged();
                }
                else
                //found anything but exactly 1 save folder
                {
                    {
                        MessageBox.Show("Could not automatically find Elden Ring save folder.\nPlease manually select the folder containing ER0000.sl2");
                        ChangeSaveDirectoryManually();
                    }
                }

            }

            if (Properties.Settings.Default.backupDir == string.Empty)
            {
                //First start: Set backup directory to save directory\Backups and create it
                Properties.Settings.Default.backupDir = Path.Combine(EldenRingFolder, "Backups");
                Properties.Settings.Default.Save();
            }
            SettingsChanged();
            RefreshSaves();
            ResetStatusLabel(null, null);

        }


        private void changeSaveDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSaveDirectoryManually();
        }

        private void ChangeSaveDirectoryManually()
        {
            var fbd = new FolderBrowserDialog();
            if (Properties.Settings.Default.saveDir != string.Empty)
            {
                fbd.SelectedPath = Properties.Settings.Default.saveDir;
            }
            else
            {
                fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                //Surely this folder never changes..

            }
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                Properties.Settings.Default.saveDir = fbd.SelectedPath;
                Properties.Settings.Default.Save();
                SettingsChanged();
            }
            else
            {
                //ToDo: Do something if user cancels
            }
            fbd.Dispose();
        }
        private void ChangeBackupDirectoryManually()
        {
            var fbd = new FolderBrowserDialog();
            if (Properties.Settings.Default.backupDir != string.Empty)
            {
                fbd.SelectedPath = Properties.Settings.Default.backupDir;
            }
            else
            {
                fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                //Surely this folder never changes..

            }
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                Properties.Settings.Default.backupDir = fbd.SelectedPath;
                Properties.Settings.Default.Save();
                Directory.CreateDirectory(Properties.Settings.Default.backupDir);
                SettingsChanged();
            }
            else
            {
                //ToDo: Do something if user cancels
            }
            fbd.Dispose();
            RefreshSaves();

        }

        private void changeBackupDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBackupDirectoryManually();
        }

        private void SettingsChanged()
        {
            changeSaveDirectoryToolStripMenuItem.Text = ("SaveDir: " + Properties.Settings.Default.saveDir);
            changeBackupDirectoryToolStripMenuItem.Text = ("BackupDir: " + Properties.Settings.Default.backupDir);
            dontWarnOnQuickLoaddangerToolStripMenuItem.Checked = Properties.Settings.Default.dontWarnOnQuickLoad;
            TmrAutoSave.Enabled = Properties.Settings.Default.autoSave;
            TmrAutoSave.Interval = Properties.Settings.Default.autoSaveTimer * 1000 * 60; //minutes to milliseconds
            playSoundWhenAutoSavingToolStripMenuItem.Checked = Properties.Settings.Default.autoSaveSound;
            autoSavetoolStripMenuItem1.Checked = Properties.Settings.Default.autoSave;
            autoSaveInterval.Text = Properties.Settings.Default.autoSaveTimer.ToString();
            enableHotkeysF5AndF9ToolStripMenuItem.Checked = Properties.Settings.Default.hotkeysEnabled;
            if (Properties.Settings.Default.hotkeysEnabled)
            {
                RegisterHotKey(this.Handle, 0, 0, Keys.F5.GetHashCode());
                RegisterHotKey(this.Handle, 1, 0, Keys.F9.GetHashCode());
            }
            else
            {
                UnregisterHotKey(this.Handle, 0);
                UnregisterHotKey(this.Handle, 1);
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                switch (id)
                {
                    case 0:
                        CopySave("QuickSave");
                        SystemSounds.Beep.Play();
                        break;

                    case 1:
                        var directory = new DirectoryInfo(Properties.Settings.Default.backupDir);

                        var newestSave = directory.GetFiles()
                         .OrderByDescending(f => f.CreationTime)
                         .First();

                        LoadSave(newestSave.FullName);

                        SystemSounds.Beep.Play();

                        break;
                }
            }
        }

        private void btnQuickSave_Click(object sender, EventArgs e)
        {
            CopySave("QuickSave");
        }
        private bool CopySave(string reason = "")
        {
            string saveDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            string backupFileName = Path.Combine(Properties.Settings.Default.backupDir, reason + "-" + "ER0000.sl2" + saveDate);
            try
            {
                File.Copy(Path.Combine(Properties.Settings.Default.saveDir, "ER0000.sl2"), backupFileName);
                ChangeStatus("Backup made");
                RefreshSaves();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                ChangeStatus("Backup failed.");
                return false;
            }


        }
        private void ChangeStatus(string status)
        {
            statusLabel.Text = status;
            tmr.Enabled = true;
            tmr.Tick += new EventHandler(ResetStatusLabel);
        }
        private void ResetStatusLabel(object sender, EventArgs e)
        {
            statusLabel.Text = "Ready -  BackupDir size: " + backupDirSize.ToString() + "MB";
            tmr.Enabled = false;
        }
        private void LoadSave(string savePath)
        {
            File.Delete(Path.Combine(Properties.Settings.Default.saveDir, "ER0000.sl2"));
            File.Copy(savePath, Path.Combine(Properties.Settings.Default.saveDir, "ER0000.sl2"));
            ChangeStatus(Path.GetFileName(savePath) + " loaded.");
        }

        private void btnQuickLoad_Click(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.dontWarnOnQuickLoad)
            {
                DialogResult res = MessageBox.Show("A backup of your current save file will be made and your current save file will be replaced by the newest save in the backup folder.", "Warning", MessageBoxButtons.OKCancel);
                if (res != DialogResult.OK)
                {
                    return;
                }
            }
            var directory = new DirectoryInfo(Properties.Settings.Default.backupDir);

            //get newest save file before making a backup
            var newestSave = directory.GetFiles()
             .OrderByDescending(f => f.CreationTime)
             .First();

            if (CopySave("QuickLoad"))
            {
                //only replace the save if the backup was successful
                LoadSave(newestSave.FullName);
            }
        }

        private void dontWarnOnQuickLoaddangerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.dontWarnOnQuickLoad)
            {
                Properties.Settings.Default.dontWarnOnQuickLoad = false;
                Properties.Settings.Default.Save();
                SettingsChanged();
            }
            else
            {
                DialogResult res = MessageBox.Show("Your save file will be replaced if you load a save without further warnings.\nA Backup will be made in any case (except when using hotkeys).", "Warning", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    Properties.Settings.Default.dontWarnOnQuickLoad = true;
                    Properties.Settings.Default.Save();
                    SettingsChanged();
                }
            }
        }



        private void TmrAutoSave_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autoSaveSound)
                SystemSounds.Beep.Play();
            CopySave("AutoSave");
        }


        private void RefreshSaves()
        {
            if(!(Directory.Exists(Properties.Settings.Default.backupDir))) {
                Directory.CreateDirectory(Properties.Settings.Default.backupDir);
            }
            LstSaves.Items.Clear();
            var directory = new DirectoryInfo(Properties.Settings.Default.backupDir);
            lblCreationTime.Text = string.Empty;
            //get newest save file before making a backup
            FileInfo[] backupFilesUnsorted = directory.GetFiles();
            backupFiles = backupFilesUnsorted.OrderByDescending(item => item.CreationTime).ToArray();


            foreach (FileInfo backupFile in backupFiles)
            {
                LstSaves.Items.Add(backupFile.Name);
            }
            backupDirSize = DirSize(new DirectoryInfo(Properties.Settings.Default.backupDir)) / 1024 / 1024;
            ResetStatusLabel(null, null);
        }
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            return size;

        }
        private void BtnLoadSelected_Click(object sender, EventArgs e)
        {
            if (LstSaves.SelectedItems.Count == 1)
            {
                if (!(Properties.Settings.Default.dontWarnOnQuickLoad))
                {
                    DialogResult res = MessageBox.Show("A backup of your current save file will be made and your current save file will be replaced by the selected file.", "Warning", MessageBoxButtons.OKCancel);
                    if (res != DialogResult.OK)
                    {
                        return;
                    }
                }



                FileInfo[] selectedSave = backupFiles.Where(item => item.Name == LstSaves.Text).ToArray();
                if (selectedSave.Length == 1)
                {
                    if (CopySave("Load"))
                    {
                        //only replace the save if the backup was successful
                        LoadSave(selectedSave[0].FullName);
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select one file to load.", "Error");
            }
        }

        private void LstSaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstSaves.SelectedItems.Count == 1)
            {
                FileInfo[] selectedSave = backupFiles.Where(item => item.Name == LstSaves.Text).ToArray();
                if (selectedSave.Length == 1)
                {
                    lblCreationTime.Text = "Created: " + selectedSave[0].CreationTime.ToString();
                }
            }
            else
            {
                lblCreationTime.Text = string.Empty;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to delete the selected files?", "Warning", MessageBoxButtons.OKCancel);
            if (res != DialogResult.OK)
            {
                return;
            }
            foreach (string selectedItem in LstSaves.SelectedItems)
            {
                FileInfo[] selectedSave = backupFiles.Where(item => item.Name == selectedItem).ToArray();
                if (selectedSave.Length == 1)
                {
                    File.Delete(selectedSave[0].FullName);
                }
            }
            RefreshSaves();
        }

        private void playSoundWhenAutoSavingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autoSaveSound)
            {
                Properties.Settings.Default.autoSaveSound = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.autoSaveSound = true;
                Properties.Settings.Default.Save();
            }

            SettingsChanged();
        }

        private void autoSavetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autoSave)
            {
                Properties.Settings.Default.autoSave = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.autoSave = true;
                Properties.Settings.Default.Save();
            }

            SettingsChanged();
        }

        private void autoSaveInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoSaveTimer = int.Parse(autoSaveInterval.Text);
            Properties.Settings.Default.Save();
            SettingsChanged();
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            if (LstSaves.SelectedItems.Count == 1)
            {
                string input = string.Empty;
                if(ShowInputDialog(ref input) == DialogResult.OK)
                {
                    FileInfo[] selectedSave = backupFiles.Where(item => item.Name == LstSaves.Text).ToArray();
                    if(input != string.Empty)
                    {
                        selectedSave[0].MoveTo(Path.Combine(Properties.Settings.Default.backupDir,input));
                        RefreshSaves();
                    }
                    else
                    {
                        MessageBox.Show("New name cannot be empty.");
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select one file to rename.");
            }
        }
        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();


            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Name";

            TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            
            input = textBox.Text;
            return result;
        }

        private void enableHotkeysF5AndF9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.hotkeysEnabled)
            {
                Properties.Settings.Default.hotkeysEnabled = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Hotkeys enabled. Press F5 to immediately save and F9 to immediately load the newest save.\nThis overwrites your current save.");
                Properties.Settings.Default.hotkeysEnabled = true;
                Properties.Settings.Default.Save();
            }

            SettingsChanged();
        }
    }
}
