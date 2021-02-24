using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToggleSwitch
{
    internal class MyRectangle
    {
        private Point _location;
        private float _radius;
        private GraphicsPath _grPath;
        private float _x;
        private float _y;
        private float _width;
        private float _height;

        public MyRectangle() { }

        public MyRectangle(float width, float height, float radius, float x = 0F, float y = 0F)
        {
            this._location = new Point(0, 0);
            this._radius = radius;
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
            this._grPath = new GraphicsPath();
            if (radius <= 0F)
            {
                this._grPath.AddRectangle(new RectangleF(x, y, width, height));
            }
            else
            {
                RectangleF ef = new RectangleF(x, y, 2F * radius, 2F * radius);
                RectangleF ef2 = new RectangleF((width - (2F * radius)) - 1F, y, 2F * radius, 2F * radius);
                RectangleF ef3 = new RectangleF(x, (height - (2F * radius)) - 1F, 2F * radius, 2F * radius);
                RectangleF ef4 = new RectangleF((width - (2F * radius)) - 1F, (height - (2F * radius)) - 1F,
                    2F * radius, 2F * radius);

                this._grPath.AddArc(ef, 180F, 90F);
                this._grPath.AddArc(ef2, 270F, 90F);
                this._grPath.AddArc(ef4, 0F, 90F);
                this._grPath.AddArc(ef3, 90F, 90F);
                this._grPath.CloseAllFigures();
            }
        }

        public GraphicsPath Path => this._grPath;
        public RectangleF Rect => new RectangleF(this._x, this._y, this._width, this._height);
        public float Radius
        {
            get => this._radius;
            set => this._radius = value;
        }
    }
}
