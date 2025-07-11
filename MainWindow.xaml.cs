﻿using OOPaint;
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

namespace OOPaint
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            controller = new MainController(this);
        }
        private MainController controller;
        private Point _mousePosition = new Point();
        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left || controller == null)
                return;
            MyCanvas drawingCanvas = (MyCanvas)sender;

            controller.Draw(_mousePosition);
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            _mousePosition = e.GetPosition(canvas);
            if (controller != null)
                controller.RedrawCurObject(_mousePosition);
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                controller.StopDraw(_mousePosition);
        }

        private void BtnRedo_Click(object sender, RoutedEventArgs e)
        {
            if (controller != null)
                controller.Redo();
        }

        private void BtnPlugin_Click(object sender, RoutedEventArgs e)
        {
            if (controller != null)
                controller.LoadPlugin();
        }
    }
}