using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextLibrary.Entities
{
    public enum ExecutionStage
    {
        /// <summary>
        /// ожидание запчастей
        /// </summary>
        WaitingForSpareParts,
        /// <summary>
        /// Заявка в процессе ремонта
        /// </summary>
        InProcessOfRepair,
        /// <summary>
        /// Готово к выдаче
        /// </summary>
        ReadyForIssue
    }
}
