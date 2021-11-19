using FillingShapes.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data.Decorator
{
    public class MoveRandomly : BaseDecorator
    {
        private int _angle;
        private double _verticalMove;
        private double _horizontalMove;
        private Speed _speed;
        public MoveRandomly(IGraphicObject graphicObject, int angle, Speed speed) : base(graphicObject)
        {
            _angle = angle;
            _speed = speed;
        }

        private void ChangeDirection(int minimumAngle, int maximumAngle)
        {
            var random = new Random();
            _angle = random.Next(minimumAngle, maximumAngle);
            if (minimumAngle < 0)
                _angle += 360;
        }

        public void calculateDisplacement()
        {
            _verticalMove += Math.Sin(Math.PI * _angle / 180);
            _horizontalMove += Math.Cos(Math.PI * _angle / 180);
        }

        public override void Move(Point startingPoint, Point endingPoint)
        {
            for (int i = 0; i < _speed.Value; i++)
            {
                calculateDisplacement();

                if (_verticalMove >= 1)
                {
                    _graphicObject.Move(startingPoint, new Point(0, endingPoint.Y - startingPoint.Y));
                    _verticalMove -= 1;
                }
                else if (_verticalMove <= -1)
                {
                    _graphicObject.Move(startingPoint, new Point(0, startingPoint.Y - endingPoint.Y));
                    _verticalMove += 1;
                }
                if (_horizontalMove >= 1)
                {
                    _graphicObject.Move(startingPoint, new Point(endingPoint.X - startingPoint.X, 0));
                    _horizontalMove -= 1;
                }
                else if (_horizontalMove <= -1)
                {
                    _graphicObject.Move(startingPoint, new Point(startingPoint.X - endingPoint.X, 0));
                    _horizontalMove += 1;
                }
            }

            var direction = _graphicObject.IsNextToWall();
            if (direction == Direction.Down)
                ChangeDirection(181, 359);
            else if (direction == Direction.Up)
                ChangeDirection(1, 179);
            else if (direction == Direction.Left)
                ChangeDirection(-89, 89);
            else if (direction == Direction.Right)
                ChangeDirection(91, 269);
        }
    }
}
