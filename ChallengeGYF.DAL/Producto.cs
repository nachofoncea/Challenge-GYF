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
using System.Collections;

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


        public List<DTOEntity> GetProductos(int cat, int presup)
        {
            using (var context1 = new ContextDB())
            {
                var _list = (from p in context1.Producto
                                            .Include(x => x.Categoria)
                                            .Where(x => x.Precio < presup &&
                                                   x.CategoriaID == cat)

                              select new DTOProducto
                              {
                                  ProductoID = p.ProductoID,
                                  Precio = p.Precio,
                                  CategoriaID = p.CategoriaID,
                                  Categoria = p.Categoria.Descripcion
                              })
                               .ToList();

                return _list;
            }
        }

        public List<DTOEntity> GetSeleccionProductos(List<DTOProducto>list1, List<DTOProducto> list2, int presup)
        {
            var _listSelected = new List<DTOProducto>();

            var _max = new { prod1 = -1, prod2 = -1, precio = -1 };

            foreach (var prod1 in list1)
            {
                foreach (var prod2 in list2)
                {
                    var _suma = prod1.Precio + prod2.Precio;

                    if (_suma < presup)
                    {
                        if (_suma > _max.precio)
                        {
                            _max = new
                            {
                                prod1 = prod1.ProductoID,
                                prod2 = prod2.ProductoID,
                                precio = _suma
                            };
                        }
                    }
                }
            }

            _listSelected.Add(list1.Find(x => x.ProductoID == _max.prod1));
            _listSelected.Add(list2.Find(x => x.ProductoID == _max.prod2));

            return _listSelected;

        }


        public List<DTOProducto> CalcularProductos(int Presupuesto)
        {

            var list1 = GetProductos(1, Presupuesto).ToList();

            var list2 = GetProductos(2, Presupuesto).ToList();

            var _listSelected = GetSeleccionProductos(list1,list2,Presupuesto).ToList();

            return _listSelected;     
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
