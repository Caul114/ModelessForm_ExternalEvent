using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace ModelessForm_ExternalEvent.ToggleSwitch
{
    public class Toggle_Switch : Control
    {
        private float diameter;
        private MyRectangle rect;
        private RectangleF circle;
        private bool isON;
        private float artis;
        private Color borderColor;
        private bool textEnabled;
        private string onTex = string.Empty;
        private string offTex = string.Empty;
        private Color onCol;
        private Color offCol;
        private Timer painTicker = new Timer();

        public event SliderChangedEventHandler SliderValueChanged;

        public Toggle_Switch()
        {
            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;
            this.artis = 4F;
            this.diameter = 30F;
            this.textEnabled = true;
            this.rect = new MyRectangle(2F * this.diameter, this.diameter + 2F, this.diameter / 2F, 1F, 2F);
            this.circle = new RectangleF(1F, 1F, this.diameter, this.diameter);
            this.isON = false;
            this.borderColor = Color.LightGray;
            this.painTicker.Tick += new EventHandler(this.paintTicker_Tick);
            this.painTicker.Interval = 1;
            this.onCol = Color.FromArgb(94, 148, 255);
            this.offCol = Color.DarkGray;
            this.ForeColor = Color.White;
            this.onTex = "ON";
            this.offTex = "OFF";
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.Invalidate();
            base.OnEnabledChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.isON = !this.isON;
                this.IsOn = this.isON;
                base.OnMouseClick(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = (SmoothingMode)SmoothingMode.HighQuality;
            if (base.Enabled)
            {
                Pen pen;
                using (SolidBrush brush = new SolidBrush(this.isON ? this.onCol : this.offCol))
                {
                    e.Graphics.FillPath((Brush)brush, this.rect.Path);
                }
                using (pen = new Pen(this.borderColor, 2F))
                {
                    e.Graphics.DrawPath(pen, this.rect.Path);
                }
                if (this.textEnabled)
                {
                    using (Font font = new Font("Century Gothic", (8.2F * this.diameter) / 30F, (FontStyle)FontStyle.Bold))
                    {
                        SolidBrush b = new SolidBrush(this.ForeColor);
                        int height = TextRenderer.MeasureText(this.onTex, font).Height;
                        float num2 = (this.diameter - height) / 2F;
                        e.Graphics.DrawString(this.onTex, font, b, 5F, num2 + 1F);
                        height = TextRenderer.MeasureText(this.offTex, font).Height;
                        num2 = (this.diameter - height) / 2F;
                        e.Graphics.DrawString(this.offTex, font, b, this.diameter + 2F, num2 + 1F);
                    }
                }
                using (SolidBrush brush2 = new SolidBrush("#FFFFFF".FromHex()))
                {
                    e.Graphics.FillEllipse((Brush)brush2, this.circle);
                }
                using (pen = new Pen(Color.LightGray, 1.2F))
                {
                    e.Graphics.DrawEllipse(pen, this.circle);
                }

            }
            else
            {
                using (SolidBrush brush3 = new SolidBrush("#FFFFFF".FromHex()))
                {
                    using (SolidBrush brush4 = new SolidBrush("#FFFFFF".FromHex()))
                    {
                        e.Graphics.FillPath((Brush)brush3, this.rect.Path);
                        e.Graphics.FillEllipse((Brush)brush4, this.circle);
                        e.Graphics.DrawEllipse(Pens.DarkGray, this.circle);
                    }
                }
            }
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.Width = (base.Height - 2) * 2;
            this.diameter = base.Width / 2;
            this.artis = (4F * this.diameter) * 30F;
            this.rect = new MyRectangle(2F * this.diameter, this.diameter + 2F, this.diameter / 2F, 1F, 1F);
            this.circle = new RectangleF(!this.isON ? 1F : ((base.Width - this.diameter) - 1F), 1F, this.diameter, this.diameter);
            base.OnResize(e);
        }

        private void paintTicker_Tick(object sender, EventArgs e)
        {
            float x = this.circle.X;
            if (this.isON)
            {
                if ((x + this.artis) <= ((base.Width - this.diameter) - 1F))
                {
                    x += this.artis;
                    this.circle = new RectangleF(x, 1F, this.diameter, this.diameter);
                    base.Invalidate();
                }
                else
                {
                    x = (base.Width - this.diameter) - 1F;
                    this.circle = new RectangleF(x, 1F, this.diameter, this.diameter);
                    base.Invalidate();
                    this.painTicker.Stop();
                }
            }
            else if ((x - this.artis) >= 1F)
            {
                x -= this.artis;
                this.circle = new RectangleF(x, 1F, this.diameter, this.diameter);
            }
            else
            {
                x = 1F;
                this.circle = new RectangleF(x, 1F, this.diameter, this.diameter);
                base.Invalidate();
                this.painTicker.Stop();
            }
        }

        public bool TextEnabled
        {
            get => this.textEnabled;
            set
            {
                this.textEnabled = value;
                base.Invalidate();
            }
        }

        public bool IsOn
        {
            get => this.isON;
            set
            {
                this.painTicker.Stop();
                this.isON = value;
                this.painTicker.Start();
                if (this.SliderValueChanged != null)
                {
                    this.SliderValueChanged(this, EventArgs.Empty);
                }
            }
        }

        public Color BorderColor
        {
            get => this.borderColor;
            set
            {
                this.borderColor = value;
                base.Invalidate();
            }
        }

        protected override Size DefaultSize => new Size(60, 35);
        public delegate void SliderChangedEventHandler(object sender, EventArgs e);

        public string OnText
        {
            get => this.onTex;
            set
            {
                this.onTex = value;
                base.Invalidate();
            }
        }

        public string OffText
        {
            get => this.offTex;
            set
            {
                this.offTex = value;
                base.Invalidate();
            }
        }

        public Color OnColor
        {
            get => this.onCol;
            set
            {
                this.onCol = value;
                base.Invalidate();
            }
        }

        public Color OffColor
        {
            get => this.offCol;
            set
            {
                this.offCol = value;
                base.Invalidate();
            }
        }
    }
}

