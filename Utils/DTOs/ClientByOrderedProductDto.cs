using Akelon.Task_2.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelon.Task_2.Utils.DTOs
{
    public class ClientByOrderedProductDto
    {
        [Display(Name = "Код клиента")]
        public int Code { get; set; }

        [Display(Name = "Наименование организации")]
        public string Company { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Контактное лицо (ФИО)")]
        public string FullName { get; set; }

        [Display(Name = "Количество товара")]
        public int ProductQuantity { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Дата заказа")]
        public DateTimeOffset OrderDate { get; set; }

        public override string ToString()
        {
            // TODO: use displaynames
            return
                $"Код клиента: {Code} \nНаименование организации: {Company} \nАдрес: {Address} \nКонтактное лицо (ФИО) {FullName} \nКоличество товара: {ProductQuantity} \nЦена: {Price} Дата заказа: {OrderDate}";
        }
    }
}
