using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._6_HomeWork_WPFapp_clients_base
{
    class Manager : Worker
    {
        /// <summary>
        /// Создание экземпляра Менеджера
        /// </summary>
        /// <param name="Path"></param>
        public Manager(string Path) : base(Path)
        {
        }

        #region Методы

        /// <summary>
        /// Загрузка данных о клиентах из файла Справочник в коллекцию
        /// </summary>
        public override string Load()
        {
            FileOper.Load();
            return "Данные выведены";
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
        public override string changeClientsList(string SurnameOld, string SurnameNew, string Name, string Patronymic, long PhoneNumber, string RangePassport, string NumberPassport, string Post)
        {
            string result = FileOper.changeClientsAllData(SurnameOld, SurnameNew, Name, Patronymic, PhoneNumber, RangePassport, NumberPassport, Post);
            FileOper.Load();
            return result;
        }

        /// <summary>
        /// Метод добавления данных о клиенте
        /// </summary>
        public override string putClient(string Surname, string Name, string Patronymic, long PhoneNumber, string RangePassport, string NumberPassport)
        {
            string result = FileOper.putClient(Surname, Name, Patronymic, PhoneNumber, RangePassport, NumberPassport);
            FileOper.Load();
            return result;
        }
        #endregion
    }
}
