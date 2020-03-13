using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Въведете име")]
        [StringLength(25)]
        [Required(ErrorMessage ="Дължината на името не трябва да е под 5 символа")]
        public string Name { get; set; }

        [Display(Name = "Въведете фамилия")]
        [StringLength(25)]
        [Required(ErrorMessage = "Дължината на фамилията не трябва да е под 5 символа")]
        public string Surname { get; set; }

        [Display(Name = "Въведете адрес")]
        [StringLength(35)]
        [Required(ErrorMessage = "Дължината на адреса не трябва да е под 15 символа")]
        public string address { get; set; }

        [Display(Name = "Въведете телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Дължината на номера не трябва да е под 10 знака")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Дължината на името не трябва да е под 15 символа")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
