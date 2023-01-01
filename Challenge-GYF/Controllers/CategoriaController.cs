using ChallengeGYF.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DTOEntity = ChallengeGYF.Shared.DTO.DTOCategoria;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using ChallengeGYF.Shared.DTO;
using System.Net.Http.Headers;

namespace ChallengeGYF.API.Controllers
{

    // //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoria<DTOEntity> _bll;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ILogger<CategoriaController> logger,
                                       ICategoria<DTOEntity> bll)
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
        public ActionResult Add([FromBody] Shared.DTO.DTOCategoria item)
        {

            var id = _bll.Add(item);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] Shared.DTO.DTOCategoria item)
        {
            _bll.Update(item);
            return Ok();
        }

        [HttpGet]
        [Route("{ID}")]
        public DTOEntity GetByID(int ID)
        {
            return _bll.GetByID(ID);
        }

        [HttpDelete]
        [Route("{ID}")]
        public ActionResult Delete(int ID)
        {
            _bll.Delete(ID);
            return Ok();
        }
    }
}

