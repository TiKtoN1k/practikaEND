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
    /// Логика взаимодействия для Page10.xaml
    /// </summary>
    public partial class Page10 : Page
    {
        caseTableAdapter Case = new caseTableAdapter();
        goodsTableAdapter goods = new goodsTableAdapter();
        public Page10()
        {
            InitializeComponent();
            CaseDTG.ItemsSource = Case.GetData();
            Goods.ItemsSource = goods.GetData();
            Goods.DisplayMemberPath = "name";
            Goods.SelectedValuePath = "Id";
            
        }
        private void CaseDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CaseDTG.SelectedItem != null)
            {
                var item = CaseDTG.SelectedItem as DataRowView;
                Goods.SelectedValue = (int)item.Row[0];
                Name.Text = (string)item.Row[1];
                Format.Text = (string)item.Row[2];

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Goods.Text != "") || (Name.Text != "") || (Format.Text !="")) 
            {
                    int id = (int)Goods.SelectedValue;
                    Case.InsertQuery(id, Name.Text, Format.Text);
                    CaseDTG.ItemsSource = Case.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((Goods.Text != "") || (Name.Text != "") || (Format.Text != ""))
            {
                int id = (int)(CaseDTG.SelectedItem as DataRowView).Row[0];
                Case.DeleteQuery(id);
                CaseDTG.ItemsSource = goods.GetData();
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((Goods.Text != "") || (Name.Text != "") || (Format.Text != ""))
            {
                if (CaseDTG.SelectedItem != null)
                {
                    var item = CaseDTG.SelectedItem as DataRowView;
                    Case.UpdateQuery((int)Goods.SelectedValue, Name.Text, Format.Text, (int)item.Row[0]);
                    CaseDTG.ItemsSource = Case.GetData();

                }
            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }
    }
}
