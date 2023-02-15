using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._6_HomeWork_WPFapp_clients_base
{
    class FileOperator
    {
        protected static string path;
        public ObservableCollection<Client> ClientsBase = new ObservableCollection<Client>();

        #region Конструктор
        public FileOperator(string Path)
        {
            path = Path;
        }
        #endregion

        /// <summary>
        /// Метод возвращает полную информацию о клиентах
        /// </summary>
        /// <returns></returns>
        public void Load()
        {
            ClientsBase.Clear();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    ClientsBase.Add(new Client(args[0], args[1], args[2], long.Parse(args[3]), args[4], args[5], args[6], args[7], args[8]));
                }
            }
        }

        /// <summary>
        /// Метод возвращает информацию о клиентах со скрытыми данными о паспорте
        /// </summary>
        /// <returns></returns>
        public void LoadHiddenPassport()
        {
            ClientsBase.Clear();
            using (StreamReader sr = new StreamReader(path))
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

                    ClientsBase.Add(new Client
                    {
                        Surname = args[0],
                        Name = args[1],
                        Patronymic = args[2],
                        PhoneNumber = long.Parse(args[3]),
                        RangePassport = rangePassportHidden,
                        NumberPassport = numberPassportHidden,
                        DateAndTime = args[6],
                        WhatChanged = args[7],
                        WhoChanged = args[8]
                    });
                }
            }
        }

        /// <summary>
        /// Метод изменяет номер телефона по фамилии клиента
        /// </summary>
        /// <param name="SurnameToChangePhoneNumber"></param>
        /// <param name="PhoneNumberToChange"></param>
        /// <returns></returns>
        public string changeClientsPhoneNumber(string SurnameToChangePhoneNumber, long PhoneNumberToChange, string Post)
        {
            int i = 0;
            bool surnameNotFound = true;
            string result = string.Empty;
            ClientsBase.Clear();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    if (args[0] != SurnameToChangePhoneNumber)
                    {
                        ClientsBase.Add(new Client
                        {
                            Surname = args[0],
                            Name = args[1],
                            Patronymic = args[2],
                            PhoneNumber = long.Parse(args[3]),
                            RangePassport = args[4],
                            NumberPassport = args[5],
                            DateAndTime = args[6],
                            WhatChanged = args[7],
                            WhoChanged = args[8]
                        });
                    }
                    else
                    {
                        string nowDate = DateTime.Now.ToShortDateString();
                        string nowTime = DateTime.Now.ToShortTimeString();
                        string dateAndTime = $"{nowDate} {nowTime}";
                        ClientsBase.Add(new Client
                        {
                            Surname = args[0],
                            Name = args[1],
                            Patronymic = args[2],
                            PhoneNumber = PhoneNumberToChange,
                            RangePassport = args[4],
                            NumberPassport = args[5],
                            DateAndTime = dateAndTime,
                            WhatChanged = "/н.тел.",
                            WhoChanged = Post
                        });
                        surnameNotFound = false;
                        result = "Данные изменены";
                    }
                    i++;
                }
                if (surnameNotFound)
                {
                    result = $"Клиента с фамилией {SurnameToChangePhoneNumber} нет в Базе";
                }
            }
            File.Delete(path);
            File.Create(path).Close();
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
            {
                for (int j = 0; j < i; j++)
                {
                    string lineClient = string.Empty;
                    lineClient = $"{ClientsBase[j].Surname}#" +
                                 $"{ClientsBase[j].Name}#" +
                                 $"{ClientsBase[j].Patronymic}#" +
                                 $"{ClientsBase[j].PhoneNumber}#" +
                                 $"{ClientsBase[j].RangePassport}#" +
                                 $"{ClientsBase[j].NumberPassport}#" +
                                 $"{ClientsBase[j].DateAndTime}#" +
                                 $"{ClientsBase[j].WhatChanged}#" +
                                 $"{ClientsBase[j].WhoChanged}";
                    sw.WriteLine(lineClient);
                }
            }
            return result;
        }

        /// <summary>
        /// Метод изменяет все данные по фамилии клиента
        /// </summary>
        /// <param name="Surname"></param>
        /// <param name="Name"></param>
        /// <param name="Patronymic"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="RangePassport"></param>
        /// <param name="NumberPassport"></param>
        /// <param name="Post"></param>
        /// <returns></returns>
        public string changeClientsAllData(string SurnameOld, string SurnameNew, string Name, string Patronymic, long PhoneNumber, string RangePassport, string NumberPassport, string Post)
        {
            int i = 0;
            bool surnameNotFound = true;
            string result = string.Empty;
            ClientsBase.Clear();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    if (args[0] != SurnameOld)
                    {
                        ClientsBase.Add(new Client
                        {
                            Surname = args[0],
                            Name = args[1],
                            Patronymic = args[2],
                            PhoneNumber = long.Parse(args[3]),
                            RangePassport = args[4],
                            NumberPassport = args[5],
                            DateAndTime = args[6],
                            WhatChanged = "ничего",
                            WhoChanged = args[8]
                        });
                    }
                    else
                    {
                        bool somthingChanged = true;
                        string whatChanged = string.Empty;
                        if (args[0] != SurnameNew)
                        {
                            whatChanged += "/фам.";
                            somthingChanged = false;
                        }
                        if (args[1] != Name)
                        {
                            whatChanged += "/им.";
                            somthingChanged = false;
                        }
                        if (args[2] != Patronymic)
                        {
                            whatChanged += "/отч.";
                            somthingChanged = false;
                        }
                        if (long.Parse(args[3]) != PhoneNumber)
                        {
                            whatChanged += "/н.тел.";
                            somthingChanged = false;
                        }
                        if (args[4] != RangePassport)
                        {
                            whatChanged += "/сер.пасп.";
                            somthingChanged = false;
                        }
                        if (args[5] != NumberPassport)
                        {
                            whatChanged += "/н.пасп.";
                            somthingChanged = false;
                        }
                        if (somthingChanged)
                        {
                            whatChanged = "ничего";
                        }
                        string nowDate = DateTime.Now.ToShortDateString();
                        string nowTime = DateTime.Now.ToShortTimeString();
                        string dateAndTime = $"{nowDate} {nowTime}";
                        ClientsBase.Add(new Client
                        {
                            Surname = SurnameNew,
                            Name = Name,
                            Patronymic = Patronymic,
                            PhoneNumber = PhoneNumber,
                            RangePassport = RangePassport,
                            NumberPassport = NumberPassport,
                            DateAndTime = dateAndTime,
                            WhatChanged = whatChanged,
                            WhoChanged = Post
                        });
                        surnameNotFound = false;
                        result = "Данные изменены";
                    }
                    i++;
                }
                if (surnameNotFound)
                {
                    result = $"Клиента с фамилией {SurnameOld} нет в Базе";
                }
            }
            File.Delete(path);
            File.Create(path).Close();
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
            {
                for (int j = 0; j < i; j++)
                {
                    string lineClient = string.Empty;
                    lineClient = $"{ClientsBase[j].Surname}#" +
                                 $"{ClientsBase[j].Name}#" +
                                 $"{ClientsBase[j].Patronymic}#" +
                                 $"{ClientsBase[j].PhoneNumber}#" +
                                 $"{ClientsBase[j].RangePassport}#" +
                                 $"{ClientsBase[j].NumberPassport}#" +
                                 $"{ClientsBase[j].DateAndTime}#" +
                                 $"{ClientsBase[j].WhatChanged}#" +
                                 $"{ClientsBase[j].WhoChanged}";
                    sw.WriteLine(lineClient);
                }
            }
            return result;
        }

        /// <summary>
        /// Метод добавления данных о клиенте
        /// </summary>
        /// <param name="Surname"></param>
        /// <param name="Name"></param>
        /// <param name="Patronymic"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="RangePassport"></param>
        /// <param name="NumberPassport"></param>
        /// <returns></returns>
        public string putClient(string Surname, string Name, string Patronymic, long PhoneNumber, string RangePassport, string NumberPassport)
        {
            string result = "Данные не внесены";
            using (StreamWriter put = new StreamWriter(path, true, Encoding.UTF8))
            {
                string line = string.Empty;
                string nowDate = DateTime.Now.ToShortDateString();
                string nowTime = DateTime.Now.ToShortTimeString();
                string dateAndTime = $"{nowDate} {nowTime}";

                line = $"{Surname}#" +
                       $"{Name}#" +
                       $"{Patronymic}#" +
                       $"{PhoneNumber}#" +
                       $"{RangePassport}#" +
                       $"{NumberPassport}#" +
                       $"{dateAndTime}#" +
                       "ничего#" +
                       $"Менеджер";
                put.WriteLine(line);
                result = string.Empty;
                result = "Данные внесены";
            }
            return result;
        }

        /// <summary>
        ///  Метод сортировки клиентов
        /// </summary>
        /// <param name="ClientsListToSort"></param>
        /// <returns></returns>
        public ObservableCollection<Client> sortClientsList(ObservableCollection<Client> ClientsListToSort)
        {
            ObservableCollection<Client> temp;
            temp = new ObservableCollection<Client>(ClientsListToSort.OrderBy(p => p));
            ClientsListToSort.Clear();
            foreach (Client j in temp) ClientsListToSort.Add(j);
            return ClientsListToSort;
        }
    }


}
