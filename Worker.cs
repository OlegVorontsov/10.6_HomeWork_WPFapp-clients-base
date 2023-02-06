using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._6_HomeWork_WPFapp_clients_base
{
    class Worker
    {
        protected static ObservableCollection<Client> ClientsList = new ObservableCollection<Client>();
        protected static string path;

        #region Конструктор
        /// <summary>
        /// Создание экземпляра работника
        /// </summary>
        /// <param name="Path"></param>
        public Worker(string Path)
        {
            path = Path;
        }
        #endregion

        #region Методы
        /// <summary>
        /// Загрузка данных о клиентах из файла Справочник в коллекцию
        /// </summary>
        public virtual void Load()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    ClientsList.Add(new Client(args[0], args[1], args[2], long.Parse(args[3]), args[4], args[5], args[6], args[7], args[8]));
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
        /// Метод изменения данных клиента
        /// </summary>
        public virtual string changeClientsList(string Surname, long PhoneNumber)
        {
            string result = $"У { GetType().Name} нет реализации вызванного метода";
            return result;
        }

        /// <summary>
        /// Метод добавления данных о клиентах
        /// </summary>
        /// <param name="Path"></param>
        public virtual void putClients(string Path)
        {
            Console.WriteLine($"У {GetType().Name} нет реализации вызванного метода");
        }
        #endregion
    }
}
