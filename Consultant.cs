using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._6_HomeWork_WPFapp_clients_base
{
    class Consultant
    {
        private Client[] Clients;

        private string path;
        int index;
        string[] titles;

        #region Коструктор
        /// <summary>
        /// Создание репозитория
        /// </summary>
        /// <param name="Path"></param>
        public Consultant(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.titles = new string[7];
            this.Clients = new Client[2];
        }
        #endregion
    }
}
