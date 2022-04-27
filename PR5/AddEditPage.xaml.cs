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
using System.Windows.Shapes;

namespace PR5
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Window
    {
        
        private @class _currentClass = new @class();
        public AddEditPage(@class selectedClass)
        {
            InitializeComponent();
            if (selectedClass != null)
                _currentClass = selectedClass;

            
            DataContext = _currentClass;
            

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentClass.name_class.ToString()))
                errors.AppendLine("Укажите ID");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            {
                PR5_BaseEntities.Get_context().@class.Add(_currentClass);


                try
                {
                    PR5_BaseEntities.Get_context().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
        }

    }
}
