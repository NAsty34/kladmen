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

namespace kladmen
{
    /// <summary>
    /// Логика взаимодействия для Sklad.xaml
    /// </summary>
    public partial class Sklad_show : Window
    {
        public Sklad_show()
        {
            InitializeComponent();
            list_sklad.ItemsSource = Entities.Mod().Sklad.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Main().Show();
            Close();
        }
    }
}
