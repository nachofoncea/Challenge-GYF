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

        public List<DTOEntity> Vender(int Presupuesto)
        {
            var _ls = service2.Vender(Presupuesto);

            return _ls;
        }
    }
}