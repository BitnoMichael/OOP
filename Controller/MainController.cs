using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Media;
using System.Net;
using OOPaint.Services;

namespace OOPaint
{
    public partial class MainController
    {
        private MainWindow _view;
        private UndoRedoService _undoRedoService;
        private PluginService _pluginService;
        private SettingsModel _settings = new SettingsModel(Color.FromRgb(0, 0, 0), Color.FromRgb(0, 0, 0), 2, 0);
        public MainController(MainWindow view)
        {
            _view = view;
            _undoRedoService = new UndoRedoService(_view.canvas.Children);
            _pluginService = new PluginService(_view);
        }
        public void Draw(Point lastPoint)
        {
            if (_view.canvas.IsDrawing)
            {
                if (MyShapeCreatorsSingleton.GetInstance().IsComplexShapeCreator(_settings.curToolIndex))
                {
                    this.ContinueDraw(lastPoint);
                }
                else
                {
                    StopDraw(lastPoint);
                }
            }
            else
            {
                StartDraw(lastPoint);
            }
        }
        public void ContinueDraw(Point lastPoint)
        {
            if (_view.canvas.IsDrawing) 
                _view.canvas.SettedPoints.Add(lastPoint);
        }
        public void StopDraw(Point endPoint)
        {
            if (!_view.canvas.IsDrawing)
                return;
            var drawingCanvas = _view.canvas;
            var tool = _settings.curToolIndex;
            var points = _view.canvas.SettedPoints;
            points.Add(endPoint);

            drawingCanvas.IsDrawing = false;
            var shapeCreator = Services.MyShapeCreatorsSingleton.GetInstance().GetCreator(this._settings.curToolIndex);
            points.Clear();
        }
        public void StartDraw(Point startPoint)
        {
            if (_view.canvas.IsDrawing)
                return;
            var drawingCanvas = _view.canvas;
            var tool = _settings.curToolIndex;
            IMyShapeCreator shapeCreator = Services.MyShapeCreatorsSingleton.GetInstance().GetCreator(tool);
            if (shapeCreator != null)
            {
                drawingCanvas.SettedPoints.Add(startPoint);
                drawingCanvas.IsDrawing = true;
                drawingCanvas.CurShapeCreator = shapeCreator;
                var initPoints = new PointCollection(drawingCanvas.SettedPoints);
                initPoints.Add(startPoint);
                drawingCanvas.CurShape = shapeCreator.CreateShape(
                    _settings.BrushColor,
                    _settings.PenColor,
                    _settings.PenWidth,
                    initPoints
                );
                _undoRedoService.Add(drawingCanvas.CurShape);
            }
        }

        public void RedrawCurObject(Point endPoint)
        {
            if (_view.canvas.IsDrawing)
            {
                _view.canvas.CurShapeCreator.TransformShape(_view.canvas.CurShape, _view.canvas.SettedPoints, endPoint);
            }
        }

        public void ChoosePenColor()
        {
            using (System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog())
            {
                if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    _settings.PenColor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }

        public void ChooseBrushColor()
        {
            using (System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog())
            {
                if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    _settings.BrushColor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }

        public void ChangePenWidth(int width)
        {
            _settings.PenWidth = width;
        }

        public void ChooseTool(int tool)
        {
            _settings.curToolIndex= tool;
        }

        public void Undo()
        {
            _undoRedoService.Undo();
        }
        public void Redo()
        {
            _undoRedoService.Redo();
        }

        private List<MyShape> modelShapesToList()
        {
            var list = new List<MyShape>();
            foreach (var shape in _view.canvas.Children)
            {
                if (shape is MyShape)
                {
                    list.Add((MyShape)shape);
                }
            }
            return list;
        }
        private void listToModelShapes(List<MyShape> list)
        {
            _view.canvas.Children.Clear();
            foreach (var elem in list)
                _view.canvas.Children.Add(elem);
        }
        public void SaveShapes()
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog
            {
                Filter = "Shapes files (*.shapes)|*.shapes",
                DefaultExt = ".shapes",
                AddExtension = true
            };
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ShapeFileHandler.Save(modelShapesToList(), saveFileDialog.FileName);
            }
        }
        public void OpenShapes()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "(*.shapes)|*.shapes",
                DefaultExt = ".shapes",
                AddExtension = true
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listToModelShapes(ShapeFileHandler.Load(openFileDialog.FileName));
                _undoRedoService.ClearHistory();
            }
        }
        public void LoadPlugin()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "(*.dll)|*.dll",
                DefaultExt = ".dll",
                AddExtension = true
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _pluginService.LoadPlugin(openFileDialog.FileName);
            }
        }
    }
}
