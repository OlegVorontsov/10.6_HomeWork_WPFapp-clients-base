using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._6_HomeWork_WPFapp_clients_base
{
    class Consultant : Worker
    {
        #region Коструктор
        /// <summary>
        /// Создание экземпляра Консультанта
        /// </summary>
        /// <param name="Path"></param>
        public Consultant(string Path) : base(Path)
        {
        }
        #endregion

        #region Методы
        /// <summary>
        /// Загрузка данных о клиентах из файла Справочник в коллекцию
        /// </summary>
        public override void Load()
        {
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

                    ClientsList.Add(new Client
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
        public override string changeClientsList(string SurnameToChangePhoneNumber, long PhoneNumberToChange)
        {
            int i = 0;
            bool surnameNotFound = true;
            string result = string.Empty;

            using (StreamReader sr = new StreamReader(path))
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
                        ClientsList.Add(new Client
                        {
                            Surname = args[0],
                            Name = args[1],
                            Patronymic = args[2],
                            PhoneNumber = PhoneNumberToChange,
                            RangePassport = args[4],
                            NumberPassport = args[5],
                            DateAndTime = dateAndTime,
                            WhatChanged = "/н.тел.",
                            WhoChanged = $"{GetType().Name}"
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
            File.Delete(path);
            File.Create(path).Close();
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
            {
                for (int j = 0; j < i; j++)
                {
                    string lineClient = string.Empty;
                    lineClient = $"{ClientsList[j].Surname}#" +
                                 $"{ClientsList[j].Name}#" +
                                 $"{ClientsList[j].Patronymic}#" +
                                 $"{ClientsList[j].PhoneNumber}#" +
                                 $"{ClientsList[j].RangePassport}#" +
                                 $"{ClientsList[j].NumberPassport}#" +
                                 $"{ClientsList[j].DateAndTime}#" +
                                 $"{ClientsList[j].WhatChanged}#" +
                                 $"{ClientsList[j].WhoChanged}";
                    sw.WriteLine(lineClient);
                }
            }
            return result;
        }

        #endregion
    }
}
