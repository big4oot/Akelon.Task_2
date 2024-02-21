using System.ComponentModel.DataAnnotations;
using Akelon.Task_2.Domain.Common;
using Akelon.Task_2.Domain.Enums;
using Akelon.Task_2.Utils.Attributes;

namespace Akelon.Task_2.Domain.Models
{
    [WorksheetName("Товары")]
    [Display(Name = "Товар")]
    public class Product : ExcelData
    {
        [Display(Name = "Код товара")]
        [ColumnName("Код товара")]
        public int Code { get; set; }

        [Display(Name = "Наименование")]
        [ColumnName("Наименование")]
        public string Name { get; set; }

        [Display(Name = "Ед. измерения")]
        [ColumnName("Ед. измерения")]
        public Unit Unit { get; set; }

        [Display(Name = "Цена товара за единицу")]
        [ColumnName("Цена товара за единицу")]
        public decimal Cost { get; set; }
    }
}
