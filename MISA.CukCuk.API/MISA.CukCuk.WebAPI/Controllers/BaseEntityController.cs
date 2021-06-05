using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Common;
using MISA.CukCuk.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.WebAPI.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        private IBaseService<T> _baseService;

        public BaseEntityController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        // GET: api/<BaseController>
        [HttpGet]
        public IActionResult Get()
        {
            var responseResult = _baseService.GetEntities();
            return StatusCode(StatusCodes.Status200OK, responseResult);

        }


        // GET api/<BaseController>/5
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _baseService.GetById(entityId);

            }
            catch (Exception)
            {
                responseResult.OnBadRequest(responseResult);
                return StatusCode(StatusCodes.Status400BadRequest, responseResult);
                throw;
            }

            return StatusCode(StatusCodes.Status200OK, responseResult);
        }

        // POST api/<BaseController>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _baseService.Insert(entity);
            }
            catch (Exception)
            {
                responseResult.OnBadRequest(responseResult);
                return StatusCode(int.Parse(responseResult.ErrorCode.ToString()), responseResult);
                throw;
            }

            return StatusCode(StatusCodes.Status201Created, responseResult);
        }

        // PUT api/<BaseController>/5
        [HttpPut("{entityId}")]
        public IActionResult Put(Guid entityId, [FromBody] T entity)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _baseService.Update(entity, entityId);

            }
            catch (Exception)
            {
                responseResult.OnBadRequest(responseResult);
                return StatusCode(int.Parse(responseResult.ErrorCode.ToString()), responseResult);
                throw;
            }
            return StatusCode(StatusCodes.Status200OK, responseResult);

        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _baseService.Delete(entityId);

            }
            catch (Exception)
            {
                //return StatusCode(int.Parse(responseResult.ErrorCode.ToString()), responseResult);
                throw;
            }
            return StatusCode(StatusCodes.Status200OK, responseResult);

        }
    }
}
