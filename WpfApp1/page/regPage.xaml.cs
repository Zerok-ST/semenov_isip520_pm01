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
    /// Логика взаимодействия для regPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Txb_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtHintFIO.Visibility = Visibility.Visible;
            txtHintLogin.Visibility = Visibility.Visible;
            txtHintFIO.Visibility = Visibility.Visible;

            if (Txbt1.Text.Length > 0)

            {

                txtHintLogin.Visibility = Visibility.Hidden;

            }
            if (Txbt2.Text.Length > 0)

            {

                txtHintFIO.Visibility = Visibility.Hidden;

            }

        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtHintPassword.Visibility = Visibility.Visible;
            txtHintPasswordTrue.Visibility = Visibility.Visible;
            if (Psbt1.Password.ToString().Length > 0)

            {

                txtHintPassword.Visibility = Visibility.Hidden;

            }
            if (Psbt2.Password.ToString().Length > 0)

            {

                txtHintPasswordTrue.Visibility = Visibility.Hidden;

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Txbt1.Text = "";
            Txbt2.Text = "";
            Psbt1.Password = "";
            Psbt2.Password = "";
            NavigationService?.Navigate(new auth());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new Entities3())
            {
                var user = db.user
                .AsNoTracking()
                .FirstOrDefault(u => u.Логин == Txbt1.Text);

                if (user != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                    return;
                }
            }

            if (Txbt1.Text.Length == 0)
            {
                MessageBoxResult result = MessageBox.Show("Не все поля заполнены!", "Предупреждение.");
            }
            else if (Txbt2.Text.Length == 0)
            {
                MessageBoxResult result = MessageBox.Show("Не все поля заполнены!", "Предупреждение.");
            }
            else if (Psbt1.Password.ToString().Length == 0)
            {
                MessageBoxResult result = MessageBox.Show("Не все поля заполнены!", "Предупреждение.");
            }
            else if (Psbt2.Password.ToString().Length == 0)
            {
                MessageBoxResult result = MessageBox.Show("Не все поля заполнены!", "Предупреждение.");
            }
            else if (Psbt1.Password.ToString().Length < 6)
            {
                MessageBoxResult result = MessageBox.Show("Пароль должен содержать 6 или более символов", "Предупреждение.");
            }
            else if (Psbt1.Password != Psbt2.Password)
            {
                MessageBoxResult result = MessageBox.Show("Пароли не совпадают!", "Предупреждение.");
            }
            else
            {
                Entities db1 = new Entities();
                switch (CmbRole.SelectedIndex)
                {
                    case 0:
                        juri userObject = new juri
                        {

                            ФИО = Txbt2.Text,

                            Mail = txtMail.Text,

                            Логин = Txbt1.Text,

                            Пароль = Psbt1.Password,

                            Роль = 1

                        };
                        db1.juri.Add(userObject);
                        break;
                    case 1:
                        participant user = new participant
                        {

                            ФИО = Txbt2.Text,

                            Mail = txtMail.Text,

                            Логин = Txbt1.Text,

                            Пароль = Psbt1.Password,

                            Роль = 2

                        };
                        db1.participant.Add(user);
                        break;

                    case 2:
                        organ user = new organ
                        {

                            ФИО = Txbt2.Text,

                            Mail = txtMail.Text,

                            Логин = Txbt1.Text,

                            Пароль = Psbt1.Password,

                            Роль = 3

                        };
                        db1.organ.Add(user);
                        break;

                    case 3:
                        moder user = new moder
                        {

                            ФИО = Txbt2.Text,

                            Mail = txtMail.Text,

                            Логин = Txbt1.Text,

                            Пароль = Psbt1.Password,

                            Роль = 3

                        };
                        db1.moder.Add(user);
                        break;


                }
                db1.SaveChanges();

                MessageBoxResult result = MessageBox.Show("Пользователь успешно сохранён в базу!", "Оповещение.");
            }

        }
    }
}
