using FillingShapes.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public abstract class BaseGraphicObject : IGraphicObject
    {
        protected readonly List<Vertice> _vertices;
        protected List<int> _sortedVerticeIndexes; 
        protected readonly static object _lock = new object();
        public Coloring ColoringType { get; set; }
        protected Color _color;
        protected bool IsSelected { get; set; }
        public static Graphics Graphics { get; set; }
        public static Bitmap Bitmap { get; set; }


        public BaseGraphicObject()
        {
            _vertices = new();
            _sortedVerticeIndexes = new();
            IsSelected = true;
            ColoringType = Coloring.Solid;
            _color = Color.Black;
        }

        public void Select() => IsSelected = true;
        public void UnSelect() => IsSelected = false;
        public void SetColor(Color color) => _color = color;
        public abstract bool CheckIfClicked(Point point);
        public abstract void Move(Point startingPoint, Point endingPoint);
        public abstract Task Draw();
        public abstract Direction IsOutsideArea();
    }
}
