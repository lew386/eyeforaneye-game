using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
//using System.Timers;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace eyeforaneye_game
{
    public partial class MainForm : Form
    {
        int gameWidth = 320;
        int gameHeight = 240;

        int internalWidth = 320;
        int internalHeight = 200;
        Rectangle rctInternal = new Rectangle(0, 0, 320, 200);
        Bitmap bm = new Bitmap(320, 200);

        Graphics g;

        bool gameRunning = false;
        bool fullscreen = false;
        NearestNeighborPictureBox onscreen = new NearestNeighborPictureBox();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bm);
            ClearScreen(Color.Black);
            onscreen.BackColor = SystemColors.Control;
            onscreen.BorderStyle = BorderStyle.None;
            onscreen.SizeMode = PictureBoxSizeMode.StretchImage;
            onscreen.Dock = DockStyle.Fill;
            this.Controls.Add(onscreen);
            this.ClientSize = new Size(gameWidth, gameHeight);
           
            ClearScreen(Color.Black);
            Timer t = new Timer();
            t.Interval = 1000 / 60;
            t.Tick += t_Tick;
            t.Enabled = true;
            
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //g.Clear(Color.Black);
            Random rnd = new Random();
            int x = rnd.Next(0, internalWidth - 1);
            g.FillRectangle(RandomBrush(), x, 0, 1, internalHeight);
            
            UpdateScreen();
        }

        private void UpdateScreen()
        {
           g.Save();
           onscreen.Image = bm;
        }

        private void ClearScreen(Color c)
        {
            g.Clear(c);
            g.Save();
        }

        private Color RandomColor()
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            return Color.FromArgb(r, g, b);
        }

        private Pen RandomPen()
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            return new Pen(Color.FromArgb(r, g, b));
        }

        private Brush RandomBrush()
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            return new SolidBrush(Color.FromArgb(r, g, b));
        }
    }
}
