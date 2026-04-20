using IMS.CoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IWriteOffRepository
    {
        Task AddWriteOffAsync(MaterialWriteOff writeOff, int currentMasterId);
        Task<IEnumerable<MaterialWriteOff>> GetWriteOffHistoryAsync(int? masterId, DateTime? dateFrom, DateTime? dateTo);
    }
}
