using ObjectsSearchHelper.DataBase;
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
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        ListClass listClass = new ListClass();
        public ListPage()
        {
            InitializeComponent();
            listClass = new ListClass();
            ListOfData.ItemsSource = listClass.datas.ToList();
        }

        private void ListOfData_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ListBoxViewModel.selectedItem != null)
            {
                ListClass.selectedAdvert = ListBoxViewModel.selectedItem;
                FrameClass.MainFrame.Navigate(new ObjPage());
            }
        }

        private void ListOfData_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FrameClass.MainFrame.Refresh();
        }
    }
}
