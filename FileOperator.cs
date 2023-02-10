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
        public string changeClientsList(string SurnameToChangePhoneNumber, long PhoneNumberToChange, string Post)
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
    }
}
