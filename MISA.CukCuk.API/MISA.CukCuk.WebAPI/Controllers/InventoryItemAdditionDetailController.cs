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
    public class InventoryItemAdditionDetailController : BaseEntityController<InventoryItemAdditionDetail>
    {
        private IInventoryItemAdditionDetailService _inventoryService;
        public InventoryItemAdditionDetailController(IInventoryItemAdditionDetailService inventoryService) : base(inventoryService)
        {
            _inventoryService = inventoryService;
        }
        [HttpDelete]
        public new IActionResult Delete(InventoryItemAdditionDetail item)
        {
            var result = new ServiceResult();

            try
            {
                result = _inventoryService.DeleteInventoryItemAdditionDetail(item.InventoryItemId, item.InventoryItemAdditionId);
            }
            catch (Exception)
            {
                result.OnBadRequest(result);
                throw;
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
