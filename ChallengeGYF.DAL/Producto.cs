using AutoMapper;
using ChallengeGYF.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DTOEntity = ChallengeGYF.Shared.DTO.DTOProducto;
using ModelEntity = ChallengeGYF.DAL.EF.Models.Producto;
using ContextDB = ChallengeGYF.DAL.EF.Models.ChallengeGYFContext;
using Microsoft.EntityFrameworkCore;
using ChallengeGYF.Shared.DTO;
using Azure.Core;
using System.Net;

namespace ChallengeGYF.DAL.EF
{
    public class Producto : IProducto<DTOEntity>
    {

        //*****************************************
        //        Public  Methods
        //*****************************************
        public List<DTOEntity> GetAll()
        {

            var _ls = new List<DTOEntity>();

            using (var context = new ContextDB())
            {
                var _pp = context.Producto
                                 .Include(x => x.Categoria)
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
                context.Producto.Add(this._Map(item));
                context.SaveChanges();
                item.ProductoID = entity.ProductoID;
                return item;
            }
        }

        public void Update(DTOEntity item)
        {

            using (var context = new ContextDB())
            {

                var _entity = this._GetByID(item.ProductoID);

                if (item.Categoria == null)
                {
                    item.Categoria = _GetCategoria(item.CategoriaID);
                }


                _entity = _Map(item);

                context.Producto.Update(_entity);
                context.SaveChanges();
            }
        }

        public DTOEntity GetByID(int ID)
        {
            return _Map(_GetByID(ID));
        }

        public List<DTOEntity> Vender(int Presupuesto)
        {

            var _ls = new List<DTOProducto>();

            using (var context1 = new ContextDB())
            {
                var first_product = context1.Producto
                                    .Include(x => x.Categoria)
                                    .Where(x => x.Precio < Presupuesto)
                                    .OrderByDescending(x=> x.Precio)
                                    .FirstOrDefault();

                if (first_product != null)
                    using (var context2 = new ContextDB())
                    {
                        var second_product = context2.Producto
                                            .Include(x => x.Categoria)
                                            .Where(x => x.Precio <= Presupuesto - first_product.Precio &&
                                                   x.CategoriaID != first_product.CategoriaID)
                                            .OrderByDescending(x => x.Precio)
                                            .FirstOrDefault();

                        if (second_product != null)
                        {
                            _ls.Add(this._Map(first_product));
                            _ls.Add(this._Map(second_product));
                        }
                }
            }

            if (_ls.Count() < 2)
            {
            }
            return _ls;
        }


        public void Delete(int ID)
        {
            using (var context = new ContextDB())
            {
                var _entity1 = this._GetByID(ID);
                context.Producto.Remove(_entity1);
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
                _ret = context.Producto
                               .Include(x => x.Categoria)
                               .FirstOrDefault(x => x.ProductoID == ID);
            }
            
            
            return _ret;
        }

        private DTOEntity _Map(ModelEntity item)
        {
            {
                return new DTOEntity
                {
                    ProductoID = item.ProductoID,
                    CategoriaID = item.CategoriaID,
                    FechaCarga = item.FechaCarga,
                    Precio = item.Precio,
                    Categoria = item.Categoria.Descripcion

                };
            }

        }

        private ModelEntity _Map(DTOEntity item)
        {
                return new ModelEntity
                {
                    ProductoID = item.ProductoID,
                    CategoriaID = item.CategoriaID,
                    FechaCarga = item.FechaCarga,
                    Precio = item.Precio,
                };
        }


        private String _GetCategoria(int categoriaID)
        {
            var _ret = new Models.Categoria();
            using (var context = new ContextDB())
            {
                _ret = context.Categoria
                               .FirstOrDefault(x => x.CategoriaID == categoriaID);
            }

            return _ret.Descripcion;
        }


    }}
