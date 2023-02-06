using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _10._6_HomeWork_WPFapp_clients_base
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Client> ClientsList = new ObservableCollection<Client>();

        public MainWindow()
        {
            InitializeComponent();
            postSelector.ItemsSource = new string[] { "Консультант", "Менеджер" };
        }

        static private Consultant init()
        {
            string Path = "Справочник.txt";
            Consultant cons = new Consultant(Path);
            return cons;
        }

        private void getInfo_Click(object sender, RoutedEventArgs e)
        {
            Consultant myConsultant = init();
            myConsultant.Load();
            ClientsList = myConsultant.getClientsList();
            lstClients.ItemsSource = ClientsList;
        }




        private void postChanged(object sender, SelectionChangedEventArgs e)
        {
            //string selectedItem = postSelector.SelectedValue.ToString();
            //postInWork.Text = selectedItem;
        }

        private void addInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void changeInfo_Click(object sender, RoutedEventArgs e)
        {
            //string check = postSelector.SelectedValue.ToString();
            //string check = ((ComboBoxItem)postSelector.SelectedItem).Content.ToString();

            //if (check == "Консультант")
            //{
            //    Consultant myConsultant = init();

            //    string Result = myConsultant.changeClientsPhoneNumberBySurname(surnameToChange.Text, long.Parse(phonenumberToChange.Text));

            //    myConsultant.Load();

            //    ObservableCollection<Client> ClientsList = myConsultant.getClientsList();

            //    clientsView.ItemsSource = ClientsList;
            //    resultOfChange.Text = Result;
            //}
            //else
            //{
            //    resultOfChange.Text = "В доступе отказано";
            //}
        }


    }
}
