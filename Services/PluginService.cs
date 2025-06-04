using OOPaint.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace OOPaint
{
    internal class PluginService
    {
        MainWindow _viewDI;
        public PluginService(MainWindow viewDI)
        {
            _viewDI = viewDI;
        }

        public void LoadPlugin(string fileName)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(fileName);
                Type pluginType = assembly.GetTypes().FirstOrDefault(type => typeof(IPlugin).IsAssignableFrom(type));
                if (pluginType != null)
                {
                    IPlugin pluginInfo = Activator.CreateInstance(pluginType) as IPlugin;

                    _viewDI.CmbBoxTool.Items.Add(pluginInfo.Name);
                    MyShapeCreatorsSingleton.GetInstance().AddCreator(pluginInfo.MyShapeCreator);
                }
                else
                {
                    MessageBox.Show($"Ошибка при подключении плагина");
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                MessageBox.Show($"Ошибка при загрузке типов: {ex.Message}\n" +
                                string.Join("\n", ex.LoaderExceptions.Select(e => e.Message)));
            }
            catch (Exception ex)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Ошибка при подключении плагина: {ex.Message}");
            }
        }
    }
}
