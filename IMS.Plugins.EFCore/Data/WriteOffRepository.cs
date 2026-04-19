using IMS.CoreBusiness.Entities;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data
{
    public class WriteOffRepository : IWriteOffRepository
    {
        private readonly IMSDbContext db;

        public WriteOffRepository(IMSDbContext db)
        {
            this.db = db;
        }

        public async Task AddWriteOffAsync(MaterialWriteOff writeOff, int currentMasterId)
        {
            // Проверяем, что все материалы существуют и хватает остатков
            foreach (var item in writeOff.Items)
            {
                var material = await this.db.materialNomenclatures.FindAsync(item.NomenclatureId);

                if (material is null)
                {
                    throw new InvalidOperationException($"Материал с ID {item.NomenclatureId} не найден");
                }

                if (material.CurrentStock < item.Quantity)
                {
                    throw new InvalidOperationException(
                        $"Недостаточно материала '{material.Name}'." +
                        $"Доступно: {material.CurrentStock} {material.Unit}, запрошено: {item.Quantity}");
                }
            }

            using var transaction = await this.db.Database.BeginTransactionAsync();

            try
            {
                // Заполняем данные заголовка
                writeOff.MasterId = currentMasterId;
                writeOff.WriteOffDate = DateTime.UtcNow;

                // Привязываем строки к заголовку
                foreach (var item in writeOff.Items)
                {
                    item.WriteOff = writeOff;
                }

                // Добавялем запись о списании
                await db.materialWriteOffs.AddAsync(writeOff);

                // Уменьшаем остатки у каждого материала
                foreach (var item in writeOff.Items)
                {
                    var material = await this.db.materialNomenclatures.FindAsync(item.NomenclatureId);
                    
                    if (material is not null)
                    {
                        material.CurrentStock -= item.Quantity;
                        this.db.materialNomenclatures.Update(material);
                    }
                }

                // Сохраняем все вместе
                await db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch 
            { 
                // откатываем все
                await transaction.RollbackAsync();
                throw;
            }

        }
    }
}
