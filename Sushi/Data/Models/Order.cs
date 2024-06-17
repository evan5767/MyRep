using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class Order
    {

        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов!")]
        public string Name { get; set; }

        [Display(Name = "Введите свой адрес")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина адреса не менее 5 символов!")]
        public string Adress { get; set; }

        [Display(Name = "Введите номер ваш телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина номера телефона не менее 5 символов!")]
        public string Phone { get; set; }

        [Display(Name = "Введите ваш E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина E-mail не менее 5 символов!")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails {  get; set; } 


    }
}
