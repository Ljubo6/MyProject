using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage ="Попълнете името на услугата")]
        [Display(Name = "Име на услугата")]
        public override string Title { get; set; } = "Информационна страница";

        [Display(Name = "Кратко описание на услугата")]
        public override string Subtitle { get; set; }

        [Display(Name = "Пълно описание на услугата")]
        public override string Text { get; set; }
    }
}
