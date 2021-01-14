using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelessForm_ExternalEvent
{
    public partial class MagnifyingGlass : Form
    {
        Graphics graphic;
        Bitmap tempImage;
        Point frmMover;
        bool moverMouse;
        int Zoom = 2; // 1px, 2px, 3px ....
        public MagnifyingGlass()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //
            int widthImage = pictureBox1.Width;
            int heightImage = pictureBox1.Height;
            // Posizione del Mouse
            int mouseX = MousePosition.X;
            int mouseY = MousePosition.Y;
            // Cattura l'immagine
            tempImage = new Bitmap(widthImage / Zoom, heightImage / Zoom, System.Drawing.Imaging.PixelFormat.Format64bppPArgb);
            graphic = this.CreateGraphics();
            graphic = Graphics.FromImage(tempImage);
            // Copia l'immagine esatta
            graphic.CopyFromScreen(mouseX - widthImage / (Zoom * 2), mouseY - heightImage / (Zoom * 2), 0, 0, pictureBox1.Size);

            // Aumenta le dimensioni
            Bitmap newImage = new Bitmap(widthImage, heightImage);
            graphic = Graphics.FromImage(newImage);
            graphic.SmoothingMode = SmoothingMode.HighQuality; // qualita'
            graphic.DrawImage(tempImage, new Rectangle(0, 0, widthImage, heightImage));
            pictureBox1.Image = newImage;

            // Crea la forma circolare della lente
            Rectangle rect = new Rectangle(0, 0, widthImage, heightImage);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rect);
            pictureBox1.Region = new Region(path);

            // Pannello circolare
            Rectangle rectp = new Rectangle(0, 0, panel1.Width, panel1.Height);
            GraphicsPath pathp = new GraphicsPath();
            pathp.AddEllipse(rectp);
            panel1.Region = new Region(pathp);

            // La lente segue il mouse
            this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moverMouse)
            {
                Location = new Point(Cursor.Position.X - frmMover.X, Cursor.Position.Y - frmMover.Y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            frmMover = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            moverMouse = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moverMouse = false;
        }

        private void MagnifyingGlass_KeyDown(object sender, KeyEventArgs e)
        {
            //quando pressiona uma tecla
            if ((e.KeyCode & Keys.Up) == Keys.Up)
            {
                Zoom++; //aumenta zoom
            }
            if ((e.KeyCode & Keys.Down) == Keys.Down)
            {
                if (Zoom > 2)
                {
                    Zoom--; //diminuisci zoom
                }
            }
            if ((e.KeyCode & Keys.Escape) == Keys.Escape)
            {
                this.Close();
            }
        }


    }
}
