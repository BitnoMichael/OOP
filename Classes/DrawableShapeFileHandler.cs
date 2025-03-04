using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows;
using OOPaint.Shapes;
using System.CodeDom.Compiler;

namespace OOPaint
{
    internal static class DrawableShapeFileHandler
    {
        public static void SaveCollection(Stack<DrawableShape> collection, string fileName)
        {
            Stack<DrawableShape> tempCollection = new Stack<DrawableShape>(collection);
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    while (tempCollection.Count > 0)
                        formatter.Serialize(stream, tempCollection.Pop());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}");
            }
        }
        public static void LoadCollection(Stack<DrawableShape> collection, string fileName)
        {
            collection.Clear();
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    while (stream.Position < stream.Length)
                    {
                        collection.Push((DrawableShape)formatter.Deserialize(stream));
                        collection.Peek().ValidateView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла: {ex.Message}");
            }
        }
    }
}
