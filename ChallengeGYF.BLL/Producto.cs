using ChallengeGYF.BLL;
using IDal = ChallengeGYF.DAL.Interfaces.IProducto<ChallengeGYF.Shared.DTO.DTOProducto>;
using T = ChallengeGYF.Shared.DTO.DTOProducto;

namespace ChallengeGYF.BLL
{
    public class Producto : BLLBase<T>, BLL.Interfaces.IProducto<T>
    {
        public Producto(IDal service)
        {
            _service = service;
        }

        public virtual T Vender(int Presupuesto)
        {
            try
            {
                var _ls = _service.Vender(Presupuesto);

                return _ls;
            }
            catch (System.Exception e)
            {

                throw;
            }
        }
    }
}
