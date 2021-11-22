using FillingShapes.Data;
using FillingShapes.Data.Decorator;
using FillingShapes.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingShapes
{
    public partial class MainForm
    {
        private void SetBitmap()
        {
            mainPictureBox.Image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            Bitmap bitmap = (Bitmap)mainPictureBox.Image;
            Graphics graphics = Graphics.FromImage(mainPictureBox.Image);
            BaseGraphicObject.Bitmap = bitmap;
            BaseGraphicObject.Graphics = graphics;
        }

        private void SetState() => State = State.Default;
        private void SetState(State state) => State = state;

        private void SetAllDefault()
        {
            SetState();
            UnSelectShape();
        }

        private void DrawAllShapes()
        {
            SetBitmap();
            Task task = null;
            if (State == State.NewShape)
                task = SelectedPolygon.Draw();
            Task[] tasks = new Task[_polygons.Count];
            int i = 0;
            foreach(var polygon in _polygons)
            {
                tasks[i] = polygon.Draw();
                i++;
            };

            Task.WaitAll(tasks);
            if (task != null)
                task.Wait();
        }

        private void SelectShape(Point point)
        {
            UnSelectShape();
            foreach (var shape in _polygons)
            {
                if (shape.CheckIfClicked(point))
                {
                    shape.Select();
                    SelectedPolygon = shape;
                    SetState(State.MoveShape);
                    break;
                }
            }
        }

        private void SelectVertice(Vertice vertice)
        {
            vertice.Select();
            SelectedVertice = vertice;
            SetState(State.MoveVertice);
        }

        private void SelectEdge(Vertice vertice)
        {
            vertice.Select();
            SelectedEdge = new Edge(SelectedVertice, vertice);
            SetState(State.SelectedEdge);
        }

        private void MoveShape(IGraphicObject graphicObject, Point position)
        {
            graphicObject.Move(_position, position);
            DrawAllShapes();
        }

        private void MoveVertice(Polygon baseShape, Vertice vertice, Point position)
        {
            baseShape.MoveVertice(vertice, _position, position);
            DrawAllShapes();
        }

        private void UnSelectShape()
        {
            if (SelectedPolygon != null)
            {
                UnSelectVertice();
                HideAllOptions();
                SelectedPolygon.UnSelect();
                SelectedPolygon = null;
                SetState(State.Default);
                DrawAllShapes();
            }
        }

        private void UnSelectVertice()
        {
            if (SelectedVertice != null)
            {
                UnSelectEdge();
                SelectedVertice.UnSelect();
                SelectedVertice.Draw();
                SelectedVertice = null;
                SetState(State.SelectedShape);
            }
        }

        private void UnSelectEdge()
        {
            if (SelectedEdge != null)
            {
                SelectedEdge.VerticeFirst.UnSelect();
                SelectedEdge.VerticeFirst.Draw();
                SelectedEdge.VerticeSecond.UnSelect();
                SelectedEdge.VerticeSecond.Draw();
                SelectedEdge = null;
                SetState(State.SelectedShape);
            }
        }
        
        private void SetCorrectOptions()
        {
            HideAllOptions();
            switch (State)
            {
                case State.NewShape:
                    {
                        NewPolygonOptions();
                        break;
                    }
                case State.SelectedShape:
                case State.MoveShape:
                    {
                        PolygonOptions();
                        break;
                    }
                case State.SelectedVertice:
                case State.MoveVertice:
                    {
                        VerticeOptions();
                        break;
                    }
                case State.SelectedEdge:
                    {
                        EdgeOptions();
                        break;
                    }
                case State.Playing:
                    {
                        PlayingOptons();
                        break;
                    }
            }
        }

        private void NewPolygonOptions()
        {
            PolygonOptions();
            addButton.Enabled = true;
        }

        private void PolygonOptions()
        {
            colorButton.Enabled = textureColoringButton.Enabled = true;
            deleteButton.Enabled = true;
            solidColoringButton.Enabled = interpolationColoringButton.Enabled = true;
        }

        private void VerticeOptions()
        {
            colorButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        private void EdgeOptions()
        {
            addButton.Enabled = true;
        }

        private void PlayingOptons()
        {
            startButton.Text = "Pause";
            createButton.Enabled = false;
            speedTrackBar.Enabled = true;
        }

        private void HideAllOptions()
        {
            colorButton.Enabled = textureColoringButton.Enabled = false;
            solidColoringButton.Enabled = interpolationColoringButton.Enabled = false;
            addButton.Enabled = deleteButton.Enabled = false;
            positionXTextBox.Enabled = positionYTextBox.Enabled = false;
            speedTrackBar.Enabled = false;
            createButton.Enabled = true;
            startButton.Text = "Start";
        }

        private bool CheckIfShape()
        {
            if (SelectedPolygon != null && SelectedPolygon.CheckIfClicked(_position))
            {
                return true;
            }
            else
            {
                UnSelectShape();
                return false;
            }
        }

        private bool CheckIfVertice(out Vertice vertice)
        {
            vertice = null;
            if (SelectedPolygon != null && SelectedPolygon.CheckIfClickedVertice(_position, out Vertice clickedVertice))
            {
                vertice = clickedVertice;
                return true;
            }
            CheckIfShape();
            return false;
        }

        private bool CheckIfEdge(out Vertice vertice)
        {
            vertice = null;
            if (SelectedVertice != null && SelectedPolygon.CheckIfClickedVertice(_position, out Vertice clickedVertice))
            {
                if (SelectedPolygon.CheckIfEdge(SelectedVertice, clickedVertice))
                {
                    vertice = clickedVertice;
                    return true;
                }
                else
                {
                    UnSelectVertice();
                    SelectVertice(clickedVertice);
                }
            }
            else
            {
                UnSelectVertice();
                if (!SelectedPolygon.CheckIfClicked(_position))
                    UnSelectShape();
            }
            return false;
        }

        private void StartMoving()
        {
            _movingShapes = new();
            Random random = new Random();
            foreach (var polygon in _polygons)
            {
                _movingShapes.Add(new MoveRandomly(polygon, random.Next(0, 359), _speed));
            }

            timer.Start();
            SetState(State.Playing);
        }

        private void StopMoving()
        {
            timer.Stop();
            SetState();
            _movingShapes.Clear();
        }

        private void CountDown(object sender, EventArgs e)
        {
            foreach (var shape in _movingShapes)
            {
                shape.Move(new Point(0, 0), new Point(1, 1));
                SetBitmap();
            }
            DrawAllShapes();
        }
    }
}
