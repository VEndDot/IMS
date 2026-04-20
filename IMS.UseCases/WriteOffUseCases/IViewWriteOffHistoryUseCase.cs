using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.WriteOffUseCases
{
    public interface IViewWriteOffHistoryUseCase
    {
        Task<IEnumerable<MaterialWriteOff>> ExecuteAsync(int? masterId, DateTime? dateFrom, DateTime? dateTo);
    }
}