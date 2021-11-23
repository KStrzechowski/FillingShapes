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
        List<IGraphicObject> _movingShapes;
        private Light _light;
        private Point _position;
        private Speed _speed = new(5);
        private double _Kd;
        private double _Ks;
        private int _M;
        private int _lightHeight;
        private Light SelectedLight { get; set; }
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
            SetBitmap();
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
                        SelectLight(_position);
                        if (SelectedLight == null)
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
                case State.SelectedEdge:
                    {
                        UnSelectShape();
                        break;
                    }
                case State.SelectedLight:
                    {
                        if (_light.CheckIfClicked(_position))
                        {
                            SetState(State.MoveLight);
                        }
                        else
                        {
                            UnSelectLight();
                        }
                        break;
                    }
            }
            SetCorrectOptions();
            DrawAllShapes();

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
                case State.MoveLight:
                    {
                        MoveLight(SelectedLight, position);
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
                case State.MoveLight:
                    {
                        SetState(State.SelectedLight);
                        break;
                    }
            }
            DrawAllShapes();
        }

        private void createButton_MouseDown(object sender, MouseEventArgs e)
        {
            UnSelectAll();
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
                            if (_light != null)
                                SelectedPolygon.Light = _light;
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
                            SelectedPolygon.SetColor(colorDialog.Color);
                        }
                        break;
                    }
                case State.SelectedVertice:
                    {
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            SelectedVertice.SetColor(colorDialog.Color);
                        }
                        break;
                    }
                case State.SelectedLight:
                    {
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            SelectedLight.SetColor(colorDialog.Color);
                        }
                        break;
                    }
            }
            DrawAllShapes();
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

        private void solidColoringButton_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedPolygon.ColoringType = Coloring.Solid;
            DrawAllShapes();
        }

        private void interpolationColoringButton_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedPolygon.ColoringType = Coloring.Interpolation;
            DrawAllShapes();
        }

        private void textureColoringButton_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedPolygon.ColoringType = Coloring.Texture;
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.Filter = "Picture files|*.png;*.jpg;*.bmp";
            loadFileDialog.FilterIndex = 1;
            loadFileDialog.RestoreDirectory = true;

            switch (State)
            {
                case State.NewShape:
                case State.SelectedShape:
                    {
                        if (loadFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var fileName = loadFileDialog.FileName;
                            var image = Image.FromFile(fileName);
                            SelectedPolygon.SetTexture(image);
                        }
                        break;
                    }
            }
            DrawAllShapes();
        }

        private void lightButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_light == null)
            {
                _light = new Light(new Point(20, 20), Color.White, _lightHeight, _M, _Kd, _Ks);
                AddLight();
                lightButton.Text = "Remove Light";
            }
            else
            {
                UnSelectLight();
                _light = null;
                RemoveLight();
                lightButton.Text = "Add Light";
            }
            DrawAllShapes();
        }

        private void HeightTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _lightHeight = int.Parse(HeightTextBox.Text);
                if (_light != null)
                {
                    _light.z = _lightHeight;
                    DrawAllShapes();
                }
            }
        }

        private void KdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _Kd = KdTrackBar.Value * 0.01;
            if (_light != null)
            {
                _light.Kd = _Kd;
                DrawAllShapes();
            }
        }

        private void KsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _Ks = KsTrackBar.Value * 0.01;
            if (_light != null)
            {
                _light.Ks = _Ks;
                DrawAllShapes();
            }
        }

        private void MTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _M = MTrackBar.Value;
            if (_light != null)
            {
                _light.m = _M;
                DrawAllShapes();
            }
        }
    }
}
