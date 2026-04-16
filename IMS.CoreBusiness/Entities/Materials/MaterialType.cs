using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.CoreBusiness.Entities.Materials
{
    public class MaterialType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название типа обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Название не может превышать 100 символов")]
        public string Name { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "Описание не может превышать 255 символов")]
        public string? Description { get; set; }

        // Внешний ключ
        public int SubcategoryId { get; set; }

        // Навигационные свойства
        public Subcategory Subcategory { get; set; } = null!;
        public ICollection<MaterialNomenclature> Nomenclatures { get; set; } = new List<MaterialNomenclature>();
    }
}
