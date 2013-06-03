using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Ortopedia.UI.Properties;

namespace Ortopedia.UI
{
      public partial class Gradiente : System.Windows.Forms.Panel  
    {
       // member variables
        System.Drawing.Color mStartColor;
        System.Drawing.Color mEndColor;

        public Gradiente()
        {
            InitializeComponent();
            PaintGradient();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }


        public System.Drawing.Color PageStartColor
        {
            get
            {
                return mStartColor;
            }
            set
            {
                mStartColor = value;
                PaintGradient();
            }
        }

        public System.Drawing.Color PageEndColor
        {
            get
            {
                return mEndColor;
            }
            set
            {
                mEndColor = value;
                PaintGradient();
            }
        }

        private string _caption;
        public string Caption {
            get {
                return _caption;
            }
            set {
                Label lbl = new Label();
                lbl.Text = value;
                _caption = value;
                lbl.Location = new Point(50, 13);
                lbl.BackColor = Color.Transparent;
                lbl.Width = 600;
                lbl.Font = new Font(lbl.Font, FontStyle.Bold);
                lbl.ForeColor = Color.WhiteSmoke;
                this.Controls.Add(lbl);
            }
        }



        private string _imagen;
        public string Imagen
        {
            get
            {
                return _imagen;
            }
            set
            {
                PictureBox pic = new PictureBox();
                //pic.Image = Image.FromFile(_imagen);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Size = new Size(32, 32);
                pic.BackColor = System.Drawing.Color.Transparent;
                pic.Image = img;
                _imagen = value;
                pic.Location = new Point(10, 5);
                pic.Visible = true;
                if (img != null)
                    this.Controls.Add(pic);
            }
        }

        public Image img { get; set; }

        private void PaintGradient()
        {
            System.Drawing.Drawing2D.LinearGradientBrush gradBrush;
            gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(this.Width, this.Height), PageStartColor, PageEndColor);
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(gradBrush, new Rectangle(0, 0, this.Width, this.Height));
            this.BackgroundImage = bmp;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
