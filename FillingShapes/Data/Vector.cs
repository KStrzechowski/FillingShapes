using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public class Vector
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Normalize()
        {
            if (x == 0 && y == 0 && z == 0)
                return;
            double norm = Math.Sqrt(x * x + y * y + z * z);
            x /= norm;
            y /= norm;
            z /= norm;
        }
    }   
}
