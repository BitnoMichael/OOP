using OOPaint;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
Shapes(System.Windows.Shapes)
├── Shape(абстрактный класс)
│   ├── Fill(Brush)
│   ├── Stroke(Brush)
│   ├── StrokeThickness(double)
│   └── Opacity(double)
├── Rectangle(Shape)
│   ├── RadiusX(double)
│   ├── RadiusY(double)
│   ├── Width(double)
│   ├── Height(double)
│   └── StrokeDashArray(DoubleCollection)
├── Ellipse(Shape)
│   ├── Width(double)
│   ├── Height(double)
│   └── StrokeDashArray(DoubleCollection)
├── Line(Shape)
│   ├── X1(double)
│   ├── Y1(double)
│   ├── X2(double)
│   ├── Y2(double)
│   └── StrokeDashArray(DoubleCollection)
├── Polyline (Shape)
│   ├── Points (PointCollection)
│   ├── StrokeDashArray (DoubleCollection)
│   └── IsClosed (bool)
├── Polygon (Shape)
│   ├── Points (PointCollection)
│   ├── StrokeDashArray (DoubleCollection)
│   └── IsClosed (bool)
└── Path (Shape)
    ├── Data (Geometry)
    ├── StrokeDashArray (DoubleCollection)
    ├── FillRule (FillRule)
    ├── Stroke (Brush)
    └── Fill (Brush)
*/

namespace OOPaint
{    public partial class MainWindow : Window
    {
        private Tool curTool = Tool.TOOL_NONE;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
                return;
            if (sender.GetType() != typeof(DrawingCanvas))
                return;

            DrawingCanvas drawingCanvas = (DrawingCanvas)sender;
            if (drawingCanvas.IsDrawing || curTool == Tool.TOOL_NONE)
            {
                drawingCanvas.IsDrawing = false;
                return;
            }
            drawingCanvas.startPoint = e.GetPosition(drawingCanvas);
            drawingCanvas.IsDrawing = true;
            drawingCanvas.CurShape = ShapeFactory.СreateDrawableShape(
                this.curTool, 
                drawingCanvas.BrushColor, 
                drawingCanvas.PenColor, 
                drawingCanvas.PenWidth, 
                e.GetPosition(drawingCanvas)
            );
            drawingCanvas.AddShape(drawingCanvas.CurShape);
        }
        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender.GetType() != typeof(DrawingCanvas))
                return;

            DrawingCanvas drawingCanvas = (DrawingCanvas)sender;
            if (drawingCanvas.IsDrawing)
                drawingCanvas.drawShape(drawingCanvas.CurShape, e.GetPosition(drawingCanvas));
        }

        private void btnPickPenColor_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog())
            {
                if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    this.MyCanvas.PenColor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }

        private void btnPickBrushColor_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog())
            {
                if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    this.MyCanvas.BrushColor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sender.GetType() != typeof(ComboBox) || this.MyCanvas == null)
                return;
            ComboBox listBox = sender as ComboBox;
            this.MyCanvas.PenWidth = listBox.SelectedIndex;
        }

        private void CmbBoxTool_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender.GetType() != typeof(ComboBox)) 
                return;
            ComboBox comboBox = sender as ComboBox;
            curTool = (Tool)comboBox.SelectedIndex;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.MyCanvas.Undo();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog
            {
                Filter = "Shapes files (*.shapes)|*.shapes",
                DefaultExt = ".shapes",
                AddExtension = true
            };
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DrawableShapeFileHandler.SaveCollection(this.MyCanvas.Model, saveFileDialog.FileName);
            }
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "(*.shapes)|*.shapes",
                DefaultExt = ".shapes",
                AddExtension = true
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DrawableShapeFileHandler.LoadCollection(this.MyCanvas.Model, openFileDialog.FileName);
                this.MyCanvas.ValidateView();
            }
        }
    }
}
