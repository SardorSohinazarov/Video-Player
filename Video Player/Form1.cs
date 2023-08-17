using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Video_Player
{
    public partial class Form1 : Form
    {
        private Size formOriginalSize;
        private Rectangle recMP;
        List<string> listOfExtensions = new List<string>() {".pdf",".xls", ".xlsx",".pptx", ".ppt", ".lnk", ".txt", ".doc", ".docx" }; 

        private string rootPath;
        public Form1()
        {
            InitializeComponent();

            listBox1.Visible = false;

            this.Resize += Form1_Resize;
            formOriginalSize = this.Size;
            recMP = new Rectangle(axWindowsMediaPlayer.Location, axWindowsMediaPlayer.Size);
        }

        void Form1_Resize(object sender, EventArgs e)
        {
            resize_Control(axWindowsMediaPlayer, recMP);
        }
        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);

        }

        private void ochishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if(dialog.SelectedPath != "")
            {
                rootPath = dialog.SelectedPath;
                string[] pathes = Directory.GetFiles(rootPath);

                listBox1.Items.Clear();


                foreach (string path in pathes)
                {
                    string ex = Path.GetExtension(path);
                    if(! listOfExtensions.Contains(ex))
                        listBox1.Items.Add(Path.GetFileName(path));
                }
            }
        }
        
        private void selectedPlay()
        {
            var selectedMediaPath = listBox1.GetItemText(listBox1.SelectedItem);
            axWindowsMediaPlayer.URL = Path.Combine(rootPath, selectedMediaPath);
            axWindowsMediaPlayer.Ctlcontrols.play();
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.Visible = false;

            if (e.KeyCode == Keys.Enter) 
            { 
                selectedPlay();
            }
        }

        private void playlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Visible = ! listBox1.Visible;
        }

        private void listBox1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            listBox1.Visible = false;

            selectedPlay();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Visible= false;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer.URL = openFileDialog.FileName;
            }
        }
    }
}
