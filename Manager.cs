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
    }
}
