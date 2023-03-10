using ChallengeGYF.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DTOEntity = ChallengeGYF.Shared.DTO.DTOProducto;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using ChallengeGYF.Shared.DTO;
using System.Net.Http.Headers;
using ChallengeGYF.DAL.EF.Models;
using Ducasse.Shared.Constants;

namespace ChallengeGYF.API.Controllers
{

    // //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProducto<DTOEntity> _bll; 
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(ILogger<ProductoController> logger,
                                       IProducto<DTOEntity> bll)
        {
            _logger = logger;
            _bll = bll;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<DTOEntity> GetAll()
        {
            var gg = _bll.GetAll();
            return gg;
        }

        [HttpPost]
        public ActionResult Add([FromBody] Shared.DTO.DTOProducto item)
        {
            item.FechaCarga = System.DateTime.Now;

            if (item.Precio <= Constants.MontoMin)
            {
                return StatusCode(400, "El precio debe ser mayor a " + Constants.MontoMin);
            }

            if (item.Precio > Constants.MontoMax)
            {
                return StatusCode(400, "El precio debe ser menor a " + Constants.MontoMax);
            }
            if (item.CategoriaID == null)
            {
                return StatusCode(400, "No hay Categoria seleccionada");
            }
            else
            {
                var id = _bll.Add(item);
                return Ok();
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] Shared.DTO.DTOProducto item)
        {
            if (item.Precio <= Constants.MontoMin)
            {
                return StatusCode(400, "El precio debe ser mayor a " + Constants.MontoMin);
            }

            if (item.Precio > Constants.MontoMax)
            {
                return StatusCode(400, "El precio debe ser menor a " + Constants.MontoMax);
            }
            if (item.CategoriaID == null)
            {
                return StatusCode(400, "No hay Categoria seleccionada");
            }
            else
            {
                _bll.Update(item);
                return Ok();
            }
        }

        [HttpGet]
        [Route("{ID}")]
        public DTOEntity GetByID(int ID)
        {
            return _bll.GetByID(ID);
        }

        [HttpGet]
        [Route("CalcularProductos/{Presupuesto}")]
        public List<DTOEntity> CalcularProductos(int Presupuesto)
        {
            return _bll.CalcularProductos(Presupuesto);
        }

        [HttpDelete]
        [Route("{ID}")]
        public ActionResult Delete(int ID)
        {
            _bll.Delete(ID);
            return Ok("El Producto " + ID + " ha sido eliminado");
        }

    }
}

