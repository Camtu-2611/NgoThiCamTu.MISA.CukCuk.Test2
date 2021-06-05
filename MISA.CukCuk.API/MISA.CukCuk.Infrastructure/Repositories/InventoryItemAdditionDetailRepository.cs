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
    public class InventoryItemAdditionDetailRepository : BaseRepository<InventoryItemAdditionDetail>, IInventoryItemAdditionDetailRepository
    {
        public int DeleteInventoryItemAdditionDetail(Guid inventoryItemId, Guid inventoryItemAdditionId)
        {
            var procName = $"Proc_DeleteInventoryItemDetail";

            var parameters = new DynamicParameters();
            parameters.Add("@InventoryItemId", inventoryItemId);
            parameters.Add("@InventoryItemAdditionId", inventoryItemAdditionId);

            var rowaffects = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);

            return rowaffects;
        }

    }
}
