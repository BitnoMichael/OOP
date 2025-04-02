using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint
{
    public abstract class MyShape : Shape
    {
        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.Register(
                "Points",
                typeof(Point[]),
                typeof(MyShape),
                new FrameworkPropertyMetadata(
                    new Point[0],
                    FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty BrushColorProperty =
            DependencyProperty.Register(
                "BrushColor",
                typeof(Color),
                typeof(MyShape),
                new FrameworkPropertyMetadata(
                    Colors.Transparent,
                    FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty PenColorProperty =
            DependencyProperty.Register(
                "PenColor",
                typeof(Color),
                typeof(MyShape),
                new FrameworkPropertyMetadata(
                    Colors.Black,
                    FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty PenWidthProperty =
            DependencyProperty.Register(
                "PenWidth",
                typeof(double),
                typeof(MyShape),
                new FrameworkPropertyMetadata(
                    1.0,
                    FrameworkPropertyMetadataOptions.AffectsRender));

        public Point[] Points
        {
            get => (Point[])GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }

        public Color BrushColor
        {
            get => (Color)GetValue(BrushColorProperty);
            set
            {
                this.Fill = new SolidColorBrush(value);
                SetValue(BrushColorProperty, value);
            }
        }

        public Color PenColor
        {
            get => (Color)GetValue(PenColorProperty);
            set
            {
                this.Stroke = new SolidColorBrush(value);
                SetValue(PenColorProperty, value);
            }
        }

        public double PenWidth
        {
            get => (double)GetValue(PenWidthProperty);
            set
            {
                this.StrokeThickness = value;
                SetValue(PenWidthProperty, value);
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            // Обновляем Fill и Stroke при изменении цветов
            if (e.Property == BrushColorProperty)
            {
                Fill = new SolidColorBrush(BrushColor);
            }
            else if (e.Property == PenColorProperty)
            {
                Stroke = new SolidColorBrush(PenColor);
            }
            else if (e.Property == PenWidthProperty)
            {
                StrokeThickness = PenWidth;
            }
        }
        public abstract bool isComplex();
    }
}
