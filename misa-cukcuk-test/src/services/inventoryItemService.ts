import Service from './baseService';
import filterData from '../common/filterData';
const resource = "/inventoryitems";
export default {
    get() {
        return Service.get(`${resource}`);
    },
    getpaging(pageIndex: number, pageSize: number, dataFilter: filterData) {
        return Service.get(`${resource}/paging?pageIndex=${pageIndex}
                            &pageSize=${pageSize}
                            &inventoryItemTypeName=${dataFilter.inventoryItemTypeName}
                            &inventoryItemCode=${dataFilter.invenrotyItemCode}
                            &inventoryItemName=${dataFilter.invenrotyItemName}
                            &inventoryItemCategoryName=${dataFilter.invenrotyItemCategoryName}
                            &unit=${dataFilter.unit}
                            &salePrice=${dataFilter.salePrice}
                            &changeOutwardPrice=${dataFilter.changeOutwardPrice}
                            &allowAdjustPrice=${dataFilter.allowAdjustPrice}
                            &measureInventoryItemStatus=${dataFilter.measureInventoryItemStatus}
                            &isShowOnMenu=${dataFilter.isShowOnMenu}
                            &inActive=${dataFilter.inActive}`);
    },
    getById(itemId:string){
        return Service.get(`${resource}/${itemId}`);
    },
    // post(payload: any){
    //     return Service.post(`${resource}`, payload);
    // },
    // put(itemId: string, payload:any){
    //     return Service.put(`${resource}/${itemId}`, payload);
    // },
    delete(itemId:string){
        return Service.delete(`${resource}/${itemId}`);
    },
}