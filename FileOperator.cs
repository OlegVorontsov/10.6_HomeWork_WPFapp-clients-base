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
        protected static ObservableCollection<Client> Base = new ObservableCollection<Client>();
        protected static string path;

        #region Конструктор
        public FileOperator(string Path)
        {
            path = Path;
        }
        #endregion

        public ObservableCollection<Client> Load()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    Base.Add(new Client(args[0], args[1], args[2], long.Parse(args[3]), args[4], args[5], args[6], args[7], args[8]));
                }
            }
            return Base;
        }

        public ObservableCollection<Client> LoadHiddenPassport()
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

                    Base.Add(new Client
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
            return Base;
        }
    }
}
