using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.CoreBusiness.Entities.Materials
{
    public class Subcategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название подкатегории обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Название не может превышать 100 символов")]
        public string Name { get; set; } = string.Empty;

        // Внешний ключ на категорию
        public int CategoryId { get; set; }

        // Навигационные свойства
        public Category Category { get; set; } = null!;

        public ICollection<MaterialType> Types { get; set; } = new List<MaterialType>();
    }
}
