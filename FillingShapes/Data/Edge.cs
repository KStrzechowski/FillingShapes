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
    }
}
