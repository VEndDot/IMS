using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Interfaces.WriteOffInterfaces
{
    public interface IAddWriteOffUseCase
    {
        Task ExecuteAsync(MaterialWriteOff writeOff, int currentMasterId);
    }
}