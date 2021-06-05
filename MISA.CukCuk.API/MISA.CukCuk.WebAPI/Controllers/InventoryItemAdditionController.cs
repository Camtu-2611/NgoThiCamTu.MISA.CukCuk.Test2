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
    //[Route("api/[controller]")]
    //[ApiController]
    public class InventoryItemAdditionController : BaseEntityController<InventoryItemAddition>
    {
        private IInventoryItemAdditionService _inventoryService;
        public InventoryItemAdditionController(IInventoryItemAdditionService inventoryService) : base(inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("byInventoryItemId/{inventoryItemId}")]
        public new IActionResult Get(Guid inventoryItemId)
        {
            var result = new ServiceResult();
            try
            {
                result = _inventoryService.GetInventoryItemAdditionByInventoryItemId(inventoryItemId);
            }
            catch (Exception)
            {
                //return StatusCode(int.Parse(result.ErrorCode.ToString()), result);
                result.OnBadRequest(result);
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
