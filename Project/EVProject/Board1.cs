using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace EVProject
{
    public partial class Board1 : UserControl
    {
        private Image queen;
        private int[] genes;
        public int bs;//Board Scale
        public int[] Genes
        {
            set
            {
                genes = value;
                Refresh();
            }
        }
        public Board1(int boardScale)
        {
            InitializeComponent();
            this.bs = boardScale;
            genes = new int[bs];
            //ResourceManager resourceManager = new ResourceManager("EVProject.MainForm", GetType().Assembly);
            Bitmap image = (Bitmap)Image.FromFile(Application.StartupPath + "//qeen.png");
            queen = (Image)image;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int size = this.Height / bs;
            if (genes != null)
            {
                for (int i = 0; i < bs; i++)
                {
                    if (queen != null)
                    {
                        g.DrawImage(queen, new Rectangle(i * size, ((bs - 1) - genes[i]) * size, size, size));
                    }
                }
            }
        }
        /*public void CallOnPaint()
        {
            OnPaint();
        }*/
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int size = this.Height / bs;
            bool isBlack = true;
            for (int i = 0; i < bs; i++)
            {
                for (int j = 0; j < bs; j++)
                {
                    Brush b;
                    if (isBlack)
                        b = Brushes.Black;
                    else
                        b = Brushes.White;
                    g.FillRectangle(b, new Rectangle(j * size, i * size, size, size));
                    isBlack = !isBlack;
                }
                if (bs%2==0)
                {
                    isBlack = !isBlack;
                }
            }
        }

        private void Board1_Load(object sender, EventArgs e)
        {

        }
    }
}
