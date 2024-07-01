using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Utilities;
using Sushi.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sushi.ViewModels
{
    public class EditFoodViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [StringLength(20, ErrorMessage = "Наименование не может быт длиннее 20 символов.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [StringLength(200, ErrorMessage = "Описание не может быть длиннее 200 символов.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Range(0, 1500, ErrorMessage = "Введите значение от 1 до 1500.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Url(ErrorMessage = "Введите действительный путь к картинке.")]
        public string Img { get; set; }
        public bool ToViewHome { get; set; }
        public virtual Category Category { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
