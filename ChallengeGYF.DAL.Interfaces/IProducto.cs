using DTOEntity = ChallengeGYF.Shared.DTO.DTOProducto;
using System.Collections.Generic;
using ChallengeGYF.DAL.Interfaces;

namespace ChallengeGYF.DAL.Interfaces
{
    public interface IProducto<T> : IGenericBase<T>
    {

        T Vender(int Presupuesto);

    }
}
