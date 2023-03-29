using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using practikaEND._laba5_1DataSet1TableAdapters;

namespace practikaEND
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        goodsTableAdapter goods = new goodsTableAdapter();

        public Page4()
        {
            InitializeComponent();
            GoodsDTG.ItemsSource = goods.GetData();
        }
        private void GoodsDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GoodsDTG.SelectedItem != null)
            {
                var item = GoodsDTG.SelectedItem as DataRowView;
                Price.Text = Convert.ToInt16(item.Row[1]).ToString();
                Name.Text = (string)item.Row[2];
               

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page5();

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page6();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page7();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page8();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page9();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page10();

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            double num;
            if (double.TryParse(Price.Text, out num))
            {
                if (Convert.ToInt32(Price.Text) < 0)
                {
                    MessageBox.Show("Цена не может быть отрицательной");
                }
                else
                {
                    goods.InsertQuery(Convert.ToInt16(Price.Text), Name.Text);
                    GoodsDTG.ItemsSource = goods.GetData();
                }
            }
            else if ((Name.Text == "") || (Price.Text == ""))
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
            else if (double.TryParse(Name.Text, out num))
            {
                MessageBox.Show("В названии должны быть только буквы");
            }
            else
            {
                MessageBox.Show("В цене должны присутствовать только цифры");
            }
        }


        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            double num;
            if (double.TryParse(Price.Text, out num))
            {
                if (Convert.ToInt32(Price.Text) < 0)
                {
                    MessageBox.Show("Цена не может быть отрицательной");
                }
                else
                {
                    int id = (int)(GoodsDTG.SelectedItem as DataRowView).Row[0];
                    goods.DeleteQuery(id);
                    GoodsDTG.ItemsSource = goods.GetData();
                }
            }
            else if ((Name.Text == "") || (Price.Text == ""))
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
            else if (double.TryParse(Name.Text, out num))
            {
                MessageBox.Show("В названии должны быть только буквы");
            }
            else
            {
                MessageBox.Show("В цене должны присутствовать только цифры");
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            double num;
            if (double.TryParse(Price.Text, out num))
            {

                if (Convert.ToInt32(Price.Text) < 0)
                {
                    MessageBox.Show("Цена не может быть отрицательной");
                }
                else
                {
                    if (GoodsDTG.SelectedItem != null)
                    {
                        var item = GoodsDTG.SelectedItem as DataRowView;
                        goods.UpdateQuery(Convert.ToInt16(Price.Text), Name.Text, (int)item.Row[0]);
                        GoodsDTG.ItemsSource = goods.GetData();
                    }
                }
            }
            else if ((Name.Text == "") || (Price.Text == ""))
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
            else if (double.TryParse(Name.Text, out num))
            {
                MessageBox.Show("В названии должны быть только буквы");
            }
            else
            {
                MessageBox.Show("В цене должны присутствовать только цифры");
            }
        }
    }
}
