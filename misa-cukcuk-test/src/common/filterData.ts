// thực thể lưu thông tin filter 
export default interface filterFields {
    pageIndex: number,
    pageSize: number,
    inventoryItemTypeName: string,
    invenrotyItemCode: string,
    invenrotyItemName: string,
    invenrotyItemCategoryName: string,
    unit: string,
    salePrice: number,
    changeOutwardPrice: number,
    allowAdjustPrice: number,
    measureInventoryItemStatus: number,
    isShowOnMenu: number,
    inActive: number
}