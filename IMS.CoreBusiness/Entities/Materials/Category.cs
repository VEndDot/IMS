using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.CoreBusiness.Entities.Materials
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название категории обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Название не может превышать 100 символов")]
        public string Name { get; set; } = string.Empty;

        // Навигационное свойство
        public ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    }
}
