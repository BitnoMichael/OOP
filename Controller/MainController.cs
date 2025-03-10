using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPaint.ModelConstants;
using System.Windows.Controls;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Media;
using OOPaint.Model;
using System.Net;

namespace OOPaint
{
    public partial class MainController
    {
        private MainWindow _view;
        private ShapeModel _model = new ShapeModel();
        private SettingsModel _settings = new SettingsModel();
        public MainController(MainWindow view)
        {
            _view = view;
        }
        public void StopDraw(Point endPoint)
        {
            var drawingCanvas = _view.canvas;
            var tool = _settings.curToolIndex;
            var startPoint = _view.canvas.StartPoint;

            drawingCanvas.IsDrawing = false;
            var shapeCreator = Services.MyShapeCreatorsSingleton.GetInstance(tool);
            if (shapeCreator != null)
            {
                _model.Add(shapeCreator.createDrawableShape(
                    _settings.BrushColor,
                    _settings.PenColor,
                    _settings.PenWidth,
                    startPoint,
                    endPoint
                ));
            }
        }
        public void StartDraw(Point startPoint)
        {
            var drawingCanvas = _view.canvas;
            var tool = _settings.curToolIndex;
            IShapeCreator shapeCreator = Services.ShapeCreatorsSingleton.GetInstance(tool);
            if (shapeCreator != null)
            {
                drawingCanvas.StartPoint = startPoint;
                drawingCanvas.IsDrawing = true;
                drawingCanvas.CurShapeCreator = shapeCreator;
                drawingCanvas.CurShape = shapeCreator.CreateShape(
                    _settings.BrushColor,
                    _settings.PenColor,
                    _settings.PenWidth,
                    startPoint,
                    startPoint
                );
                drawingCanvas.AddShape(drawingCanvas.CurShape);
            }
        }

        public void RedrawCurObject(Point endPoint)
        {
            if (_view.canvas.IsDrawing)
            {
                _view.canvas.CurShapeCreator.TransformShape(_view.canvas.CurShape, _view.canvas.StartPoint, endPoint);
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
            _view.canvas.Undo();
            _model.PollLast();
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
                ShapeFileHandler.SaveCollection(_model.getShapesAsList(), saveFileDialog.FileName);
            }
        }
        private void redrawView()
        {
            _view.canvas.Children.Clear();
            foreach (var item in _model.getShapesAsList())
            {
                var shapeCreator = Services.ShapeCreatorsSingleton.GetInstance(item.GetType());
                if (shapeCreator != null)
                {
                    var shape = shapeCreator.CreateShape(item.BrushColor, item.PenColor, item.PenWidth, item.OuterPoint1, item.OuterPoint2);
                    _view.canvas.Children.Add(shape);
                }
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
                _model = new ShapeModel(ShapeFileHandler.LoadCollection(openFileDialog.FileName));
                redrawView();
            }
        }
    }
}
