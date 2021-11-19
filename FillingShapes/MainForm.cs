using FillingShapes.Data;
using FillingShapes.Data.Decorator;
using FillingShapes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillingShapes
{
    public partial class MainForm : Form
    {
        private readonly List<Polygon> _polygons = new();
        List<IGraphicObject> movingShapes;
        private Point _position;
        private Speed _speed = new(5);
        private Polygon SelectedPolygon { get; set; }
        private Vertice SelectedVertice { get; set; }
        private Edge SelectedEdge { get; set; }
        private State State { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HideAllOptions();
            SetAllDefault();
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _position = new Point(e.X, e.Y);

            switch (State)
            {
                case State.Default:
                    {
                        SelectShape(_position);
                        break;
                    }
                case State.NewShape:
                    {
                        var vertice = new Vertice(_position);
                        SelectedPolygon.AddVertice(vertice);
                        break;
                    }
                case State.SelectedShape:
                    {
                        if (CheckIfVertice(out Vertice clickedVertice))
                        {
                            SelectVertice(clickedVertice);
                        }

                        if (SelectedVertice == null && CheckIfShape())
                        {
                            SetState(State.MoveShape);
                        }
                        break;
                    }
                case State.SelectedVertice:
                    {
                        if (CheckIfEdge(out Vertice clickedVertice))
                        {
                            SelectEdge(clickedVertice);
                        }
                        break;
                    }
            }
            DrawAllShapes();
            SetCorrectOptions();
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            var position = new Point(e.X, e.Y);
            switch (State)
            {
                case State.MoveShape:
                    {
                        MoveShape(SelectedPolygon, position);
                        break;
                    }
                case State.MoveVertice:
                    {
                        MoveVertice(SelectedPolygon, SelectedVertice, position);
                        break;
                    }
            }
            _position = position;
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (State)
            {
                case State.MoveShape:
                    {
                        SetState(State.SelectedShape);
                        break;
                    }
                case State.MoveVertice:
                    {
                        SetState(State.SelectedVertice);
                        break;
                    }
            }
            DrawAllShapes();
        }

        private void createButton_MouseDown(object sender, MouseEventArgs e)
        {
            UnSelectShape();
            SetState();
            switch (State)
            {
                case State.Default:
                    {
                        SelectedPolygon = new Polygon();
                        SetState(State.NewShape);
                        SelectedPolygon.Select();
                        break;
                    }
            }
        }

        private void addButton_MouseDown(object sender, MouseEventArgs e)
        {
            switch (State)
            {
                case State.NewShape:
                    {
                        if (SelectedPolygon.CheckIfCorrect())
                        {
                            _polygons.Add(SelectedPolygon);
                        }
                        break;
                    }
                case State.SelectedEdge:
                    {
                        SelectedPolygon.AddVerticeBetween(SelectedEdge.VerticeFirst, SelectedEdge.VerticeSecond);
                        break;
                    }
            }
            SetState();
            UnSelectShape();
        }

        private void deleteButton_MouseDown(object sender, MouseEventArgs e)
        {
            switch (State)
            {
                case State.SelectedShape:
                    {
                        _polygons.Remove(SelectedPolygon);
                        break;
                    }
                case State.SelectedVertice:
                    {
                        SelectedPolygon.Remove(SelectedVertice);
                        if (!SelectedPolygon.CheckIfCorrect())
                            _polygons.Remove(SelectedPolygon);
                        break;
                    }
            }
            SetState();
            UnSelectShape();
        }

        private void colorButton_MouseDown(object sender, MouseEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            switch (State)
            {
                case State.NewShape:
                case State.SelectedShape:
                    {
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            SelectedPolygon.ChangeColor(colorDialog.Color);
                        }
                        break;
                    }
                case State.SelectedVertice:
                    {
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            SelectedVertice.ChangeColor(colorDialog.Color);
                        }
                        break;
                    }
            }
            DrawAllShapes();
        }

        private void textureButton_MouseDown(object sender, MouseEventArgs e)
        {
            switch (State)
            {
                case State.NewShape:
                case State.SelectedShape:
                    {
                        break;
                    }
            }
        }

        private void startButton_MouseDown(object sender, MouseEventArgs e)
        {
            switch (State)
            {
                case State.Playing:
                    {
                        StopMoving();
                        break;
                    }
                default:
                    {
                        StartMoving();
                        break;
                    }
            }
            SetCorrectOptions();
        }

        private void speedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _speed.Value = speedTrackBar.Value;
        }
    }
}
