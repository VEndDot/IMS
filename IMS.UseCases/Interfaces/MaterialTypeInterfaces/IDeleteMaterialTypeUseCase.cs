namespace IMS.UseCases.Interfaces.MaterialTypeInterfaces
{
    public interface IDeleteMaterialTypeUseCase
    {
        Task ExecuteAsync(int materialTypeId);
    }
}