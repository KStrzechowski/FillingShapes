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
        public void Draw();
        public void ChangeColor(Color color);
        public Direction WallEncountered();
    }
}
