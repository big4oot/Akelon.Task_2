using Akelon.Task_2.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akelon.Task_2.Domain.Models;
using AutoMapper;

namespace Akelon.Task_2.Utils.DTOs
{
    public class GoldenClientDto
    {
        [Display(Name = "Код клиента")]
        public int Code { get; set; }

        [Display(Name = "Наименование организации")]
        public string Company { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Контактное лицо (ФИО)")]
        public string FullName { get; set; }

        public override string ToString()
        {
            return $"Код клиента: {Code} \nНаименование организации: {Company} \nАдрес: {Address} \nКонтактное лицо (ФИО): {FullName}";
        }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Client, GoldenClientDto>();
            }
        }
    }
}
