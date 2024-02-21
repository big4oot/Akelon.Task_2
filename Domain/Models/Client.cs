using System.ComponentModel.DataAnnotations;
using Akelon.Task_2.Domain.Common;
using Akelon.Task_2.Utils.Attributes;

namespace Akelon.Task_2.Domain.Models
{
    [Display(Name = "Клиент")]
    [WorksheetName("Клиенты")]
    public class Client : ExcelData
    {
        [Display(Name = "Код клиента")]
        [ColumnName("Код клиента")]
        public int Code { get; set; }

        [Display(Name = "Наименование организации")]
        [ColumnName("Наименование организации")]
        public string Company { get; set; }

        [Display(Name = "Адрес")]
        [ColumnName("Адрес")]
        public string Address { get; set; }

        [Display(Name = "Контактное лицо (ФИО)")]
        [ColumnName("Контактное лицо (ФИО)")]
        public string FullName { get; set; }
    }

}
