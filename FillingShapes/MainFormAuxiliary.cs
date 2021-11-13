using FillingShapes.Data;
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
            BaseShape.Bitmap = bitmap;
            BaseShape.Graphics = graphics;
            Vertice.Bitmap = bitmap;
            Vertice.Graphics = graphics;
        }

        private void SetState() => State = State.Default;
        private void SetState(State state) => State = state;

        private void SetAllDefault()
        {
            SetState();
            SelectedPolygon.UnSelect();
            SelectedVertice.UnSelect();
        }

        private void DrawAllShapes()
        {
            SetBitmap();
            if (State == State.NewShape)
                SelectedPolygon.Draw();
            foreach (var polygon in _polygons)
            {
                polygon.Draw();
            }
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

        private void MoveObject(IGraphicObject graphicObject, Point position)
        {
            graphicObject.Move(_position, position);
            DrawAllShapes();
        }

        private void UnSelectShape()
        {
            if (SelectedPolygon != null)
            {
                UnSelectVertice();
                HideAllOptions();
                SelectedPolygon.UnSelect();
                DrawAllShapes();
                SelectedPolygon = null;
                SetState(State.Default);
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

        private void SetOptionsForCorrectShape()
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
            }
        }

        private void NewPolygonOptions()
        {
            PolygonOptions();
            addButton.Enabled = true;
        }

        private void PolygonOptions()
        {
            colorButton.Enabled = textureButton.Enabled = true;
            deleteButton.Enabled = true;
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

        private void HideAllOptions()
        {
            colorButton.Enabled = textureButton.Enabled = false;
            addButton.Enabled = deleteButton.Enabled = false;
            positionXTextBox.Enabled = positionYTextBox.Enabled = false;
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


        private void MoveAllShapes()
        {   

        }

    }
}
