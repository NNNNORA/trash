using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextLibrary.Entities
{
    /// <summary>
    /// Ответственный за выполнение работ
    /// </summary>
    public class Mechanic
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public required string LFP { get; set; }
    }
}
