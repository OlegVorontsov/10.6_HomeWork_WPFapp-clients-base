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
        public override string Load()
        {
            FileOper.LoadHiddenPassport();
            return "Данные выведены";
        }

        /// <summary>
        /// Метод изменяет номер телефона по фамилии клиента
        /// </summary>
        /// <param name="SurnameToChangePhoneNumber"></param>
        /// <param name="PhoneNumberToChange"></param>
        public override string changeClientsList(string SurnameToChangePhoneNumber, string SurnameNew, string Name, string Patronymic, long PhoneNumberToChange, string RangePassport, string NumberPassport, string Post)
        {
            string result = FileOper.changeClientsPhoneNumber(SurnameToChangePhoneNumber, PhoneNumberToChange, Post);
            FileOper.LoadHiddenPassport();
            return result;
        }

        #endregion
    }
}
