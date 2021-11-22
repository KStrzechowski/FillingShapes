using FillingShapes.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes.Data
{
    public class Polygon : BaseGraphicObject
    {
        protected Boundaries _boundariesIndex;
        protected DirectBitmap _texture;
        protected struct Boundaries
        {
            public int mostUp;
            public int mostDown;
            public int mostRight;
            public int mostLeft;
        }

        public Polygon() : base()
        {
        }

        public void SetTexture(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            _texture = new DirectBitmap(bitmap.Width, bitmap.Height);
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                    _texture.SetPixel(x, y, bitmap.GetPixel(x, y));
        }

        public virtual void AddVertice(Vertice vertice)
        {
            _vertices.Add(vertice);
            CheckBoundaries();
            Sort();
        }

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

            Sort();
        }
       
        public virtual void Remove(Vertice vertice)
        {
            _vertices.Remove(vertice);
            Sort();
        }

        protected void Sort()
        {
            _sortedVerticeIndexes = Enumerable.Range(0, _vertices.Count).ToList();
            _sortedVerticeIndexes.Sort((x, y) => _vertices[x].GetPosition().Y < _vertices[y].GetPosition().Y ? 1 : -1);
        }

        public virtual bool CheckIfCorrect() => _vertices.Count >= 3;

        public override bool CheckIfClicked(Point point)
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
        
        public bool CheckIfEdge(Vertice vertice1, Vertice vertice2)
        {
            if (Math.Abs(_vertices.IndexOf(vertice1) - _vertices.IndexOf(vertice2)) == 1 ||
                Math.Abs(_vertices.IndexOf(vertice1) - _vertices.IndexOf(vertice2)) == _vertices.Count - 1)
                return true;
            else
                return false;
        }

        public override void Move(Point startingPoint, Point endingPoint)
        {
            foreach (var vertice in _vertices)
            {
                var position = new Point(endingPoint.X + (vertice.GetPosition().X - startingPoint.X),
                endingPoint.Y + (vertice.GetPosition().Y - startingPoint.Y));
                vertice.SetPosition(position);
            }
            FixMove();
        }

        public virtual void MoveVertice(Vertice vertice, Point startingPoint, Point endingPoint)
        {
            vertice.Move(startingPoint, endingPoint);
            CheckBoundaries();
            Sort();
        }

        public virtual void FixMove()
        {
            var direction = IsOutsideArea();
            if (direction == Direction.None)
                return;
            Point endingPoint = new Point(0, 0);
            if (direction == Direction.Up)
                endingPoint = new Point(0, -_vertices[_boundariesIndex.mostUp].GetPosition().Y);
            else if (direction == Direction.Down)
                endingPoint = new Point(0, Bitmap.Height - _vertices[_boundariesIndex.mostDown].GetPosition().Y - 1);
            else if (direction == Direction.Right)
                endingPoint = new Point(Bitmap.Width - _vertices[_boundariesIndex.mostRight].GetPosition().X - 1, 0);
            else if (direction == Direction.Left)
                endingPoint = new Point(-_vertices[_boundariesIndex.mostLeft].GetPosition().X, 0);

            if (endingPoint.X != 0 || endingPoint.Y != 0)
                Move(new Point(0, 0), endingPoint);
        }

        public override Direction IsOutsideArea()
        {
            if (_vertices[_boundariesIndex.mostLeft].GetPosition().X <= 0)
                return Direction.Left;
            else if (_vertices[_boundariesIndex.mostRight].GetPosition().X >= Bitmap.Width - 1)
                return Direction.Right;
            else if (_vertices[_boundariesIndex.mostUp].GetPosition().Y <= 0)
                return Direction.Up;
            else if (_vertices[_boundariesIndex.mostDown].GetPosition().Y >= Bitmap.Height - 1)
                return Direction.Down;

            return Direction.None;
        }

        protected virtual void CheckBoundaries()
        {
            _boundariesIndex.mostUp = 0;
            _boundariesIndex.mostDown = 0;
            _boundariesIndex.mostLeft = 0;
            _boundariesIndex.mostRight = 0;

            foreach (var vertice in _vertices)
            {
                if (_vertices[_boundariesIndex.mostUp].GetPosition().Y > vertice.GetPosition().Y)
                    _boundariesIndex.mostUp = _vertices.IndexOf(vertice);
                if (_vertices[_boundariesIndex.mostDown].GetPosition().Y < vertice.GetPosition().Y)
                    _boundariesIndex.mostDown = _vertices.IndexOf(vertice);
                if (_vertices[_boundariesIndex.mostRight].GetPosition().X < vertice.GetPosition().X)
                    _boundariesIndex.mostRight = _vertices.IndexOf(vertice);
                if (_vertices[_boundariesIndex.mostLeft].GetPosition().X > vertice.GetPosition().X)
                    _boundariesIndex.mostLeft = _vertices.IndexOf(vertice);
            }
        }

        public override async Task Draw()
        {
            var points = _vertices;
            Color color;
            if (IsSelected)
                color = Color.Blue;
            else
                color = Color.Black;

            Task filledTask = null;
            if (points.Count > 2)
                filledTask = Fill();

            Task[] tasks = new Task[points.Count * 2];
            for (int i = 0; i < points.Count - 1; i++)
            {
                tasks[i] = DrawLine(points[i].GetPosition(), points[i + 1].GetPosition(), _color);
                tasks[points.Count - 1 + i] = points[i].Draw();
            }
            tasks[^2] = DrawLine(points[points.Count - 1].GetPosition(), points[0].GetPosition(), _color);
            tasks[^1] = points[points.Count - 1].Draw();
            for (int i = 0; i < (points.Count) * 2; i++)
                await tasks[i];
            if (filledTask != null)
                await filledTask;
        }

        protected Task DrawLine(Point first_point, Point second_point, Color color)
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
            return Task.FromResult(0);
        }

        protected virtual async Task Fill()
        {
            int yMin = _vertices[_sortedVerticeIndexes[^1]].GetPosition().Y;
            int yMax = _vertices[_sortedVerticeIndexes[0]].GetPosition().Y;
            List<Edge> Aet = new();

            for (int y = yMin; y <= yMax; y++)
            {
                for (int i = 0; i < _vertices.Count; i++)
                {
                    Vertice vertice = _vertices[_sortedVerticeIndexes[i]];
                    if (vertice.GetPosition().Y == y - 1)
                    {
                        Vertice prev = _sortedVerticeIndexes[i] == 0 ? _vertices[_vertices.Count - 1] : _vertices[_sortedVerticeIndexes[i] - 1];
                        if (vertice.GetPosition().Y <= prev.GetPosition().Y)
                            Aet.Add(new Edge(prev, vertice));
                        else
                            Aet.RemoveAll(x => x.Equals(new Edge(prev, vertice)));

                        Vertice next = _sortedVerticeIndexes[i] == _vertices.Count - 1
                            ? _vertices[0] : _vertices[_sortedVerticeIndexes[i] + 1];
                        if (vertice.GetPosition().Y <= next.GetPosition().Y)
                            Aet.Add(new Edge(next, vertice));
                        else
                            Aet.RemoveAll(x => x.Equals(new Edge(next, vertice)));
                    }
                }

                Aet.Sort((i, j) => CalculatePointPosition(i, y).X > CalculatePointPosition(j, y).X ? 1 : -1);
                Task[] tasks = new Task[Aet.Count / 2];
                for (int i = 0; i < Aet.Count - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        Point left = CalculatePointPosition(Aet[i], y);
                        Point right = CalculatePointPosition(Aet[i + 1], y);
                        tasks[i / 2] = ChooseColoring(left, right.X - left.X, Aet[i], Aet[i + 1]);
                    }
                }
                for (int i = 0; i < tasks.Length; i++)
                    if (tasks[i] != null)
                        await tasks[i];
            }
        }
      
        private Point CalculatePointPosition(Edge edge, int height)
        {
            if (edge.VerticeFirst.GetPosition().Y == edge.VerticeSecond.GetPosition().Y)
                return new Point(edge.VerticeFirst.GetPosition().X, height);
            if (edge.VerticeFirst.GetPosition().X > edge.VerticeSecond.GetPosition().X)
            {
                Vertice temp = edge.VerticeFirst;
                edge.VerticeFirst = edge.VerticeSecond;
                edge.VerticeSecond = temp;
            }

            int x = edge.VerticeFirst.GetPosition().X + Math.Abs(((edge.VerticeFirst.GetPosition().Y - height)
                * (edge.VerticeFirst.GetPosition().X - edge.VerticeSecond.GetPosition().X))
                / (edge.VerticeFirst.GetPosition().Y - edge.VerticeSecond.GetPosition().Y));

            return new Point(x, height);
        }

        protected async Task ChooseColoring(Point leftPoint, int width, Edge leftEdge, Edge rightEdge)
        {
            switch (ColoringType)
            {
                case Coloring.Solid:
                    {
                        SolidColoring(leftPoint, width);
                        break;
                    }
                case Coloring.Interpolation:
                    {
                        await InterpolationColoring(leftPoint, width, leftEdge, rightEdge);
                        break;
                    }
                case Coloring.Texture:
                    {
                        TextureColoring(leftPoint, width);
                        break;
                    }
            }
        }

        protected void SolidColoring(Point leftPoint, int width)
        {
            int y = leftPoint.Y;
            if (Bitmap.Height <= y || y < 0)
                return;

            for (int x = leftPoint.X; x <= leftPoint.X + width; x++)
            {
                if (Bitmap.Width > x && x >= 0)
                {
                    Bitmap.SetPixel(x, y, _color);
                }
            }
        }

        protected async Task InterpolationColoring(Point leftPoint, int width, Edge leftEdge, Edge rightEdge)
        {
            int y = leftPoint.Y;
            if (Bitmap.Height <= y || y < 0)
                return;

            var leftTask = CalculateColorOnLineSection(leftEdge, leftPoint);
            var rightPoint = new Point(leftPoint.X + width, y);
            var rightTask = CalculateColorOnLineSection(rightEdge, rightPoint);
            await leftTask;
            Color leftPointColor = leftTask.Result;
            await rightTask;
            Color rightPointColor = rightTask.Result;

            Vertice leftVertice = new Vertice(leftPoint, leftPointColor);
            Vertice rightVertice = new Vertice(rightPoint, rightPointColor);
           

            for (int x = leftPoint.X; x <= leftPoint.X + width; x++)
            {
                Color color = await CalculateColorOnLineSection(new Edge(rightVertice, leftVertice), new Point(x, y));
                if (Bitmap.Width > x && x >= 0)
                {
                    Bitmap.SetPixel(x, y, color);
                }
            }

        }

        private Task<Color> CalculateColorOnLineSection(Edge edge, Point point)
        {
            Color color;
            if (edge.VerticeFirst.CalculateDistance(edge.VerticeSecond.GetPosition()) == 0)
                color = Color.FromArgb(
                    (edge.VerticeFirst.GetColor().A + edge.VerticeSecond.GetColor().A) / 2,
                    (edge.VerticeFirst.GetColor().R + edge.VerticeSecond.GetColor().R) / 2,
                    (edge.VerticeFirst.GetColor().G + edge.VerticeSecond.GetColor().G) / 2,
                    (edge.VerticeFirst.GetColor().B + edge.VerticeSecond.GetColor().B) / 2
                    );
            else
            {
                double ratio = (double)edge.VerticeFirst.CalculateDistance(point)
                    / (double)edge.VerticeFirst.CalculateDistance(edge.VerticeSecond.GetPosition());
                color = Color.FromArgb(
                    (int)(edge.VerticeFirst.GetColor().A * (1 - ratio) + edge.VerticeSecond.GetColor().A * ratio),
                    (int)(edge.VerticeFirst.GetColor().R * (1 - ratio) + edge.VerticeSecond.GetColor().R * ratio),
                    (int)(edge.VerticeFirst.GetColor().G * (1 - ratio) + edge.VerticeSecond.GetColor().G * ratio),
                    (int)(edge.VerticeFirst.GetColor().B * (1 - ratio) + edge.VerticeSecond.GetColor().B * ratio)
                    );
            }
            return Task.FromResult(color);
        }

        protected void TextureColoring(Point leftPoint, int width)
        {
            int y = leftPoint.Y;
            if (Bitmap.Height <= y || y < 0)
                return;

            int horizontal = leftPoint.X - _vertices[_boundariesIndex.mostLeft].GetPosition().X;
            int vertical = y - _vertices[_boundariesIndex.mostUp].GetPosition().Y;
            while (horizontal >= _texture.Width)
                horizontal -= _texture.Width;
            while (vertical >= _texture.Height)
                vertical -= _texture.Height;
            Bitmap.SetPixel(leftPoint.X, y, _texture.GetPixel(horizontal, vertical));
            for (int x = leftPoint.X + 1; x <= leftPoint.X + width; x++)
            {
                horizontal++;
                if (horizontal >= _texture.Width)
                    horizontal -= _texture.Width;
                if (Bitmap.Width > x && x >= 0)
                {
                    Bitmap.SetPixel(x, y, _texture.GetPixel(horizontal, vertical));
                }
            }



        }
    }
}
