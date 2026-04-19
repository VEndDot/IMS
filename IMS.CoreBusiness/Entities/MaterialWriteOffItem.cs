using IMS.CoreBusiness.Entities.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.CoreBusiness.Entities
{
    public class MaterialWriteOffItem
    {
        public int Id { get; set; }

        // Foreign Keys
        [Required]
        public int WriteOffId { get; set; }

        [Required]
        public int NomenclatureId { get; set; }

        // Сколько списано
        [Required]
        [Range(0.001, 999999.999, ErrorMessage = "Некорректное количество")]
        public decimal Quantity { get; set; }

        // Навигационные свойства
        public MaterialWriteOff WriteOff { get; set; } = null!;
        public MaterialNomenclature Nomenclature { get; set; } = null!;
    }
}
