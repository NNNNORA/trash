using System;
using prilog;
namespace ContextLibrary.Entities
{
    /// <summary>
    /// Сущность "Заявка"
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime AddedDate { get; set; }
        /// <summary>
        /// Тип бытовой техники
        /// </summary>
        public string ApplianceType { get; set; }
        /// <summary>
        /// Модель техники
        /// </summary>
        public required string ApplianceModel { get; set; }
        /// <summary>
        /// Описание проблемы
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// ФИО клиента
        /// </summary>
        public required string ClientLFP { get; set; }
        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public required string PhoneNumber { get; set; }
        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus Status { get; set; }
    }
}
