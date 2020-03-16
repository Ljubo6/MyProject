using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Име на страницата (заглавие)")]
        public override string Title { get; set; } = "Информационна страница";

        [Display(Name = "Съдържание на страницата")]
        public override string Text { get; set; } = "Съдържанието са запълва от администратора";
    }
}
