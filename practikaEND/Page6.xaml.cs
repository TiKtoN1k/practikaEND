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
using practikaEND._laba5_1DataSet1TableAdapters;

namespace practikaEND
{
    /// <summary>
    /// Логика взаимодействия для Page6.xaml
    /// </summary>
    public partial class Page6 : Page

    {
        RAMTableAdapter RAM = new RAMTableAdapter();
        goodsTableAdapter goods = new goodsTableAdapter();
        public Page6()
        {
            InitializeComponent();
            RAMDTG.ItemsSource = RAM.GetData();
            Goods.ItemsSource = goods.GetData();
            Goods.DisplayMemberPath = "name";
            Goods.SelectedValuePath = "Id";

        }
        private void RAMDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RAMDTG.SelectedItem != null)
            {
                var item = RAMDTG.SelectedItem as DataRowView;
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
                RAM.InsertQuery(id, Name.Text, Type.Text);
                RAMDTG.ItemsSource = RAM.GetData();
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
                int id = (int)(RAMDTG.SelectedItem as DataRowView).Row[0];
                RAM.DeleteQuery(id);
                RAMDTG.ItemsSource = goods.GetData();
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
                if (RAMDTG.SelectedItem != null)
                {
                    var item = RAMDTG.SelectedItem as DataRowView;
                    RAM.UpdateQuery((int)Goods.SelectedValue, Name.Text, Type.Text, (int)item.Row[0]);
                    RAMDTG.ItemsSource = RAM.GetData();

                }
            
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }
    }
}
