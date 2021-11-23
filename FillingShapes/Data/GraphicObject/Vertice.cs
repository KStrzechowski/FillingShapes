using FillingShapes.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public class Vertice : BaseGraphicObject
    {
        protected int _radius;
        private Point _position;
        public Vertice(Point position)
        {
            _position = position;
            _color = Color.Orange;
            _radius = 5;
        }

        public Vertice(Point position, Color color)
        {
            _position = position;
            IsOutsideArea();
            _color = color;
            _radius = 5;
        }

        public Point GetPosition() => _position;
        
        public void SetPosition(Point position) => _position = position;

        public override bool CheckIfClicked(Point point)
        {
            if ((Math.Pow(GetPosition().X - point.X, 2) + Math.Pow(GetPosition().Y - point.Y, 2)) < _radius * _radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Move(Point startingPoint, Point endingPoint)
        {
            var position = new Point(endingPoint.X + (GetPosition().X - startingPoint.X),
                endingPoint.Y + (GetPosition().Y - startingPoint.Y));
            SetPosition(position);
            isWallEncounter();
        }

        private void isWallEncounter()
        {
            var direction = IsOutsideArea();
            Point endingPoint = new Point(0, 0);
            if (direction == Direction.Down)
                endingPoint = new Point(0, Bitmap.Height - GetPosition().Y);
            else if (direction == Direction.Up)
                endingPoint = new Point(0, -GetPosition().Y);
            else if (direction == Direction.Left)
                endingPoint = new Point(-GetPosition().X, 0);
            else if (direction == Direction.Right)
                endingPoint = new Point(Bitmap.Width - GetPosition().X, 0);
 
            if (endingPoint.X != 0 || endingPoint.Y != 0)
                Move(new Point(0, 0), endingPoint);
        }

        public override Task Draw()
        {
            Graphics.FillEllipse(new SolidBrush(_color), GetPosition().X - _radius, GetPosition().Y - _radius, _radius * 2, _radius * 2);
            return Task.FromResult(0);
        }

        public Color GetColor() => _color;

        public double CalculateDistance(Point point)
        {
            return Math.Floor((Math.Sqrt(Math.Pow(GetPosition().X - point.X, 2) + Math.Pow(GetPosition().Y - point.Y, 2))));
        }

        public override Direction IsOutsideArea()
        {
            if (GetPosition().X <= 1)
                return Direction.Left;
            else if (GetPosition().X >= Bitmap.Width - 1)
                return Direction.Right;
            else if (GetPosition().Y <= 1)
                return Direction.Up;
            else if (GetPosition().Y >= Bitmap.Height - 1)
                return Direction.Down;
            
            return Direction.None;
        }
    }
}
