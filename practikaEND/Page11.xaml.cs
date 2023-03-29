using practikaEND._laba5_1DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace practikaEND
{
    /// <summary>
    /// Логика взаимодействия для Page11.xaml
    /// </summary>
    public partial class Page11 : Page
    {
        check_infoTableAdapter check_Info = new check_infoTableAdapter();
        public Page11()
        {
            InitializeComponent();
            Check_infoDTG.ItemsSource = check_Info.GetData();
        }
        private void Check_infoDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Check_infoDTG.SelectedItem != null)
            {
                var item = Check_infoDTG.SelectedItem as DataRowView;
                Data.Text = (string)item.Row[1];
                Finaly_price.Text = (string)item.Row[2];

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num; 
            if (double.TryParse(Finaly_price.Text, out num))
            {
                if (Convert.ToInt32(Finaly_price.Text) < 0 || Convert.ToInt32(Data.Text) < 0)
                {
                    MessageBox.Show("Цена не может быть отрицательной");
                }
                else
                {
                    check_Info.InsertQuery(Data.Text, Finaly_price.Text);
                    Check_infoDTG.ItemsSource = check_Info.GetData();
                }

            }
            else if ((Data.Text == "") || (Finaly_price.Text == ""))
            {
                MessageBox.Show("Поле не должно быть пустым");

            }
            else
            {
                MessageBox.Show("В цене должны присутствовать только цифры");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double num;
            if (double.TryParse(Finaly_price.Text, out num))
            {
                if (Convert.ToInt32(Finaly_price.Text) < 0 || Convert.ToInt32(Data.Text) < 0)
                {
                    MessageBox.Show("Цена не может быть отрицательной");
                }
                else
                {
                    int id = (int)(Check_infoDTG.SelectedItem as DataRowView).Row[0];
                    check_Info.DeleteQuery(id);
                    Check_infoDTG.ItemsSource = check_Info.GetData();
                }
            }
            else if ((Data.Text == "") || (Finaly_price.Text == ""))
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
            else
            {
                MessageBox.Show("В цене должны присутствовать только цифры");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            double num;
            if (double.TryParse(Finaly_price.Text, out num))
            {
                if (Convert.ToInt32(Finaly_price.Text) < 0 || Convert.ToInt32(Data.Text) < 0)
                {
                    MessageBox.Show("Цена не может быть отрицательной");
                }
                else
                {
                    if (Check_infoDTG.SelectedItem != null)
                    {
                        var item = Check_infoDTG.SelectedItem as DataRowView;
                        check_Info.UpdateQuery(Data.Text, Finaly_price.Text, (int)item.Row[0]);
                        Check_infoDTG.ItemsSource = check_Info.GetData();

                    }
                }
            }
            else if ((Data.Text == "") || (Finaly_price.Text == ""))
            {
                MessageBox.Show("Поле не должно быть пустым");

            }
            else
            {
                MessageBox.Show("В цене должны присутствовать только цифры");
            }
        }
    }
}
