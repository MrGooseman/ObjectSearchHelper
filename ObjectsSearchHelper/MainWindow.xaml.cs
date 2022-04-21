using System;
using System.Collections.Generic;
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

namespace ObjectsSearchHelper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NameLabel.Content = CurrentUser.currentUser.Surname+" "+CurrentUser.currentUser.Name;
            ListClass.myAdvertOpen = false;
            FrameClass.MainFrame = MainFrame;
            FrameClass.MainFrame.Navigate(new ListPage());
        }

        private void CloseMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuStackPanel.Visibility = Visibility.Hidden;
        }

        private void OpenMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuStackPanel.Visibility = Visibility.Visible;
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuStackPanel.Visibility = Visibility.Hidden;
            ListClass.myAdvertOpen = false;
            FrameClass.MainFrame.Navigate(new ListPage());
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            MenuStackPanel.Visibility = Visibility.Hidden;
            ListClass.myAdvertOpen = false;
            FrameClass.MainFrame.Navigate(new NewAdvertPage());
        }

        private void MyAdvertButton_Click(object sender, RoutedEventArgs e)
        {
            MenuStackPanel.Visibility = Visibility.Hidden;
            ListClass.myAdvertOpen = true;
            FrameClass.MainFrame.Navigate(new ListPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GuideButton_Click(object sender, RoutedEventArgs e)
        {
            ListClass.myAdvertOpen = false;
            MenuStackPanel.Visibility = Visibility.Hidden;
            System.Diagnostics.Process.Start("GuideHelp.chm");
        }
    }
}
