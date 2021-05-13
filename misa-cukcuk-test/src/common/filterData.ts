// thực thể lưu thông tin filter 
export default interface filterFields {
    inventoryItemTypeName: string,
    invenrotyItemCode: string,
    invenrotyItemName: string,
    invenrotyItemCategoryName: string,
    unit: string,
    salePrice: number,
    realPrice: number,
    changeOutwardPrice: string,
    allowAdjustPrice: string,
    measureInventoryItemStatus: string,
    isShowOnMenu: string,
    inActive: number
}