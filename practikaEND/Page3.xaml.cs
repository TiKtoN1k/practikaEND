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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        personTableAdapter person = new personTableAdapter();
        public Page3()
        {
            InitializeComponent();
            PersonalDTG.ItemsSource = person.GetData();
            
        }
        private void PersonalDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PersonalDTG.SelectedItem != null)
            {
                var item = PersonalDTG.SelectedItem as DataRowView;
                Login.Text = (string)item.Row[1];
                Password.Text = (string)item.Row[2];
                Role.Text = (string)item.Row[3];

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            if ((Login.Text == "") || (Password.Text == "") || (Role.Text == ""))
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
            else if ((double.TryParse(Role.Text, out num)))
            {
                MessageBox.Show("Цифры в роль вводить нельзя");
            }
            else
            {
                person.InsertQuery(Login.Text, Password.Text, Role.Text);
                PersonalDTG.ItemsSource = person.GetData();

            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            if ((Login.Text == "") || (Password.Text == "") || (Role.Text == ""))
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
            else if ((double.TryParse(Role.Text, out num)))
            {
                MessageBox.Show("Цифры в роль вводить нельзя");
            }
            else
            {
                int id = (int)(PersonalDTG.SelectedItem as DataRowView).Row[0];
                person.DeleteQuery(id);
                PersonalDTG.ItemsSource = person.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            if ((Login.Text == "") || (Password.Text == "") || (Role.Text == ""))
            {
                MessageBox.Show("Поле не должно быть пустым");

            }
            else if ((double.TryParse(Role.Text, out num)))
            {
                MessageBox.Show("Цифры в роль вводить нельзя");
            }
            else
            {

                if (PersonalDTG.SelectedItem != null)
                {
                    var item = PersonalDTG.SelectedItem as DataRowView;
                    person.UpdateQuery(Login.Text, Password.Text, Role.Text, (int)item.Row[0]);
                    PersonalDTG.ItemsSource = person.GetData();
                }
            }
        }
    }
}
