using FillingShapes.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public interface IGraphicObject
    {
        public void Select();
        public void UnSelect();
        public bool CheckIfClicked(Point point);
        public void Move(Point startingPoint, Point endingPoint);
        public Task Draw();
        public void SetColor(Color color);
        public Direction IsOutsideArea();
    }
}
