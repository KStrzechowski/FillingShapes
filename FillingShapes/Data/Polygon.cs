using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public class Polygon : BaseShape
    {
        public Polygon() : base()
        {
        }

        public virtual void Remove(Vertice vertice) => _vertices.Remove(vertice);

        public virtual void AddVertice(Vertice vertice) => _vertices.Add(vertice);

        public virtual void AddVerticeBetween(Vertice firstVertice, Vertice secondVertice)
        {
            var point = new Point((firstVertice.GetPosition().X + secondVertice.GetPosition().X) / 2,
                                (firstVertice.GetPosition().Y + secondVertice.GetPosition().Y) / 2);
            var newVertice = new Vertice(point);
            int indexOfFirst = _vertices.IndexOf(firstVertice);
            int indexOfSecond = _vertices.IndexOf(secondVertice);
            if (indexOfFirst > indexOfSecond)
            {
                if (indexOfSecond == 0 && indexOfFirst == _vertices.Count - 1)
                    _vertices.Add(newVertice);
                else
                    _vertices.Insert(indexOfFirst, newVertice);
            }
            else
            {
                if (indexOfFirst == 0 && indexOfSecond == _vertices.Count - 1)
                    _vertices.Add(newVertice);
                else
                    _vertices.Insert(indexOfSecond, newVertice);
            }
        }

        public bool CheckIfClickedVertice(Point point, out Vertice clickedVertice)
        {
            clickedVertice = null;
            foreach (var vertice in _vertices)
            {
                if (vertice.CheckIfClicked(point))
                {
                    clickedVertice = vertice;
                    return true;
                }
            }
            return false;
        }
        
        public int CheckVerticesOrder(Vertice firstVertice, Vertice secondVertice)
        {
            int indexOfFirst = _vertices.IndexOf(firstVertice);
            int indexOfSecond = _vertices.IndexOf(secondVertice);
            if (indexOfFirst == -1 || indexOfSecond == -1)
                return -1;
            if (indexOfFirst > indexOfSecond)
            {
                if (indexOfSecond == 0 && indexOfFirst == _vertices.Count - 1)
                    return 0;
                else
                    return 1;
            }
            else
            {
                if (indexOfFirst == 0 && indexOfSecond == _vertices.Count - 1)
                    return 1;
                else
                    return 0;
            }
        }

        public bool CheckIfEdge(Vertice vertice1, Vertice vertice2)
        {
            if (Math.Abs(_vertices.IndexOf(vertice1) - _vertices.IndexOf(vertice2)) == 1 ||
                Math.Abs(_vertices.IndexOf(vertice1) - _vertices.IndexOf(vertice2)) == _vertices.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
