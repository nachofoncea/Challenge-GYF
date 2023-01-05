using ChallengeGYF.BLL;
using IDal = ChallengeGYF.DAL.Interfaces.IProducto<ChallengeGYF.Shared.DTO.DTOProducto>;
using T = ChallengeGYF.Shared.DTO.DTOProducto;
using DTOEntity = ChallengeGYF.Shared.DTO.DTOProducto;

namespace ChallengeGYF.BLL
{
    public class Producto : BLLBase<T>, BLL.Interfaces.IProducto<T>
    {
        IDal service2;

        public Producto(IDal service)
        {
            _service = service;
            service2 = service;
        }

        public List<DTOEntity> CalcularProductos(int Presupuesto)
        {
            var _ls = service2.CalcularProductos(Presupuesto);

            return _ls;
        }
    }
}