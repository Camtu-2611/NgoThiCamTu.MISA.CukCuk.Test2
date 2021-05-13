
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
        statusName: "",
        value: ""
    },
    {
        statusName: "Có",
        value: 1
    },
    {
        statusName: "Không",
        value: 0
    },
]

const TYPE_MSG={
    INSERT:"post",
    UPDATE:"put",
    REPLICA:"replicat"
}
export default {
    TYPEFOODS,
    STATUSYESNO,
}
