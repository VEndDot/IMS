using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Interfaces.WriteOffInterfaces
{
    public interface IViewWriteOffHistoryUseCase
    {
        Task<IEnumerable<MaterialWriteOff>> ExecuteAsync(int? masterId, DateTime? dateFrom, DateTime? dateTo);
    }
}