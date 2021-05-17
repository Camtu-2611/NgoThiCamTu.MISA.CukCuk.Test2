// thực thể food lưu thông tin của món
 const food = {
    inventoryItemCode :"",
    inventoryItemName : "",
    inventoryItemCategoryName: "",
    inventoryItemTypeName: "",
    unit: "",
    salePrice: 0,
    realPrice: 0,
    description: "",
    kitchen: "",
    imgUrl: "",
    isShowOnMenu: 0
}

// thực thể lưu thông tin sở thích phục vụ của một món
 const additionFood = {
    inventoryItemAdditionId: "",
    description: "",
    unitPrice: 0
}

// thực thể lưu thông tin filter 
 const filterFields = {
    inventoryItemTypeName:"",
    invenrotyItemCode:"",
    invenrotyItemName:"",
    invenrotyItemCategoryName:"",
    unit:"",
    salePrice: 0,
    realPrice: null,
    changeOutwardPrice: 0,
    allowAdjustPrice: 0,
    measureInventoryItemStatus: 0,
    isShowOnMenu: 0,
    inActive: 0
}

export default{
    food,
    additionFood,
    filterFields,
}