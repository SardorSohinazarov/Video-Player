using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Video_Player
{
    public partial class Form1 : Form
    {
        private Size formOriginalSize;
        private Rectangle recMP;
        public Form1()
        {
            InitializeComponent();

            listBox1.Visible = false;

            this.Resize += Form1_Resize;
            formOriginalSize = this.Size;
            recMP = new Rectangle(axWindowsMediaPlayer.Location, axWindowsMediaPlayer.Size);
        }

        private void selectVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer.URL = openFileDialog.FileName;
            }
        }

        private void axWindowsMediaPlayer_Enter(object sender, EventArgs e)
        {
            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer.URL = openFileDialog.FileName;
            }*/
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
            string rootPath = dialog.SelectedPath;
            string[] pathes = Directory.GetFiles(rootPath);

            foreach (string path in pathes)
            {
                listBox1.Items.Add(path);
            }
        }

        private void mediaPlayFromPath(string path)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer.URL = openFileDialog.FileName;
            }
        }

        private void mediaPlay()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer.URL = openFileDialog.FileName;
            }
        }
        
        private void selectedPlay()
        {
            var selectedMediaPath = listBox1.GetItemText(listBox1.SelectedItem);
            axWindowsMediaPlayer.URL = selectedMediaPath;
            axWindowsMediaPlayer.Ctlcontrols.play();
        }

        private async void listBox1_DoubleClick(object sender, EventArgs e)
        {
            
            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox1.Visible = false;

            var selectedMediaPath = listBox1.GetItemText(listBox1.SelectedItem);
            axWindowsMediaPlayer.URL = selectedMediaPath;
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
            listBox1.Visible = true;
        }
    }
}
