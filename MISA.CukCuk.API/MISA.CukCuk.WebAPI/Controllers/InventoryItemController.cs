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
    public class InventoryItemController : BaseEntityController<InventoryItem>
    {
        private IInventoryItemService _inventoryService;
        public InventoryItemController(IInventoryItemService inventoryService) : base(inventoryService)
        {
            _inventoryService = inventoryService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="inventoryItemTypeName"></param>
        /// <param name="inventoryItemCode"></param>
        /// <param name="inventoryItemName"></param>
        /// <param name="inventoryItemCategoryName"></param>
        /// <param name="unit"></param>
        /// <param name="salePrice"></param>
        /// <param name="changeOutwardPrice"></param>
        /// <param name="allowAdjustPrice"></param>
        /// <param name="measureInventoryItemStatus"></param>
        /// <param name="isShowOnMenu"></param>
        /// <param name="inActive"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public IActionResult Get(int pageSize,
            int pageIndex,
            string inventoryItemTypeName,
            string inventoryItemCode,
            string inventoryItemName,
            string inventoryItemCategoryName,
            string unit,
            int? salePrice,
            int? changeOutwardPrice,
            int? allowAdjustPrice,
            int? measureInventoryItemStatus,
            int? isShowOnMenu,
            int? inActive)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _inventoryService.GetInventoryItemFilterPaging(pageSize,
                    pageIndex,
                    inventoryItemTypeName,
                    inventoryItemCode,
                    inventoryItemName,
                    inventoryItemCategoryName,
                    unit,
                    salePrice,
                    changeOutwardPrice,
                    allowAdjustPrice,
                    measureInventoryItemStatus,
                    isShowOnMenu,
                    inActive);
            }
            catch (Exception e)
            {
                responseResult.OnException(responseResult, e);
            }

            return Ok(responseResult);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventoryItemCode"></param>
        /// <returns></returns>
        [HttpGet("bycode/{inventoryItemCode}")]
        public IActionResult Get(string inventoryItemCode)
        {
            var result = new ServiceResult();
            try
            {
                result = _inventoryService.GetInventoryItemByCode(inventoryItemCode);
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
