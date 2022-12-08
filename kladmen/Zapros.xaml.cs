using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;

namespace kladmen
{
    /// <summary>
    /// Логика взаимодействия для Zapros.xaml
    /// </summary>
    public partial class Zapros : Window
    {
        public Zapros()
        {
            InitializeComponent();
        }

        internal void init(string s)
        {
            if (s == "1")
            {

                var list_s = Entities.Mod().stroymat.Where(a => a.Sklad.Adress == "пос.Веканово").ToList();

                var L_S = Entities.Mod().Sklad.Where(a => a.Adress == "пос.Заскочиха").First();
                foreach (var a in list_s)
                {
                    a.Sklad = L_S;
                }
                zap.ItemsSource = Entities.Mod().stroymat.Select(a => new { a.Name, a.Ed_izm, a.Ostatok }).ToList();
            }
            else if (s == "2")
            {
                zap.ItemsSource = Entities.Mod().Sklad.Select(a => new { a.Adress, a.Type_mat1.Name, a.Dastansion }).ToList();
            }
            else if (s == "3")
            {
                var w = Entities.Mod().stroymat.Where(a => a.Sklad.Adress == "д.Крутово");
                zap.ItemsSource = Entities.Mod().stroymat.Select(a => new { a.Name, a.Ed_izm, a.Ostatok }).ToList();
            }
            else if (s == "4")
            {
                zap.ItemsSource = Entities.Mod().stroymat.Select(a => new { a.ID_Sklad, a.Ostatok, a.Ed_izm, a.Name }).ToList();
            }
            else if (s == "5")
            {
                zap.ItemsSource = Entities.Mod().stroymat.Select(a => new { a.ID_Sklad }).Distinct().ToList();
            }
            else if (s == "6")
            {
                var w = Entities.Mod().stroymat.Max(p => p.Ostatok);

                zap.ItemsSource = Entities.Mod().stroymat.Where(a => a.Ostatok == w).Select(a => new { a.Name, a.ID_Sklad }).ToList();
            }
            else
            {
                var w = Entities.Mod().stroymat.Where(a => a.ID_Sklad == 1);
                Entities.Mod().stroymat.RemoveRange(w);
                zap.ItemsSource = Entities.Mod().stroymat.ToList();
            }
        }






        private void Button_Click(object sender, RoutedEventArgs e)
        {


            iTextSharp.text.Document doc = new iTextSharp.text.Document();

            PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));

            doc.Open();


            BaseFont baseFont = BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            PdfPTable table = new PdfPTable(zap.Columns.Count);

            PdfPCell cell = new PdfPCell(new Phrase("table", font)); //заголовок серху таблицы

            cell.Colspan = zap.Columns.Count;
            cell.HorizontalAlignment = 1;
            cell.Border = 0;
            table.AddCell(cell);

            foreach (var c in zap.Columns)
            {
                cell = new PdfPCell(new Phrase(new Phrase(c.Header.ToString(), font)));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }

            foreach (var c in zap.Items)
            {
                foreach (var a in c.ToString().Split(','))
                {
                    cell = new PdfPCell(new Phrase(a.Split('=')[1].Split('}')[0], font));
                    table.AddCell(cell);
                }
                
            }


            doc.Add(table);

            doc.Close();

            MessageBox.Show("Pdf-документ сохранен");

        }
    }
}
