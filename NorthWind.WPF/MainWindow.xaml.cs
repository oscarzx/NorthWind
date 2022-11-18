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
using NorthWind.Entities;
using NorthWind.BLL;

namespace NorthWind.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            var helper = OperationsFactory.GetCategoryOperations();
            Category category = new Category
            {
                CategoryName = CategoryName.Text,
                Description = CategoryDescription.Text
            };
            category = helper.Create(category);
            string result;
            if(category != null)
            {
                result = $"Categoría insertada {category.CategoryID}";
                CategoryID.Text = category.CategoryID.ToString();
            }
            else
            {
                result = "No se pudo insertar la categoría";
            }
            MessageBox.Show(result);
        }

        private void Retrieve(object sender, RoutedEventArgs e)
        {
            var helper = OperationsFactory.GetCategoryOperations();
            var category = helper.RetrieveByID(int.Parse(CategoryID.Text));
            if(category != null)
            {
                CategoryName.Text = category.CategoryName;
                CategoryDescription.Text = category.Description;
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la categoría");
                CategoryName.Text = String.Empty;
                CategoryDescription.Text = String.Empty;
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            var helper = OperationsFactory.GetCategoryOperations();
            Category category = new Category
            {
                CategoryID = int.Parse(CategoryID.Text),
                CategoryName = CategoryName.Text,
                Description = CategoryDescription.Text
            };
            var UpdateResult = helper.Update(category);

            if (UpdateResult)
            {
                MessageBox.Show("Categoría Modificada");
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la categoría");
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var helper = OperationsFactory.GetCategoryOperations();
            int ID = int.Parse(CategoryID.Text);
            var deleteResult = WithLog.IsChecked.Value ? helper.DeleteWithLog(ID)
                : helper.Delete(ID);

            if (deleteResult)
            {
                MessageBox.Show("Categoría eliminada");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la categoría");
            }
        }

        private void GetCategories(object sender, RoutedEventArgs e)
        {
            var helper = OperationsFactory.GetCategoryOperations();
            Data.ItemsSource = helper.GetAll()
                .Select(c => new { c.CategoryID, c.CategoryName, c.Description });
            Data.Visibility = Visibility.Visible;
        }

        private void GetLogs(object sender, RoutedEventArgs e)
        {
            var helper = OperationsFactory.GetLogOperations();
            Data.ItemsSource = helper.GetLogs();
            Data.Visibility = Visibility.Visible;
        }
    }
}
