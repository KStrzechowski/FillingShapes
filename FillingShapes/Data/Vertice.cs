using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public class Vertice : IGraphicObject
    {
        private Point _position;
        private Color _color;
        protected bool IsSelected { get; set; }
        public static Graphics Graphics { get; set; }
        public static Bitmap Bitmap { get; set; }


        public Vertice(Point position)
        {
            _position = position;
            _color = Color.Green;
        }

        public Vertice(Point position, Color color)
        {
            _position = position;
            _color = color;
        }

        public Point GetPosition() => _position;
        public void SetPosition(Point position) => _position = position;
        public void Select() => IsSelected = true;
        public void UnSelect() => IsSelected = false;

        public bool CheckIfClicked(Point point)
        {
            if ((Math.Pow(GetPosition().X - point.X, 2) + Math.Pow(GetPosition().Y - point.Y, 2)) < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Move(Point startingPoint, Point endingPoint)
        {
            var position = new Point(endingPoint.X + (GetPosition().X - startingPoint.X),
                endingPoint.Y + (GetPosition().Y - startingPoint.Y));
            SetPosition(position);
        }

        public void Draw()
        {
            int radius = 5;
            if (IsSelected)
                Graphics.FillEllipse(new SolidBrush(Color.Green), GetPosition().X - radius, GetPosition().Y - radius, radius * 2, radius * 2);
            else
                Graphics.FillEllipse(new SolidBrush(Color.Orange), GetPosition().X - radius, GetPosition().Y - radius, radius * 2, radius * 2);
        }
        
        public double CalculateDistance(Point point)
        {
            return Math.Floor((Math.Sqrt(Math.Pow(GetPosition().X - point.X, 2) + Math.Pow(GetPosition().Y - point.Y, 2))));
        }
    }
}
