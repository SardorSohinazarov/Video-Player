using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer.URL = openFileDialog.FileName;
            }
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
    }
}
