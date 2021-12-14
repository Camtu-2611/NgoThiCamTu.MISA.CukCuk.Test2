
//danh sách loại món
const TYPEFOODS = [
    {
        typeName: "Tất cả",
        value: ""
    },
    {
        typeName: "Món ăn",
        value: "Món ăn"
    },
    {
        typeName: "Đồ uống",
        value: "Đồ uống"
    },
    {
        typeName: "Set đồ ăn",
        value: "Set đồ ăn"
    },
    {
        typeName: "Combo",
        value: "Combo"
    },
    {
        typeName: "Set lẩu",
        value: "Set lẩu"
    },
    {
        typeName: "Mặt hàng khác",
        value: "Mặt hàng khác"
    }
]

const STATUSYESNO = [
    {
        statusName: "Có",
        value: "1"
    },
    {
        statusName: "Không",
        value: "0"
    }, {
        statusName: "Tất cả",
        value: ""
    }
]


const ACTIVE = [
    {
        status: "Có",
        value: "1"
    },
    {
        status: "Không",
        value: "0"
    }, {
        status: "Tất cả",
        value: ""
    }
]


const TYPE_MSG = {
    INSERT: "post",
    UPDATE: "put",
    REPLICA: "replica"
}

const KITCHEN_AREA = [
    "Bếp",
    "Bếp chung",
    "Bếp tầng 1",
    "Bếp tầng 2",
    "Bếp tầng 3",
    "Quầy",
    "Tiệm",
]

const UNIT = [
    "Cốc",
    "Bát",
    "Gói",
    "Suất",
    "Nồi",
    "Chiếc",
    "Thùng",
    "Lon",
    "Đĩa",
    "Ấm",
]

const FOOD_CATEGORY = [
    "Đồ uống",
    "Món Nhật",
    "Món Hàn",
    "Món Trung",
    "Món Việt",
    "Gà-chim",
    "Rau củ",
    "Dê",
    "Lẩu",
    "Tráng miệng",
    "Khai vị",
    "Hải sản",
    "Cá",
    "Heo",
    "Bò",
]
export default {
    TYPEFOODS,
    STATUSYESNO,
    FOOD_CATEGORY,
    KITCHEN_AREA,
    UNIT,
    TYPE_MSG,
    ACTIVE
}
