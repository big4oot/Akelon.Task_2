using System.ComponentModel.DataAnnotations;
using Akelon.Task_2.Domain.Common;
using Akelon.Task_2.Utils.Attributes;

namespace Akelon.Task_2.Domain.Models
{
    [WorksheetName("Заявки")]
    [Display(Name = "Заявка")]
    public class Order : ExcelData
    {
        [Display(Name = "Код заявки")]
        [ColumnName("Код заявки")]
        public int Code { get; set; }

        [Display(Name = "Код товара")]
        [ColumnName("Код товара")]
        public int ProductCode { get; set; }

        [Display(Name = "Код клиента")]
        [ColumnName("Код клиента")]
        public int ClientCode { get; set; }

        [Display(Name = "Номер заявки")]
        [ColumnName("Номер заявки")]
        public int Number { get; set; }

        [Display(Name = "Требуемое количество")]
        [ColumnName("Требуемое количество")]
        public int Quantity { get; set; }

        [Display(Name = "Дата размещения")]
        [ColumnName("Дата размещения")]
        public DateTimeOffset PublishDate { get; set; }
    }
}
