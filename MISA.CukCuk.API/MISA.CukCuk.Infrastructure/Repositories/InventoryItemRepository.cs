using Dapper;
using MISA.CukCuk.Common;
using MISA.CukCuk.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repositories
{

    public class InventoryItemRepository : BaseRepository<InventoryItem>, IInventoryItemRepository
    {
        public PagingResult<InventoryItem> GetInventoryItemFilterPaging(
            int pageSize,
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
            var entitiesPaging = new PagingResult<InventoryItem>();
            var procName = "Proc_GetInventoryItemFilterPaging";
            var parameters = new DynamicParameters();
            parameters.Add("@PageSize", pageSize);
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@InventoryItemTypeName", inventoryItemTypeName);
            parameters.Add("@InventoryItemCode", inventoryItemCode);
            parameters.Add("@InventoryItemName", inventoryItemName);
            parameters.Add("@InventoryItemCategoryName", inventoryItemCategoryName);
            parameters.Add("@Unit", unit);
            parameters.Add("@SalePrice", salePrice);
            parameters.Add("@ChangeOutwardPrice", changeOutwardPrice);
            parameters.Add("@AllowAdjustPrice", allowAdjustPrice);
            parameters.Add("@MeasureInventoryItemStatus", measureInventoryItemStatus);
            parameters.Add("@IsShowOnMenu", isShowOnMenu);
            parameters.Add("@InActive", inActive);


            parameters.Add("@TotalRecord", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

            var listStore = _dbConnection.Query<InventoryItem>(procName, parameters, commandType: CommandType.StoredProcedure);
            
            entitiesPaging.Data = listStore.ToList();
            entitiesPaging.TotalRecord = parameters.Get<int>("@TotalRecord");

            return entitiesPaging;
        }

        public bool CheckInventoryItemCode(Guid? inventoryItemId, string inventoryItemCode, string functionName)
        {
            var sqlCheckExistCode = "";
            if (functionName == "Insert")
            {
                // Thực hiện lấy số lượng bản ghi có mã món trùng với mã món truyền vào
                sqlCheckExistCode = $"Select InventoryItemCode from InventoryItem where InventoryItem.InventoryItemCode = @InventoryItemCode";
            }
            else if (functionName == "Update")
            {
                // Thực hiện lấy số lượng bản ghi có mã món trùng với mã món truyền vào, loại bỏ bản ghi hiện tại
                sqlCheckExistCode = $"Select InventoryItemCode from InventoryItem where InventoryItem.InventoryItemCode = @InventoryItemCode and  InventoryItem.InventoryItemId != '{inventoryItemId}'";
            }

            // truyền vào tham số mã món - inventoryItemCode
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@InventoryItemCode", inventoryItemCode);

            // thực hiện truy vấn 
            var storeExistCode = _dbConnection
                .Query<string>(
                    sqlCheckExistCode,
                    dynamicParameters,
                    commandType: CommandType.Text);

            // kiểm tra kết quả:
            if (storeExistCode.AsList().Count > 0)
            {
                return true;
            }

            return false;
        }

        public InventoryItem GetInventoryItemByCode(string inventoryItemCode)
        {
            var procName = $"Proc_GetInventoryItemByCode";
            var parameters = new DynamicParameters();
            parameters.Add("@InventoryItemCode", inventoryItemCode);

            var item = _dbConnection.Query<InventoryItem>(
                procName, 
                parameters, 
                commandType: CommandType.StoredProcedure)
                .FirstOrDefault();

            return item;
        }
    }
}
