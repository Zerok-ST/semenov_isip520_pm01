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

namespace WpfApp1.page
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class auth : Page
    {
        public auth()
        {
            InitializeComponent();
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (Txb.Text == "Enter text here...")
            {
                Txb.Text = "";
            }
        }
        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txb.Text))
                Txb.Text = "Enter text here...";
        }
        private void Frame_Navigated(object sender, NavigationEventArgs e)

        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new Entities3())
            {
                switch (CmbRole.SelectedIndex)
                {
                    case 0:
                        var user = db.organ
                        .AsNoTracking()
                        .FirstOrDefault(u => u.Логин == Txb.Text && u.Пароль.ToString() == PBox.Password);

                        if (user == null)
                        {
                            MessageBox.Show("Организатор с таким данными не найден!");
                            return;
                        }
                        if (user != null)
                        {
                            MessageBox.Show("Организатор найден!");
                            NavigationService?.Navigate(new org());
                        }
                        break;
                    case 1:
                        var user2 = db.participant
                        .AsNoTracking()
                        .FirstOrDefault(u => u.Логин == Txb.Text && u.Пароль.ToString() == PBox.Password);

                        if (user2 == null)
                        {
                            MessageBox.Show("Участник с такими данными не найден!");
                            return;
                        }
                        if (user2 != null)
                        {
                            MessageBox.Show("Студент найден!");
                            NavigationService?.Navigate(new partProf());
                        }

                        break;
                    case 2:
                        var user3 = db.moder
                        .AsNoTracking()
                        .FirstOrDefault(u => u.Логин == Txb.Text && u.Пароль.ToString() == PBox.Password);

                        if (user3 == null)
                        {
                            MessageBox.Show("Модератор с такими данными не найден!");
                            return;
                        }
                        if (user3 != null)
                        {
                            MessageBox.Show("Модератор найден!");
                            NavigationService?.Navigate(new moderProf());
                        }

                        break;
                    case 3:
                        var user4 = db.juri
                        .AsNoTracking()
                        .FirstOrDefault(u => u.Логин == Txb.Text && u.Пароль.ToString() == PBox.Password);

                        if (user4 == null)
                        {
                            MessageBox.Show("Жюри с такими данными не найден!");
                            return;
                        }
                        if (user4 != null)
                        {
                            MessageBox.Show("Жюри найден!");
                            NavigationService?.Navigate(new juryProf());
                        }

                        break;
                }

            }
        }

        private void Txb_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtHintLogin.Visibility = Visibility.Visible;

            if (Txb.Text.Length > 0)

            {

                txtHintLogin.Visibility = Visibility.Hidden;

            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtHintPassword.Visibility = Visibility.Visible;
            if (PBox.Password.ToString().Length > 0)

            {

                txtHintPassword.Visibility = Visibility.Hidden;

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new regPage());
        }
    }
}