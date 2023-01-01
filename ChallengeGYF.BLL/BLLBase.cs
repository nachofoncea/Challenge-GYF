using System.Collections.Generic;

namespace ChallengeGYF.BLL
{
    public abstract class BLLBase<T> where T : class
    {
        public DAL.Interfaces.IGenericBase<T> _service;

        public virtual T Add(T item)
        {
            try
            {
                return _service.Add(item);
            }
            catch (System.Exception e)
            {

                throw;
            }
        }

        public virtual void Delete(int ID)
        {
            try
            {

                _service.Delete(ID);
            }
            catch (System.Exception e)
            {

                throw;
            }
        }

        public virtual List<T> GetAll()
        {
            try
            {
                var _ls = _service.GetAll();

                return _ls;
            }
            catch (System.Exception e)
            {
                throw;
            }
        }

        public virtual T GetByID(int ID)
        {
            try
            {
                var _ls = _service.GetByID(ID);

                return _ls;
            }
            catch (System.Exception e)
            {

                throw;
            }
        }

      
        public virtual void Update(T item)
        {
            try
            {
                _service.Update(item);

            }
            catch (System.Exception e)
            {

                throw;
            }
        }
    }
}
