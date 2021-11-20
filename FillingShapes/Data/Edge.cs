using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public class Edge
    {
        public Vertice VerticeFirst { get; set; }
        public Vertice VerticeSecond { get; set; }
        public Edge(Vertice verticeFirst, Vertice verticeSecond)
        {
            VerticeFirst = verticeFirst;
            VerticeSecond = verticeSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Edge))
            {
                return false;
            }

            if ((VerticeFirst.GetPosition() == ((Edge)obj).VerticeFirst.GetPosition())
                && (VerticeSecond.GetPosition() == ((Edge)obj).VerticeSecond.GetPosition())
                || ((VerticeFirst.GetPosition() == ((Edge)obj).VerticeSecond.GetPosition())
                && (VerticeSecond.GetPosition() == ((Edge)obj).VerticeFirst.GetPosition())))
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
