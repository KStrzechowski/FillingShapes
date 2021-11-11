using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public abstract class BaseShape : IGraphicObject
    {
        protected readonly List<Vertice> _vertices;
        protected bool IsSelected { get; set; }
        public static Graphics Graphics { get; set; }
        public static Bitmap Bitmap { get; set; }
        public static int MaxHeigth { get; set; }
        public static int MaxWidth { get; set; }

        public BaseShape()
        {
            _vertices = new();
            IsSelected = true;
        }

        public void Select() => IsSelected = true;
        public void UnSelect() => IsSelected = false;

        public bool CheckIfClicked(Point point)
        {
            bool result = false;
            int j = _vertices.Count() - 1;
            for (int i = 0; i < _vertices.Count(); i++)
            {
                if (_vertices[i].GetPosition().Y < point.Y && _vertices[j].GetPosition().Y >= point.Y
                    || _vertices[j].GetPosition().Y < point.Y && _vertices[i].GetPosition().Y >= point.Y)
                {
                    if (_vertices[i].GetPosition().X + (point.Y -
                        (double)_vertices[i].GetPosition().Y) / ((double)_vertices[j].GetPosition().Y - _vertices[i].GetPosition().Y) *
                        (_vertices[j].GetPosition().X - _vertices[i].GetPosition().X) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public virtual bool CheckIfCorrect() => _vertices.Count >= 3;

        public virtual void Move(Point startingPoint, Point endingPoint)
        {
            foreach (var vertice in _vertices)
            {
                var position = new Point(endingPoint.X + (vertice.GetPosition().X - startingPoint.X),
                endingPoint.Y + (vertice.GetPosition().Y - startingPoint.Y));
                vertice.SetPosition(position);
            }
        }

        public virtual void Draw()
        {
            var points = _vertices;
            Color color;
            if (IsSelected)
                color = Color.Blue;
            else
                color = Color.Black;

            for (int i = 0; i < points.Count - 1; i++)
            {
                DrawLine(points[i].GetPosition(), points[i + 1].GetPosition(), color);
                points[i].Draw();
            }
            DrawLine(points[points.Count - 1].GetPosition(), points[0].GetPosition(), color);
            points[points.Count - 1].Draw();
        }

        protected void DrawLine(Point first_point, Point second_point, Color color)
        {
            int d, dx, dy, a, b, xFactor, yFactor;
            int x = first_point.X, y = first_point.Y;

            // wybieramy poziomy kierunek rysowania
            if (first_point.X < second_point.X)
            {
                xFactor = 1;
                dx = second_point.X - first_point.X;
            }
            else
            {
                xFactor = -1;
                dx = first_point.X - second_point.X;
            }
            // wybieraym pionowy kierunek rysowania
            if (first_point.Y < second_point.Y)
            {
                yFactor = 1;
                dy = second_point.Y - first_point.Y;
            }
            else
            {
                yFactor = -1;
                dy = first_point.Y - second_point.Y;
            }
            // Sprawdzam czy linia nie wychodzi poza bitmapę
            if (Bitmap.Width > x && x >= 0 && Bitmap.Height > y && y >= 0)
            {
                Bitmap.SetPixel(x, y, color);
            }

            // sprawdzamy czy odcinek jest "bardziej" pionowy czy poziomy
            if (dx > dy)
            {
                a = (dy - dx) * 2;
                b = dy * 2;
                d = b - dx;
                // pętla po kolejnych x
                while (x != second_point.X)
                {
                    if (d >= 0)
                    {
                        x += xFactor;
                        y += yFactor;
                        d += a;
                    }
                    else
                    {
                        d += b;
                        x += xFactor;
                    }
                    if (Bitmap.Width > x && x >= 0 && Bitmap.Height > y && y >= 0)
                    {
                        Bitmap.SetPixel(x, y, color);
                    }
                }
            }
            else
            {
                a = (dx - dy) * 2;
                b = dx * 2;
                d = b - dy;
                // pętla po kolejnych y
                while (y != second_point.Y)
                {
                    if (d >= 0)
                    {
                        x += xFactor;
                        y += yFactor;
                        d += a;
                    }
                    else
                    {
                        d += b;
                        y += yFactor;
                    }
                    if (Bitmap.Width > x && x >= 0 && Bitmap.Height > y && y >= 0)
                    {
                        Bitmap.SetPixel(x, y, color);
                    }
                }
            }
        }
    }
}
