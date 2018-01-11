using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace eyeforaneye_game
{
    class NearestNeighborPictureBox : PictureBox
    {
        public NearestNeighborPictureBox()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            paintEventArgs.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            paintEventArgs.Graphics.SmoothingMode = SmoothingMode.None;
            paintEventArgs.Graphics.CompositingQuality = CompositingQuality.AssumeLinear;
            base.OnPaint(paintEventArgs);
        }
    }
}
