// thực thể lưu thông tin filter 
export default interface filterFields {
    conditions?: Array<ConditionsFilter>,
    page: number,
    limit: number
}

export interface ConditionsFilter{
    field: string,
    value: string|number|null,
    type: string,
    operator: string,
}
