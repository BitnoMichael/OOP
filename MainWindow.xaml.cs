using OOPaint;
using OOPaint.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using static OOPaint.ModelConstants;

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
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            controller = new MainController(this);
        }
        MainController controller;
        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left || controller == null)
                return;
            MyCanvas drawingCanvas = (MyCanvas)sender;
            var curPoint = e.GetPosition(drawingCanvas);

            if (drawingCanvas.IsDrawing)
            {
                controller.StopDraw(curPoint);
            }
            else
            {
                controller.StartDraw(curPoint);
            }
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var curPoint = e.GetPosition(canvas);
            if (controller != null)
                controller.RedrawCurObject(curPoint);
        }

        private void btnPickPenColor_Click(object sender, RoutedEventArgs e)
        {
            if (controller != null)
                controller.ChoosePenColor();
        }

        private void btnPickBrushColor_Click(object sender, RoutedEventArgs e)
        {
            if (controller != null)
            {
                controller.ChooseBrushColor();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sender.GetType() != typeof(ComboBox) || controller == null)
                return;
            ComboBox listBox = sender as ComboBox;
            controller.ChangePenWidth(listBox.SelectedIndex);
        }

        private void CmbBoxTool_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender.GetType() != typeof(ComboBox) || controller == null)
                return;
            ComboBox comboBox = sender as ComboBox;
            controller.ChooseTool(comboBox.SelectedIndex);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (controller != null)
                controller.Undo();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (controller != null)
                controller.SaveShapes();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (controller != null)
                controller.OpenShapes();
        }
    }
}