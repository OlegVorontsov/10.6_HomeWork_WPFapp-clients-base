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
            //string Path = "Справочник.txt";
            //Consultant cons = new Consultant(Path);

            clientsView.ItemsSource = ClientsList;
        }

        private void postChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = postSelector.SelectedItem.ToString();
        }

        private void addInfo_Click(object sender, RoutedEventArgs e)
        {
            ClientsList.Add(new Client
            {
                Surname = "Markov",
                Name = "Oleg",
                Patronymic = "Sergeevich",
                PhoneNumber = 79261013691,
                RangePassport = 4508,
                NumberPassport = 613675
            });
        }
    }
}
