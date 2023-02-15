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
        static string Path = "Справочник.txt";
        static Worker myWorker = new Worker(Path);
        ObservableCollection<Client> ClientsList = new ObservableCollection<Client>();
        static string postSelected = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            postSelector.ItemsSource = new string[] { "Консультант", "Менеджер" };
        }
        //инициализация сотрудника
        static private Worker Init()
        {
            Worker SelectedWorker = new Worker(Path);

            if (postSelected == "Консультант")
                SelectedWorker = new Consultant(Path);
            else if (postSelected == "Менеджер")
                SelectedWorker = new Manager(Path);
            return SelectedWorker;
        }
        //вывод информации о клиентах
        private void getInfo_Click(object sender, RoutedEventArgs e)
        {
            string result = myWorker.Load();
            ClientsList = myWorker.getClientsList();
            lstClients.ItemsSource = ClientsList;
            resultOfGettingData.Text = result;
        }
        //отображение о том, кто сейчас работает
        private void postChanged(object sender, SelectionChangedEventArgs e)
        {
            postSelected = postSelector.SelectedValue.ToString();
            myWorker = Init();
        }
        //изменение данных о клиенте
        private void changeInfo_Click(object sender, RoutedEventArgs e)
        {
            string Result = myWorker.changeClientsList(surnameOld.Text,
                                                       surnameNew.Text,
                                                       nameToChange.Text,
                                                       patronymicToChange.Text,
                                                       long.Parse(phonenumberToChange.Text),
                                                       rangepassportToChange.Text,
                                                       numberpassportToChange.Text,
                                                       postSelected);
            ClientsList = myWorker.getClientsList();
            lstClients.ItemsSource = ClientsList;
            resultOfChange.Text = Result;
        }
        //сортировка коллекции клиентов. Файл с данными о клиентах не меняется
        private void sortBySurname_Click(object sender, RoutedEventArgs e)
        {
            ClientsList = myWorker.sortClientsList();
            lstClients.ItemsSource = ClientsList;
        }
        //добавление данных о клиенте
        private void addInfo_Click(object sender, RoutedEventArgs e)
        {
            string Result = myWorker.putClient(surname.Text,
                                               name.Text,
                                               patronymic.Text,
                                               long.Parse(phoneNumber.Text),
                                               rangePassport.Text,
                                               numberPassport.Text);
            ClientsList = myWorker.getClientsList();
            lstClients.ItemsSource = ClientsList;
            resultOfPut.Text = Result;
        }
    }
}
