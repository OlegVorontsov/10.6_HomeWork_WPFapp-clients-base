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
        protected static FileOperator FileOper;
        protected static string path;

        #region Конструктор
        /// <summary>
        /// Создание экземпляра работника
        /// </summary>
        /// <param name="Path"></param>
        public Worker(string Path)
        {
            path = Path;
            FileOper = new FileOperator(path);
        }
        #endregion

        #region Методы
        /// <summary>
        /// Загрузка данных о клиентах из файла Справочник в коллекцию
        /// </summary>
        public virtual string Load()
        {
            string result = "Нужно выбрать должность";
            return result;
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
        public virtual string changeClientsList(string Surname, long PhoneNumber, string Post)
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
