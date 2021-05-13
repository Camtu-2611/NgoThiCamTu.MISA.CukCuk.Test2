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
    public class InventoryItemAdditionRepository : BaseRepository<InventoryItemAddition>, IInventoryItemAdditionRepository
    {
        public IEnumerable<InventoryItemAddition> GetInventoryItemAdditionByInventoryItemId(Guid inventoryItemId)
        {
            var storeName = $"Proc_GetInventoryItemAdditionByInventoryItemId";

            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdParamName = $"@InventoryItemId";
            dynamicParameters.Add(storeGetByIdParamName, inventoryItemId);

            var entity = _dbConnection.Query<InventoryItemAddition>(
                storeName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure);

            return entity;
        }
    }
}
