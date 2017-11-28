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

namespace ООП_11_Графика
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            arrayColors = new Color[(int)numericUpDown4.Value+1];
            Random rnd = new Random();
            for(int c = 0; c < arrayColors.Length; c++)
                arrayColors[c] = Color.FromArgb(rnd.Next(1, 255), rnd.Next(1, 255), rnd.Next(1, 255));
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }
        ColorComboBox CB;
        private void Form1_Load(object sender, EventArgs e)
        {
            CB = new ColorComboBox();
            CB.Location = new Point(100,50);
            CB.Show();
            CB.Parent = panel1;
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            int y = 10;
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.FromName(CB.SelectedItem.ToString()), 1);
            Point beginXDown = new Point(0, (ClientSize.Height / 2 - 100) + (int)(numericUpDown1.Value / 2));
            Point endXDown = new Point(ClientSize.Width, (ClientSize.Height / 2 - 100) + (int)(numericUpDown1.Value / 2));
            Point beginXUp = new Point(0, (ClientSize.Height / 2 - 100) - (int)(numericUpDown1.Value / 2));
            Point endXUp = new Point(ClientSize.Width, (ClientSize.Height / 2 - 100) - (int)(numericUpDown1.Value / 2));
            g.DrawLine(p, beginXUp, endXUp);
            g.DrawLine(p, beginXDown, endXDown);
            //кадр
            float widthCadr = (float)numericUpDown1.Value;
            float HeightCadr = (float)numericUpDown1.Value * 2 / 3;
            Point XCadr = new Point((int)(beginXUp.X + numericUpDown1.Value / 8), (int)(beginXUp.Y + numericUpDown1.Value / 6));
            int CountRect = 0;
            for (decimal i = 0; i < ClientSize.Width; i += numericUpDown1.Value + numericUpDown1.Value / 8)
                if ((beginXUp.X + (float)numericUpDown1.Value / 8) + (float)i + (float)numericUpDown1.Value < ClientSize.Width - 10)
                {
                    g.DrawRectangle(p, (beginXUp.X + (float)numericUpDown1.Value / 8) + (float)i, (beginXUp.Y + (float)numericUpDown1.Value / 6), (float)numericUpDown1.Value, (float)numericUpDown1.Value * 2 / 3);
                    CountRect++;
                }
            for (decimal i = 0; i < ClientSize.Width; i += numericUpDown1.Value / (decimal)2.1 )
                g.DrawEllipse(p, beginXUp.X+ (float)(numericUpDown1.Value / 8) + (float)i, (beginXUp.Y + 2) , (float)numericUpDown1.Value / 8, (float)(numericUpDown1.Value / 8) );
            for (decimal i = 0; i < ClientSize.Width; i += numericUpDown1.Value / (decimal)2.1)
                g.DrawEllipse(p, beginXUp.X + (float)(numericUpDown1.Value / 8) + (float)i, (beginXDown.Y - 2- (float)numericUpDown1.Value / 8), (float)numericUpDown1.Value / 8, (float)(numericUpDown1.Value / 8));
            float C = 0;
            C = ((widthCadr- (float)(numericUpDown1.Value / 8)) / (CountRect+1));
            
            //for (float i = 0; i < ClientSize.Width; i += (float)widthCadr+ (float)numericUpDown1.Value / 8 + C)
            //{
            //    g.DrawEllipse(p, i+(XCadr.X + widthCadr / 8), (XCadr.Y) + 1, HeightCadr / 3, HeightCadr / 3);
            //    g.DrawLine(p, i + (XCadr.X + widthCadr * 2 / 8) - 2, XCadr.Y + 1 + HeightCadr * 2 / 3, i + (XCadr.X + widthCadr * 2 / 8) - 2, XCadr.Y + HeightCadr / 3);
            //    Point Ass = new Point((int)(i +( XCadr.X + widthCadr * 2 / 8) - 2),  (int)(XCadr.Y + 1 + HeightCadr * 2 / 3));
            //    Point Leftfoot = new Point((int)(i +(XCadr.X + widthCadr / 8)), XCadr.Y + (int)HeightCadr);
            //    Point Rightfoot = new Point((int)(i+(XCadr.X + widthCadr * 3 / 8 - 5)), XCadr.Y + (int)HeightCadr);
            //    g.DrawLine(p, Ass, Rightfoot);
            //    g.DrawLine(p, Ass, Leftfoot);
            //    Point neck = new Point((int)(i +(XCadr.X + widthCadr * 2 / 8)) - 2, (int)(XCadr.Y + HeightCadr / 3 + 5));
            //    Point leftHand = new Point((int)(i+(XCadr.X + widthCadr / 8)), XCadr.Y + (int)(HeightCadr) - 20);
            //    Point rightHand = new Point((int)(i+(XCadr.X + widthCadr * 3 / 8 - 5)), XCadr.Y + (int)HeightCadr - 20);
            //    g.DrawLine(p, neck, leftHand);
            //    g.DrawLine(p, neck, rightHand);
            //}
            int countFor = 0;
            if (numericUpDown1.Value < 125)
            {
                for (float i = 0; i < ClientSize.Width; i += (float)widthCadr + (float)numericUpDown1.Value / 8 + C)
                {
                    if (countFor < CountRect)
                    {
                        g.DrawEllipse(p, i + (XCadr.X), (XCadr.Y) + 1, HeightCadr / 3, HeightCadr / 3);
                        g.DrawLine(p, i + (XCadr.X + widthCadr / 8) - 2, XCadr.Y + 1 + HeightCadr * 2 / 3, i + (XCadr.X + widthCadr / 8) - 2, XCadr.Y + HeightCadr / 3);
                        Point Ass = new Point((int)(i + (XCadr.X + widthCadr / 8) - 2), (int)(XCadr.Y + 1 + HeightCadr * 2 / 3));
                        Point Leftfoot = new Point((int)(i + (XCadr.X)), XCadr.Y + (int)HeightCadr);
                        Point Rightfoot = new Point((int)(i + (XCadr.X + widthCadr * 2 / 8 - 5)), XCadr.Y + (int)HeightCadr);
                        g.DrawLine(p, Ass, Rightfoot);
                        g.DrawLine(p, Ass, Leftfoot);
                        Point neck = new Point((int)(i + (XCadr.X + widthCadr / 8)) - 2, (int)(XCadr.Y + HeightCadr / 3 + 5));
                        Point leftHand = new Point((int)(i + (XCadr.X)), XCadr.Y + (int)(HeightCadr) - 20);
                        Point rightHand = new Point((int)(i + (XCadr.X + widthCadr * 2 / 8 - 5)), XCadr.Y + (int)HeightCadr - 20);
                        g.DrawLine(p, neck, leftHand);
                        g.DrawLine(p, neck, rightHand);
                        countFor++;
                    }

                }

            }
            else
            {
                for (float i = C; i < ClientSize.Width; i += (float)widthCadr + (float)numericUpDown1.Value / 8 + C)
                {
                    if (countFor < CountRect)
                    {
                        g.DrawEllipse(p, i + (XCadr.X), (XCadr.Y) + 1, HeightCadr / 3, HeightCadr / 3);
                        g.DrawLine(p, i + (XCadr.X + widthCadr / 8) - 2, XCadr.Y + 1 + HeightCadr * 2 / 3, i + (XCadr.X + widthCadr / 8) - 2, XCadr.Y + HeightCadr / 3);
                        Point Ass = new Point((int)(i + (XCadr.X + widthCadr / 8) - 2), (int)(XCadr.Y + 1 + HeightCadr * 2 / 3));
                        Point Leftfoot = new Point((int)(i + (XCadr.X)), XCadr.Y + (int)HeightCadr);
                        Point Rightfoot = new Point((int)(i + (XCadr.X + widthCadr * 2 / 8 - 5)), XCadr.Y + (int)HeightCadr);
                        g.DrawLine(p, Ass, Rightfoot);
                        g.DrawLine(p, Ass, Leftfoot);
                        Point neck = new Point((int)(i + (XCadr.X + widthCadr / 8)) - 2, (int)(XCadr.Y + HeightCadr / 3 + 5));
                        Point leftHand = new Point((int)(i + (XCadr.X)), XCadr.Y + (int)(HeightCadr) - 20);
                        Point rightHand = new Point((int)(i + (XCadr.X + widthCadr * 2 / 8 - 5)), XCadr.Y + (int)HeightCadr - 20);
                        g.DrawLine(p, neck, leftHand);
                        g.DrawLine(p, neck, rightHand);
                        countFor++;
                    }

                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Visible = false;
                Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Visible = false;
                Visible = true;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' || e.KeyChar <= '9')
                Invalidate();
        }
        Color[] arrayColors;
        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random rnd = new Random();
            Graphics ds = CreateGraphics();
            Pen p = new Pen(Color.FromName(CB.SelectedItem.ToString()), 1);
            //myPath.AddEllipse(new RectangleF((float)(ClientSize.Width / 2 - numericUpDown2.Value), (float)(ClientSize.Height / 2 - numericUpDown2.Value), (float)numericUpDown2.Value * 2, (float)numericUpDown2.Value * 2));
            //myPath.AddEllipse(new RectangleF((float)(ClientSize.Width / 2 - numericUpDown3.Value), (float)(ClientSize.Height / 2 - numericUpDown3.Value), (float)numericUpDown3.Value * 2, (float)numericUpDown3.Value * 2));
            float C = 360 / ((float)numericUpDown4.Value);
            int i = 0;
            for (float j = 0; j < 360; j += C)
            {
                GraphicsPath myPath = new GraphicsPath();
                Brush br = new SolidBrush(arrayColors[i]);
                myPath.StartFigure();
                myPath.AddArc(new RectangleF((float)(ClientSize.Width / 2 - numericUpDown2.Value), (float)(ClientSize.Height / 2 - numericUpDown2.Value), (float)numericUpDown2.Value * 2, (float)numericUpDown2.Value * 2), (-1) * j , (-1) * C);
                myPath.AddArc(new RectangleF((float)(ClientSize.Width / 2 - numericUpDown3.Value), (float)(ClientSize.Height / 2 - numericUpDown3.Value), (float)numericUpDown3.Value * 2, (float)numericUpDown3.Value * 2), (-1) * j, C);
                //myPath.AddPie(new Rectangle((int)(ClientSize.Width / 2 - numericUpDown3.Value), (int)(ClientSize.Height / 2 - numericUpDown3.Value), (int)numericUpDown3.Value * 2, (int)numericUpDown3.Value * 2), (-1) * j, C);
                //myPath.AddPie(new Rectangle((int)(ClientSize.Width / 2 - numericUpDown2.Value), (int)(ClientSize.Height / 2 - numericUpDown2.Value), (int)numericUpDown2.Value * 2, (int)numericUpDown2.Value * 2), (-1) * (j+2*C), C);

                //myPath.CloseFigure();
                g.FillPath(br, myPath);
                Pen outLine = new Pen(arrayColors[i], 1);
                g.DrawPath(outLine, myPath);
                i++;
            }

            /* Солнце
            for (float j = 0; j < 360; j += C)
            {
                GraphicsPath myPath = new GraphicsPath();
                myPath.StartFigure();
                myPath.AddArc(new RectangleF((float)(ClientSize.Width / 2 - numericUpDown3.Value), (float)(ClientSize.Height / 2 - numericUpDown3.Value), (float)numericUpDown3.Value * 2, (float)numericUpDown3.Value * 2), j, C);
                myPath.AddArc(new RectangleF((float)(ClientSize.Width / 2 - numericUpDown2.Value), (float)(ClientSize.Height / 2 - numericUpDown2.Value), (float)numericUpDown2.Value * 2, (float)numericUpDown2.Value * 2), j+C, C);
                myPath.CloseFigure();
                g.FillPath(Brushes.Black, myPath);
                Pen outLine = new Pen(Color.Black, 2);
                g.DrawPath(outLine, myPath);
            }
            */
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            arrayColors = new Color[(int)numericUpDown4.Value + 1];
            Random rnd = new Random();
            for (int c = 0; c < arrayColors.Length; c++)
                arrayColors[c] = Color.FromArgb(rnd.Next(1, 255), rnd.Next(1, 255), rnd.Next(1, 255));
        }

        private void tabPage3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
