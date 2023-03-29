using practikaEND._laba5_1DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        goodsTableAdapter goods = new goodsTableAdapter();
        checkTableAdapter check = new checkTableAdapter();
        check_infoTableAdapter check_Info = new check_infoTableAdapter();

        public Page2()
        {
            InitializeComponent();
            CheckDTG.ItemsSource = check.GetData();
            Goods.ItemsSource = goods.GetData();
            Goods.DisplayMemberPath = "name";
            Goods.SelectedValuePath = "Id";
            info.ItemsSource = check_Info.GetData();
            info.DisplayMemberPath = "Data";
            info.SelectedValuePath= "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page4();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page11();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((Goods.Text != "") || (info.Text != ""))
            {
                

                check.InsertQuery((int)Goods.SelectedValue, (int)info.SelectedValue);
                CheckDTG.ItemsSource = check.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if ((Goods.Text != "") || (info.Text != ""))
            {
                int id = (int)(CheckDTG.SelectedItem as DataRowView).Row[0];
                check.DeleteQuery(id);
                CheckDTG.ItemsSource = goods.GetData();
                CheckDTG.ItemsSource = check_Info.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if ((Goods.Text != "") || (info.Text != ""))
            {

                if (CheckDTG.SelectedItem != null)
                {
                    var item = CheckDTG.SelectedItem as DataRowView;
                    check.UpdateQuery((int)Goods.SelectedValue, (int)info.SelectedValue, (int)item.Row[0]);
                    CheckDTG.ItemsSource = check.GetData();

                }
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }

        }

        private void CheckDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckDTG.SelectedItem != null)
            {
                var item = CheckDTG.SelectedItem as DataRowView;
                Goods.SelectedValue = (int)item.Row[1];
                info.SelectedValue = (int)item.Row[2];

            }

        }
    }
}
