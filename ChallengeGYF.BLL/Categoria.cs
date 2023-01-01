using ChallengeGYF.BLL;
using IDal = ChallengeGYF.DAL.Interfaces.ICategoria<ChallengeGYF.Shared.DTO.DTOCategoria>;
using T = ChallengeGYF.Shared.DTO.DTOCategoria;

namespace ChallengeGYF.BLL
{
    public class Categoria : BLLBase<T>, BLL.Interfaces.ICategoria<T>
    {
        public Categoria(IDal service)
        {
            _service = service;
        }
    }
}
