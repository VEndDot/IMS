using IMS.CoreBusiness.Entities.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.CoreBusiness.Entities
{
    /// <summary>
    /// Заголовок списания. Кто, когда, зачем
    /// </summary>
    public class MaterialWriteOff
    {
        public int Id { get; set; }

        // Причина / для чего списано
        [Required(ErrorMessage = "Укажите причину списания")]
        [StringLength(300, ErrorMessage = "Причина не может превышать 300 символов")]
        public string Reason { get; set; } = string.Empty;

        // Кто списал
        [Required]
        public int MasterId { get; set; }

        // Когда списано
        [Required]
        public DateTime WriteOffDate { get; set; } = DateTime.UtcNow;

        // Навигационные свойства
        public UserAccount Master { get; set; } = null!;
        public ICollection<MaterialWriteOffItem> Items { get; set; } = new List<MaterialWriteOffItem>();
    }
}
