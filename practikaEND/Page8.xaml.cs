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
    /// Логика взаимодействия для Page8.xaml
    /// </summary>
    public partial class Page8 : Page
    {
        graphic_adapterTableAdapter graphic_adapter = new graphic_adapterTableAdapter();
        goodsTableAdapter goods = new goodsTableAdapter();
        public Page8()
        {
            InitializeComponent();
            GADTG.ItemsSource = graphic_adapter.GetData();
            Goods.ItemsSource = goods.GetData();
            Goods.DisplayMemberPath = "name";
            Goods.SelectedValuePath = "Id";

        }
        private void GADTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GADTG.SelectedItem != null)
            {
                var item = GADTG.SelectedItem as DataRowView;
                Goods.SelectedValue = (int)item.Row[0];
                Name.Text = (string)item.Row[1];

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (Goods.Text != ""))
            {
                int id = (int)Goods.SelectedValue;
                graphic_adapter.InsertQuery(id, Name.Text);
                GADTG.ItemsSource = graphic_adapter.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (Goods.Text != ""))
            {
                int id = (int)(GADTG.SelectedItem as DataRowView).Row[0];
                graphic_adapter.DeleteQuery(id);
                GADTG.ItemsSource = goods.GetData();
            }

            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }

}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") || (Goods.Text != ""))
            {
                if (GADTG.SelectedItem != null)
                {
                    var item = GADTG.SelectedItem as DataRowView;
                    graphic_adapter.UpdateQuery((int)Goods.SelectedValue, Name.Text, (int)item.Row[0]);
                    GADTG.ItemsSource = graphic_adapter.GetData();

                }
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }
    }
}