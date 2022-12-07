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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var R_S = ((Button)sender).DataContext as Sklad;
            var w = new Add_edir();
            w.init(R_S);
            w.ShowDialog();
            list_sklad.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var R_S = ((Button)sender).DataContext as Sklad;
            Entities.Mod().stroymat.RemoveRange(R_S.stroymat);
            Entities.Mod().Sklad.Remove(R_S);
            Entities.Mod().SaveChanges();
            (list_sklad.ItemsSource as List<Sklad>).Remove(R_S);
            list_sklad.Items.Refresh();
            MessageBox.Show("Запись о складе удалена");
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
           
            var w = new Add_edir();
            w.add_ss_init();
            w.ShowDialog();
            list_sklad.ItemsSource = Entities.Mod().Sklad.ToList();
        }
    }
}
