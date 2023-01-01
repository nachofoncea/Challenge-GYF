using System.Collections.Generic;

namespace ChallengeGYF.BLL.Interfaces
{
    public interface IGenericBase<T>
    {
        List<T> GetAll();
        T GetByID(int ID);
        T Add(T item);
        void Update(T item);
        void Delete(int ID);
    }
}
