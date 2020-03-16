using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            this.DateAdded = DateTime.UtcNow;
        }
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Име (заглавие)")]
        public virtual string Title { get; set; }

        [Display(Name = "Съкратено описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Пълно описание")]
        public virtual string Text { get; set; }

        [Display(Name = "Главна картинка")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO метатаг Title")]
        public virtual string MetaTitle { get; set; }

        [Display(Name = "SEO метатаг Description")]
        public virtual string MetaDescription { get; set; }

        [Display(Name = "SEO метатаг Keywords")]
        public virtual string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
