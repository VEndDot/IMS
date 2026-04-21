namespace IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces
{
    public interface IDeleteMaterialNomenclatureUseCase
    {
        Task ExecuteAsync(int materialId);
    }
}