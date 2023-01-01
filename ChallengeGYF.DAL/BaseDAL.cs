using AutoMapper;
using ChallengeGYF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ChallengeGYF.DAL.EF
{
    public class BaseDAL<T, TModel> : IGenericBase<T> where T : class
                                                      where TModel : class
    {
        MapperConfiguration _configuration;
        IMapper _mapper;

        public BaseDAL()
        {
            _configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<T, TModel>();
                cfg.CreateMap<TModel, T>();
            });
            _mapper = _configuration.CreateMapper();
        }

        public T Add(T item)
        {
            using var context = new Models.ChallengeGYFContext();
            {
                var _map = _Map(item);
                context.Set<TModel>().Add(_map);
                context.SaveChanges();
                return _Map(_map);
            }
        }

        public void Delete(int ID)
        {
            var _entity1 = this._GetByID(ID);
            using var context = new Models.ChallengeGYFContext();
            {
                context.Set<TModel>().Remove(_entity1);
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            var _ls = new List<T>();

            using var context = new Models.ChallengeGYFContext();
            {
                var _gc = context.Set<TModel>();

                foreach (var item in _gc)
                {
                    _ls.Add(_Map(item));
                }

            }

            return _ls;
        }

        public T GetByID(int ID)
        {
            var item = this._GetByID(ID);

            return _Map(item);
        }

        public List<T> GetByName(string name)
        {
            var _ls = new List<T>();

            using var context = new Models.ChallengeGYFContext();
            {

                // TODO :HACER EXPRESSION
                var _gc = (context.Set<TModel>()).ToList();
                //.Where(x => x. ..Contains(name))
                //.OrderBy(x => x.);

                foreach (var item in _gc)
                {
                    _ls.Add(_Map(item));
                }
            }

            return _ls;
        }

        public void Update(T item)
        {

            using var context = new Models.ChallengeGYFContext();
            {
                var _entity = _Map(item);
                context.Set<TModel>().Update(_entity);
                context.SaveChanges();

            }

        }

        //*****************************************
        //        Private  Methods
        //*****************************************

        private TModel _GetByID(int ID)
        {

            TModel _ret = null;
            using var context = new Models.ChallengeGYFContext();
            {
                _ret = context.Set<TModel>().Find(ID);
            }

            return _ret;
        }

        public T _Map(TModel item)
        {
            return _mapper.Map<T>(item);
        }

        public TModel _Map(T item)
        {
            return _mapper.Map<TModel>(item);
        }
    }
}
