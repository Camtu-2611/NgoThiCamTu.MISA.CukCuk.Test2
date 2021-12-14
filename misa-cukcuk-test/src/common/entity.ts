// thực thể food lưu thông tin của món
 const food = {
    foodCode :"",
    foodName : "",
    inventoryItemCategoryName: "",
    inventoryItemTypeName: "Món khác",
    unit: "",
    salePrice: "",
    realPrice: "",
    description: "",
    kitchen: "",
    imgUrl: "",
    isShowOnMenu: "",
    inActive:""
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
    foodCode:"",
    foodName:"",
    inventoryItemCategoryName:"",
    unit:"",
    salePrice: null,
    realPrice: null,
    isShowOnMenu: "",
    inActive: ""
}

export default{
    food,
    additionFood,
    filterFields,
}