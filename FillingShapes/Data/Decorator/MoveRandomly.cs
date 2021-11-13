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
        //public double SpeedFactor { get; set; }
        private int _angle;
        private double _verticalMove;
        private double _horizontalMove;
        public MoveRandomly(IGraphicObject graphicObject, double speedFactor) : base(graphicObject)
        {
            //SpeedFactor = speedFactor;
            var random = new Random();
            _angle = random.Next(0, 359);
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
            int angle;
            if (_angle < 90)
            {
                angle = _angle;
                _verticalMove += angle / 90;
                _horizontalMove += (90 - angle) / 90;
            }
            else if (_angle < 180)
            {
                angle = _angle - 90;
                _verticalMove += (90 - angle) / 90;
                _horizontalMove -= angle / 90;
            }
            else if (_angle < 270)
            {
                angle = _angle - 180;
                _verticalMove += angle / 90;
                _horizontalMove -= (90 - angle) / 90;
            }
            else
            {
                angle = _angle - 270;
                _verticalMove -= (90 - angle) / 90;
                _horizontalMove += angle / 90;
            }
        }

        public void Move()
        {
            if (_verticalMove > 1)
            {
                _graphicObject.Move(new Point(0, 0), new Point(0, 1));
                _verticalMove -= 1;
            }
            else if (_verticalMove < -1)
            {
                _graphicObject.Move(new Point(0, 0), new Point(0, -1));
                _verticalMove += 1;
            }
            if (_horizontalMove > 1)
            {
                _graphicObject.Move(new Point(0, 0), new Point(1, 0));
                _horizontalMove -= 1;
            }
            else if (_horizontalMove < -1)
            {
                _graphicObject.Move(new Point(0, 0), new Point(-1, 0));
                _horizontalMove += 1;
            }

            var direction = _graphicObject.WallEncountered();
            if (direction == Direction.Down)
                ChangeDirection(0, 180);
            else if (direction == Direction.Up)
                ChangeDirection(180, 360);
            else if (direction == Direction.Left)
                ChangeDirection(-90, 90);
            else if (direction == Direction.Right)
                ChangeDirection(90, 180);
        }

    }
}
