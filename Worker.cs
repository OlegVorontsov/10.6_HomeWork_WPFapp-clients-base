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
            return "Нужно выбрать должность";
        }

        /// <summary>
        /// Метод возвращает коллекцию Клиентов
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Client> getClientsList()
        {
            return FileOper.ClientsBase;
        }

        /// <summary>
        /// Метод изменения данных клиента
        /// </summary>
        public virtual string changeClientsList(string SurnameOld, string SurnameNew, string Name, string Patronymic, long PhoneNumber, string RangePassport, string NumberPassport, string Post)
        {
            return "Нужно выбрать должность";
        }

        /// <summary>
        /// Метод добавления данных о клиенте
        /// </summary>
        /// <param name="Path"></param>
        public virtual string putClient(string Surname, string Name, string Patronymic, long PhoneNumber, string RangePassport, string NumberPassport)
        {
            return $"У {GetType().Name} нет реализации вызванного метода";
        }

        /// <summary>
        /// Метод сортировки клиентов
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Client> sortClientsList()
        {
            return FileOper.sortClientsList(FileOper.ClientsBase);
        }
        #endregion
    }
}
