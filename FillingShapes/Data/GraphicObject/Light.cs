using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public class Light : Vertice
    {
        public double Kd { get; set; }
        public double Ks { get; set; }
        public double z { get; set; }
        public int m { get; set; }
        public Light(Point center, Color color, int z = 300, int m = 50, double Kd = 0.5, double Ks = 0.5) : base(center, color)
        {
            _radius = 10;
            this.Kd = Kd;
            this.Ks = Ks;
            this.z = z;
            this.m = m;
        }
    }
}
