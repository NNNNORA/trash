using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextLibrary.Entities
{
    /// <summary>
    /// Статус заявки
    /// </summary>
    public enum RequestStatus
    {
        /// <summary>
        /// Новая заявка
        /// </summary>
        New,
        /// <summary>
        /// Заявка в процессе выполнения
        /// </summary>
        InProcess,
        /// <summary>
        /// Заявка завершена
        /// </summary>
        Completed
    }
}
