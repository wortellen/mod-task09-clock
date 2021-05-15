using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace clock_9
{
    public partial class Form1 : Form
    {
        double length = 120;
        Graphics g;
        Timer timer;
        Color bkColor = Control.DefaultBackColor;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += new EventHandler(timerTime_Tick);
            timer.Interval = 1000;
            timer.Enabled = true;
            g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }
        private void PaintClock(DateTime dtArg)
        {

            PaintBackGround();

            PaintCircle();

            PaintArrows(dtArg);
        }
        private void timerTime_Tick(object sender, EventArgs e)
        {
            PaintClock(DateTime.Now);
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            PaintClock(DateTime.Now);
        }

        private void PaintBackGround()
        {
            g.FillRectangle(
                new SolidBrush(bkColor),
                new Rectangle(
                    new Point(
                        (int)(this.ClientRectangle.Width / 2 - length),
                        (int)(this.ClientRectangle.Height / 2 - length)),
                        new Size((int)length * 2, (int)length * 2)));
        }

        private void PaintCircle()
        {

            g.DrawEllipse(
                new Pen(Color.Black, 2),
                new Rectangle(
                    new Point(
                        (int)(this.ClientRectangle.Width / 2 - length),
                        (int)(this.ClientRectangle.Height / 2 - length)),
                        new Size((int)length * 2, (int)length * 2)));


            for (int i = 0; i < 12; i++)
            {
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 2),
                    new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                    new Point((int)(ClientRectangle.Width / 2 + length * Math.Cos(Math.PI / 6 * i)), (int)(ClientRectangle.Height / 2 + length * Math.Sin(Math.PI / 6 * i))));
            }

            for (int i = 0; i <60; i++)
            {
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 1),
                    new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                    new Point((int)(ClientRectangle.Width / 2 + length * Math.Cos(Math.PI / 30 * i)), (int)(ClientRectangle.Height / 2 + length * Math.Sin(Math.PI / 30 * i))));
            }

            g.FillEllipse(
                new SolidBrush(bkColor),
                new Rectangle(
                new Point(
                (int)(this.ClientRectangle.Width / 2 - length + 10),
                (int)(this.ClientRectangle.Height / 2 - length + 10)),
                new Size((int)(length - 10) * 2, (int)(length - 10) * 2)));

        }

        private void PaintArrows(DateTime dt)
        {

            g.DrawLine(
                new Pen(new SolidBrush(Color.Green), 1),
                new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                new Point((int)(ClientRectangle.Width / 2 + (length - 4) * Math.Sin(2 * Math.PI / 60 * dt.Second)), (int)(ClientRectangle.Height / 2 - (length - 4) * Math.Cos(2 * Math.PI / 60 * dt.Second))));

            g.DrawLine(
                new Pen(new SolidBrush(Color.Red), 2),
                new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                new Point((int)(ClientRectangle.Width / 2 + (length - 30) * Math.Sin(2 * Math.PI / 60 * dt.Minute)), (int)(ClientRectangle.Height / 2 - (length - 30) * Math.Cos(2 * Math.PI / 60 * dt.Minute))));
            int hour;
            if (dt.Hour <= 12)
            {
                hour = dt.Hour;
            }
            else
            {
                hour = dt.Hour - 12;
            }

            g.DrawLine(
                new Pen(new SolidBrush(Color.Blue), 2),
                new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                new Point((int)(ClientRectangle.Width / 2 + (length - 60) * Math.Sin(2 * Math.PI / 12 * hour + 2 * Math.PI / (12 * 60) * dt.Minute)), (int)(ClientRectangle.Height / 2 - (length - 60) * Math.Cos(2 * Math.PI / 12 * hour + 2 * Math.PI / (12 * 60) * dt.Minute))));
        }

        
    }
}
