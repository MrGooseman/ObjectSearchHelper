using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ObjectsSearchHelper
{
    /// <summary>
    /// Логика взаимодействия для LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        public LoadWindow()
        {
            InitializeComponent();
            Loading_Timer();
            RGBchanger();
        }
        async private void Loading_Timer() 
        {
            await Task.Run(() => timer());
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }
        private void timer()
        {
            Thread.Sleep(10000);
        }
        async private void RGBchanger()
        {
            await Task.Run(() => changer());
        }
        private void changer()
        {
            byte r;
            for (r = 0; r <= 255; r++)
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    MainGrid.Background = new SolidColorBrush(Color.FromRgb(r, r, r));
                }));
                Thread.Sleep(10);
                if (r == 255) break;
            }
        }
    }
}
