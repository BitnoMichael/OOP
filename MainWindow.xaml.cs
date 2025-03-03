using OOPaint;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        public enum Tool { TOOL_NONE, TOOL_SQUARE, TOOL_LINE, TOOL_ELLIPSE, TOOL_TRIANGLE };
        private Tool curTool = Tool.TOOL_NONE;
        public class ShapeFactory
        {
            public static Shape createShape(Tool curTool, Color brushColor, Color penColor, double penWidth, Point curPoint)
            {
                Shape shape;

                switch (curTool)
                {
                    case Tool.TOOL_SQUARE:
                        shape = new Rectangle
                        {
                            Fill = new SolidColorBrush(brushColor),
                            Stroke = new SolidColorBrush(penColor),
                            StrokeThickness = penWidth,
                            Width = 0, // Ширина установлена в 0
                            Height = 0 // Высота установлена в 0
                        };
                        Canvas.SetLeft(shape, curPoint.X);
                        Canvas.SetTop(shape, curPoint.Y);
                        break;

                    case Tool.TOOL_LINE:
                        shape = new Line
                        {
                            Stroke = new SolidColorBrush(penColor),
                            StrokeThickness = penWidth,
                            X1 = curPoint.X, // Начальная точка
                            Y1 = curPoint.Y,
                            X2 = curPoint.X + 0, // Конечная точка (0, чтобы линия была невидима)
                            Y2 = curPoint.Y + 0
                        };
                        break;

                    case Tool.TOOL_ELLIPSE:
                        shape = new Ellipse
                        {
                            Fill = new SolidColorBrush(brushColor),
                            Stroke = new SolidColorBrush(penColor),
                            StrokeThickness = penWidth,
                            Width = 0, // Ширина установлена в 0
                            Height = 0 // Высота установлена в 0
                        };
                        Canvas.SetLeft(shape, curPoint.X);
                        Canvas.SetTop(shape, curPoint.Y);
                        break;

                    case Tool.TOOL_TRIANGLE:
                        shape = new Polygon
                        {
                            Fill = new SolidColorBrush(brushColor),
                            Stroke = new SolidColorBrush(penColor),
                            StrokeThickness = penWidth,
                            Points = new PointCollection
                            {
                                new Point(curPoint.X, curPoint.Y), // Вершина 1
                                new Point(curPoint.X + 0, curPoint.Y + 0), // Вершина 2
                                new Point(curPoint.X + 0, curPoint.Y + 0) // Вершина 3
                            }
                        };
                        break;

                    default:
                        return null;
                }
                return shape;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RBLine_Click(object sender, RoutedEventArgs e)
        {
            curTool = Tool.TOOL_LINE;
        }

        private void RBCircle_Click(object sender, RoutedEventArgs e)
        {
            curTool = Tool.TOOL_ELLIPSE;
        }

        private void RBTriangle_Click(object sender, RoutedEventArgs e)
        {
            curTool = Tool.TOOL_TRIANGLE;
        }

        private void RBSquare_Click(object sender, RoutedEventArgs e)
        {
            curTool = Tool.TOOL_SQUARE;
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
            drawingCanvas.CurShape = ShapeFactory.createShape(
                this.curTool, 
                drawingCanvas.BrushColor, 
                drawingCanvas.PenColor, 
                drawingCanvas.PenWidth, 
                e.GetPosition(drawingCanvas)
            );
            drawingCanvas.Children.Add(drawingCanvas.CurShape);
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
    }
}
