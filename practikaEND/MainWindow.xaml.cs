using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        personTableAdapter adapter = new personTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Login.Text != "") || (Password.Password != ""))
            {
                var allLogins = adapter.GetData().Rows;
                for (int i = 0; i < allLogins.Count; i++)
                {
                    if (allLogins[i][1].ToString() == Login.Text &&
                        allLogins[i][2].ToString() == Password.Password)
                    {
                        string roleId = (string)allLogins[i][3];
                        switch (roleId)
                        {
                            case "Администратор":
                                (Application.Current.MainWindow as MainWindow).PageFrame.Content = new Page1();
                                return;
                            case "Касса":
                                (Application.Current.MainWindow as MainWindow).PageFrame.Content = new Page12();
                                return;
                        }

                    }

                }
                MessageBox.Show("Вы ввели неправильные данные");

            }
            else
            {
                MessageBox.Show("Поле не должно быть пустым");
            }
        }
    }
}
    

