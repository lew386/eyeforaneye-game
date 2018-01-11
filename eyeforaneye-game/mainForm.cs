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
        Bitmap bm = new Bitmap(320, 200, PixelFormat.Format24bppRgb);
        bool gameRunning = false;
        bool fullscreen = false;
        NearestNeighborPictureBox onscreen = new NearestNeighborPictureBox();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            onscreen.BackColor = SystemColors.Control;
            onscreen.BorderStyle = BorderStyle.None;
            onscreen.SizeMode = PictureBoxSizeMode.StretchImage;
            onscreen.Dock = DockStyle.Fill;
            
            this.Controls.Add(onscreen);
            this.ClientSize = new Size(gameWidth, gameHeight);
            ClearBitmap(Color.Black);
            onscreen.Image = bm;
            //this.Text = onscreen.Width.ToString() + " " + onscreen.Height.ToString();

            Timer t = new Timer();
            t.Interval = 1000 / 60;
            t.Tick += t_Tick;
            t.Enabled = true;
            
            //bm.Save("C:\\Users\\User\\Desktop\\testlines.bmp");
        }

        private void t_Tick(object sender, EventArgs e)
        {
            ClearBitmap(Color.Black);
            //this.FillSquare(16, 16, 64, 64, Color.Green);
            FillEllipse(0, 0, 16, 16, Color.DodgerBlue);

            DrawLine(64, 96, 64, 96, Color.Green);
            onscreen.Image = bm;
        }

        private void ClearBitmap(Color c)
        {
            for (int x = 0; x < internalWidth; x++)
            {
                for (int y = 0; y < internalHeight; y++)
                {
                    DrawPixel(x, y, c);
                }
            }
        }

        private void FillSquare(int x, int y, int w, int h, Color c)
        {
            for(int xx = x; xx < w; xx++)
            {
                for(int yy = y; yy < h; yy++)
                {
                    DrawPixel(xx, yy, c);
                }
            }
        }

        // Bresenham's filled ellipse algorithm
        private void FillEllipse(int x, int y, int w, int h, Color c)
        {
            int xradius = w / 2;
            int yradius = h / 2;
            int n = xradius;
            int xcenter = x + xradius;
            int ycenter = y + yradius;
            for(int cx = x; cx <= x + w; cx++)
            {
                DrawPixel(cx, yradius, c);
            }
            for (int j = 1; j < yradius; j++)
            {
                int ra = ycenter - j;
                int rb = ycenter + j;
                while ((w * (h - j * j) < (h * n * n)) && n != 0)
                {
                    n = n - 1;
                }

                for (int xx = xcenter - n; xx <= xcenter + n; xx++)
                {
                    DrawPixel(xx, ra, c);
                    DrawPixel(xx, rb, c);
                }
            }
        }

        

        private void DrawPixel(int x, int y, Color c)
        {
            if(x < internalWidth && x >= 0 && y < internalHeight && y >= 0)
            {
                bm.SetPixel(x, y, c);
            }
        }

        /*private void DrawLine(int x0, int y0, int x1, int y1, Color c)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int d = 2 * dy - dx;
            int y = y0;
            for(int x = x0; x <= x1; x++)
            {
                DrawPixel(x, y, c);
                if(d > 0)
                {
                    y = y + 1;
                    d -= 2 * dx;
                }
                d += 2 * dy;
            }
        }*/
        private void DrawLine(int x0, int y0, int x1, int y1, Color c)
        {
            int h = y1 - y0;
            int w = x1 - x0;
            int f = 2 * h - w;
            int yy = y0;
            for(int xx = x0; xx <= x1; xx++)
            {
                DrawPixel(xx, yy, c);
                if (f < 0)
                {
                    f += 2 * h;
                }
                else
                {
                    f += 2 * (h - w);
                    yy++;
                }
            }
        }

        private Color RandomColor()
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            Color c = Color.FromArgb(r, g, b);
            return c;
        }
    }
}
