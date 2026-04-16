using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.CoreBusiness.Entities.Materials
{
    public class MaterialNomenclature
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название материала обязательно для заполнения")]
        [StringLength(200, ErrorMessage = "Название не может превышать 200 символов")]
        public string Name { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Артикул не может превышать 50 символов")]
        public string? Sku { get; set; }

        [StringLength(100, ErrorMessage = "ГОСТ не может превышать 100 символов")]
        public string? Gost { get; set; }

        [Range(0.01, 9999.99, ErrorMessage = "Некорректное значение сечения")]
        public decimal? CrossSection { get; set; }

        [StringLength(10)]
        public string Unit { get; set; } = "м";

        [Range(0, 999999.999, ErrorMessage = "Некорректное значение остатка")]
        public decimal CurrentStock { get; set; } = 0;

        // Foreign Key
        public int TypeId { get; set; }

        // Навигационное свойство
        public MaterialType Type { get; set; } = null!;
    }
}
