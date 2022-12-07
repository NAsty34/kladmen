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
using System.Xml.Linq;

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var R_S = ((Button)sender).DataContext as stroymat;
            var w =new Add_edir();
            w.init(R_S);
            w.ShowDialog();
            list_stroy.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var R_S = ((Button)sender).DataContext as stroymat;
            Entities.Mod().stroymat.Remove(R_S);
            Entities.Mod().SaveChanges();
            (list_stroy.ItemsSource as List<stroymat>).Remove(R_S);
            list_stroy.Items.Refresh();
            MessageBox.Show("Запись о материале удалена");
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            var w = new Add_edir();
            w.add_st_init();
            w.ShowDialog();
            list_stroy.ItemsSource = Entities.Mod().stroymat.ToList();
        }
    }
}
