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
using System.Data.SqlClient;

namespace PR5
{
    public class Manager
    {
        public static Frame MainFrame { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DGridClass.ItemsSource = PR5_BaseEntities.Get_context().@class.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage addEditPage = new AddEditPage(null);
            addEditPage.Show();
            this.Close();
            //Manager.MainFrame.Navigate(new AddEditPage());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (DGridClass.SelectedItems.Count > 0)
            {
                for (int i = 0; i < DGridClass.SelectedItems.Count; i++)
                {
                    @class phone = DGridClass.SelectedItems[i] as @class;
                    if (phone != null)
                    {
                        PR5_BaseEntities.Get_context().@class.Remove(phone);
                    }
                }
            }
            PR5_BaseEntities.Get_context().SaveChanges();
            PR5_BaseEntities.Get_context().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridClass.ItemsSource = PR5_BaseEntities.Get_context().@class.ToList();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                PR5_BaseEntities.Get_context().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridClass.ItemsSource = PR5_BaseEntities.Get_context().@class.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage addEditPage = new AddEditPage((sender as Button).DataContext as @class);
            addEditPage.Show();
            this.Close();
        }
    }
}
