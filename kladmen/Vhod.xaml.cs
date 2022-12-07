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

namespace kladmen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Vhod : Window
    {
        public Vhod()
        {
            InitializeComponent();
            kod.Focus();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (kod.Text == "0000")
            {
                new Main().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вы вели неправильный пароль, введите 0000");
            }
        }

        private void kod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click(null, null);
            }
        }
    }
}
