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
    /// Логика взаимодействия для Stroy.xaml
    /// </summary>
    public partial class Stroy : Window
    {
        public Stroy()
        {
            InitializeComponent();
            list_stroy.ItemsSource = Entities.Mod().stroymat.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Main().Show();
            Close();
        }
    }
}
