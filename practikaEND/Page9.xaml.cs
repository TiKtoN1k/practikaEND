using practikaEND._laba5_1DataSet1TableAdapters;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practikaEND
{
    /// <summary>
    /// Логика взаимодействия для Page9.xaml
    /// </summary>
    public partial class Page9 : Page
    {
        cooling_systemTableAdapter CS = new cooling_systemTableAdapter();
        goodsTableAdapter goods = new goodsTableAdapter();
        public Page9()
        {
            InitializeComponent();
            CSDTG.ItemsSource = CS.GetData();
            Goods.ItemsSource = goods.GetData();
            Goods.DisplayMemberPath = "name";
            Goods.SelectedValuePath = "Id";

        }
        private void CSDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CSDTG.SelectedItem != null)
            {
                var item = CSDTG.SelectedItem as DataRowView;
                Goods.SelectedValue = (int)item.Row[0];
                Name.Text = (string)item.Row[1];
                Type.Text = (string)item.Row[2];

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (Type.Text != "") || (Goods.Text != ""))
            {
                int id = (int)Goods.SelectedValue;
                CS.InsertQuery(id, Name.Text, Type.Text);
                CSDTG.ItemsSource = CS.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (Type.Text != "") || (Goods.Text != ""))
            {
                int id = (int)(CSDTG.SelectedItem as DataRowView).Row[0];
                CS.DeleteQuery(id);
                CSDTG.ItemsSource = goods.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (Type.Text != "") || (Goods.Text != ""))
            {
                if (CSDTG.SelectedItem != null)
                {
                    var item = CSDTG.SelectedItem as DataRowView;
                    CS.UpdateQuery((int)Goods.SelectedValue, Name.Text, Type.Text, (int)item.Row[0]);
                    CSDTG.ItemsSource = CS.GetData();


                }
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }
    }
}