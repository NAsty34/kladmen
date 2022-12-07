using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для Add_edir.xaml
    /// </summary>
    public partial class Add_edir : Window
    {
        private stroymat st;
        private Sklad ss;
        public Add_edir()
        {
            InitializeComponent();
                        
        }
        public void init(stroymat st)
        {
            stroymaterials.Visibility = Visibility.Visible;
            h1.Text = "Редактирование стройматериалов";
            this.st = st;
            s_nazvan.Text = st.Name;
            s_pole2.Text = st.Ed_izm;
            s_pole3.Text = st.Ostatok.ToString();
            s_pole4.Text = st.ID_Sklad.ToString();
        }

        public void init(Sklad ss)
        {
            garage.Visibility = Visibility.Visible;
            h1.Text = "Редактирование склада";
            this.ss = ss;
            s_nazvan.IsEnabled = false;
            s_nazvan.Text = ss.ID.ToString();
            s_pole2.Text = ss.Adress;
            s_pole3.Text = ss.Dastansion.ToString();
            s_pole4.Text = ss.Type_mat.ToString();
        }

        public void add_ss_init()
        {
            garage.Visibility = Visibility.Visible;
            h1.Text = "Добавление склада";
            s_nazvan.IsEnabled = false;
        }

        public void add_st_init()
        {
            stroymaterials.Visibility = Visibility.Visible;
            h1.Text = "Добавление стройматериалов";
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(garage.Visibility == Visibility.Visible)
            {
                
                if (ss == null) ss = new Sklad();
               
                ss.Adress = s_pole2.Text;
                ss.Dastansion = double.Parse(s_pole3.Text);
                ss.Type_mat = int.Parse(s_pole4.Text);

                if (ss.ID < 1)
                {
                    Entities.Mod().Sklad.Add(ss);
                    MessageBox.Show("Добавлено");

                }
                else
                {
                    MessageBox.Show("Отредактировано");

                }
            }
            else
            {
                if (st == null) st = new stroymat();
                st.Name = s_nazvan.Text;
                st.Ed_izm = s_pole2.Text;
                st.Ostatok = double.Parse(s_pole3.Text);
                st.ID_Sklad = int.Parse(s_pole4.Text);

                if (st.ID < 1)
                {
                    Entities.Mod().stroymat.Add(st);
                    MessageBox.Show("Добавлено");

                }
                else
                {
                    MessageBox.Show("Отредактировано");

                }

            }
            Entities.Mod().SaveChanges();
            

            Close();
        }

    }
}
