using IMS.CoreBusiness.Entities;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.WriteOffUseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.Interfaces.WriteOffInterfaces
{
    public class ViewWriteOffHistoryUseCase : IViewWriteOffHistoryUseCase
    {
        private readonly IWriteOffRepository writeOffRepository;

        public ViewWriteOffHistoryUseCase(IWriteOffRepository writeOffRepository)
        {
            this.writeOffRepository = writeOffRepository;
        }

        public async Task<IEnumerable<MaterialWriteOff>> ExecuteAsync(int? masterId, DateTime? dateFrom, DateTime? dateTo)
        {
            return await this.writeOffRepository.GetWriteOffHistoryAsync(masterId, dateFrom, dateTo);
        }
    }
}
