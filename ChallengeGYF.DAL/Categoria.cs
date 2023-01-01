using AutoMapper;
using ChallengeGYF.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DTOEntity = ChallengeGYF.Shared.DTO.DTOCategoria;
using ModelEntity = ChallengeGYF.DAL.EF.Models.Categoria;
using ContextDB = ChallengeGYF.DAL.EF.Models.ChallengeGYFContext;
using Microsoft.EntityFrameworkCore;

namespace ChallengeGYF.DAL.EF
{
    public class Categoria : ICategoria<DTOEntity>
    {

        //*****************************************
        //        Public  Methods
        //*****************************************
        public List<DTOEntity> GetAll()
        {

            var _ls = new List<DTOEntity>();

            using (var context = new ContextDB())
            {
                var _pp = context.Categoria
                                 .ToList();

                foreach (var item in _pp)
                {
                    _ls.Add(this._Map(item));
                }
            }

            return _ls;

        }

        public DTOEntity Add(DTOEntity item)
        {

            using (var context = new ContextDB())
            {

                var entity = this._Map(item);
                context.Categoria.Add(this._Map(item));
                context.SaveChanges();
                item.CategoriaID = entity.CategoriaID;
                return item;
            }
        }

        public void Update(DTOEntity item)
        {

            using (var context = new ContextDB())
            {

                var _entity = this._GetByID(item.CategoriaID);

                _entity = _Map(item);

                context.Categoria.Update(_entity);
                context.SaveChanges();
            }
        }

        public DTOEntity GetByID(int ID)
        {
            return _Map(_GetByID(ID));
        }

        public void Delete(int ID)
        {
            using (var context = new ContextDB())
            {
                var _entity1 = this._GetByID(ID);
                context.Categoria.Remove(_entity1);
                context.SaveChanges();
            }
        }

        //*****************************************
        //        Private  Methods
        //*****************************************

        private ModelEntity _GetByID(int ID)
        {

            var _ret = new ModelEntity();
            using (var context = new ContextDB())
            {
                _ret = context.Categoria
                               .FirstOrDefault(x => x.CategoriaID == ID);
            }

            return _ret;
        }

        private DTOEntity _Map(ModelEntity item)
        {
            return new DTOEntity
            {
                CategoriaID = item.CategoriaID,
                Detalle = item.Descripcion,
                Observaciones = item.Observaciones
            };

        }

        private ModelEntity _Map(DTOEntity item)
        {

            return new ModelEntity
            {
                CategoriaID = item.CategoriaID,
                Descripcion = item.Detalle,
                Observaciones = item.Observaciones
            };

        }

    }

}
