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
using practikaEND._laba5_1DataSet1TableAdapters;

namespace practikaEND
{
    /// <summary>
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        mother_boardTableAdapter mother = new mother_boardTableAdapter();
        goodsTableAdapter goods = new goodsTableAdapter();
        public Page5()
        {
            InitializeComponent();
            MotherBDTG.ItemsSource = mother.GetData();
            Goods.ItemsSource = goods.GetData();
            Goods.DisplayMemberPath = "name";
            Goods.SelectedValuePath = "Id";
            
        }
        private void MotherBDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MotherBDTG.SelectedItem != null)
            {
                var item = MotherBDTG.SelectedItem as DataRowView;
                Goods.SelectedValue = (int)item.Row[0];
                Name.Text  = (string)item.Row[1];
                Socet.Text = (string)item.Row[2];

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (Socet.Text != "") || (Goods.Text != "")) 
            {
                int id = (int)Goods.SelectedValue;
                mother.InsertQuery(id, Name.Text, Socet.Text);
                MotherBDTG.ItemsSource = mother.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (Socet.Text != "") || (Goods.Text != ""))
            {
                int id = (int)(MotherBDTG.SelectedItem as DataRowView).Row[0];
                mother.DeleteQuery(id);
                MotherBDTG.ItemsSource = goods.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (Socet.Text != "") || (Goods.Text != ""))
            {
                if (MotherBDTG.SelectedItem != null)
                {
                    var item = MotherBDTG.SelectedItem as DataRowView;
                    mother.UpdateQuery((int)Goods.SelectedValue, Name.Text, Socet.Text, (int)item.Row[0]);
                    MotherBDTG.ItemsSource = mother.GetData();

                }
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }
    }
}
