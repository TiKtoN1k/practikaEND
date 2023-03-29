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
using practikaEND._laba5_1DataSet1TableAdapters;

namespace practikaEND
{
    /// <summary>
    /// Логика взаимодействия для Page7.xaml
    /// </summary>
    public partial class Page7 : Page
    {
        CPUTableAdapter CPU = new CPUTableAdapter();
        goodsTableAdapter goods = new goodsTableAdapter();
        public Page7()
        {
            InitializeComponent();
            CPUDTG.ItemsSource = CPU.GetData();
            Goods.ItemsSource = goods.GetData();
            Goods.DisplayMemberPath = "name";
            Goods.SelectedValuePath = "Id";

        }
        private void CPUDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CPUDTG.SelectedItem != null)
            {
                var item = CPUDTG.SelectedItem as DataRowView;
                Goods.SelectedValue = (int)item.Row[0];
                Name.Text = (string)item.Row[1];
                CheepSet.Text = (string)item.Row[2];

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (CheepSet.Text != "") || (Goods.Text != ""))
            {
                int id = (int)Goods.SelectedValue;
                CPU.InsertQuery(id, Name.Text, CheepSet.Text);
                CPUDTG.ItemsSource = CPU.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (CheepSet.Text != "") || (Goods.Text != ""))
            {
                int id = (int)(CPUDTG.SelectedItem as DataRowView).Row[0];
                CPU.DeleteQuery(id);
                CPUDTG.ItemsSource = goods.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (CheepSet.Text != "") || (Goods.Text != ""))
            {
                if (CPUDTG.SelectedItem != null)
                {
                    var item = CPUDTG.SelectedItem as DataRowView;
                    CPU.UpdateQuery((int)Goods.SelectedValue, Name.Text, CheepSet.Text, (int)item.Row[0]);
                    CPUDTG.ItemsSource = CPU.GetData();
                }
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
         }
    }
}

