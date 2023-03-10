using DTOEntity = ChallengeGYF.Shared.DTO.DTOProducto;

namespace ChallengeGYF.BLL.Interfaces
{
    public interface IProducto<T> : IGenericBase<T>
    {
        List<DTOEntity> CalcularProductos(int Presupuesto);
    }
}
