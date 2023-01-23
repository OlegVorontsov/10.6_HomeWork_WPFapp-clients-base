using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._6_HomeWork_WPFapp_clients_base
{
    class Consultant
    {
        ObservableCollection<Client> ClientsList = new ObservableCollection<Client>();

        private string path;

        #region Коструктор
        /// <summary>
        /// Создание репозитория
        /// </summary>
        /// <param name="Path"></param>
        public Consultant(string Path)
        {
            this.path = Path;
        }
        #endregion

        #region Методы
        /// <summary>
        /// Загрузка данных о клиентах из файла Справочник в коллекцию
        /// </summary>
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    string rangePassportHidden = string.Empty;
                    string numberPassportHidden = string.Empty;

                    foreach (var item in args[4])
                    {
                        rangePassportHidden += "*";
                    }
                    foreach (var item in args[5])
                    {
                        numberPassportHidden += "*";
                    }

                    ClientsList.Add(new Client
                    {
                        Surname = args[0],
                        Name = args[1],
                        Patronymic = args[2],
                        PhoneNumber = long.Parse(args[3]),
                        RangePassport = rangePassportHidden,
                        NumberPassport = numberPassportHidden
                    });
                }
            }
        }

        /// <summary>
        /// Метод возвращает коллекцию Клиентов
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Client> getClientsList()
        {
            return ClientsList;
        }

        /// <summary>
        /// Метод изменяет номер телефона по фамилии клиента
        /// </summary>
        /// <param name="SurnameToChangePhoneNumber"></param>
        /// <param name="PhoneNumberToChange"></param>
        public string changeClientsPhoneNumberBySurname(string SurnameToChangePhoneNumber, long PhoneNumberToChange)
        {
            int i = 0;
            bool surnameNotFound = true;
            string result = string.Empty;

            using (StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    if (args[0] != SurnameToChangePhoneNumber)
                    {
                        ClientsList.Add(new Client
                        {
                            Surname = args[0],
                            Name = args[1],
                            Patronymic = args[2],
                            PhoneNumber = long.Parse(args[3]),
                            RangePassport = args[4],
                            NumberPassport = args[5]
                        });
                    }
                    else
                    {
                        ClientsList.Add(new Client
                        {
                            Surname = args[0],
                            Name = args[1],
                            Patronymic = args[2],
                            PhoneNumber = PhoneNumberToChange,
                            RangePassport = args[4],
                            NumberPassport = args[5]
                        });
                        surnameNotFound = false;
                        result = "Данные изменены";
                    }
                    i++;
                }
                if (surnameNotFound)
                {
                    result = $"Клиента с фамилией {SurnameToChangePhoneNumber} нет в Справочнике";
                }
            }
            File.Delete(this.path);
            File.Create(this.path).Close();
            using (StreamWriter sw = new StreamWriter(this.path, true, Encoding.UTF8))
            {
                for (int j = 0; j < i; j++)
                {
                    string lineClient = string.Empty;
                    lineClient = $"{this.ClientsList[j].Surname}#" +
                                 $"{this.ClientsList[j].Name}#" +
                                 $"{this.ClientsList[j].Patronymic}#" +
                                 $"{this.ClientsList[j].PhoneNumber}#" +
                                 $"{this.ClientsList[j].RangePassport}#" +
                                 $"{this.ClientsList[j].NumberPassport}#";
                    sw.WriteLine(lineClient);
                }
            }
            return result;
        }

        #endregion
    }
}
