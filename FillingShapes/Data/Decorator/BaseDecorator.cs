using FillingShapes.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public abstract class BaseDecorator : IGraphicObject
    {
        protected readonly IGraphicObject _graphicObject;
        public BaseDecorator(IGraphicObject graphicObject)
        {
            _graphicObject = graphicObject;
        }

        public virtual void Select()
        {
            _graphicObject.Select();
        }

        public virtual void UnSelect()
        {
            _graphicObject.UnSelect();
        }

        public virtual bool CheckIfClicked(Point point)
        {
            return _graphicObject.CheckIfClicked(point);
        }

        public virtual void Move(Point startingPoint, Point endingPoint)
        {
            _graphicObject.Move(startingPoint, endingPoint);
        }

        public virtual async Task Draw()
        {
            await _graphicObject.Draw();
        }

        public virtual void SetColor(Color color)
        {
            _graphicObject.SetColor(color);
        }

        public Direction IsOutsideArea()
        {
            return _graphicObject.IsOutsideArea();
        }
    }
}
