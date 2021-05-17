/**
 * Hàm định dạng giá tiền dạng xxx,xxx.xx
 * @param value giá trị cần định dạng
 * @returns 
 * CreatedBy: nctu 14.05.2021
 */
function formatMoney(value:number){
    // var patternRegex="/(\d)(?=(\d{3})+(?!\d))/g";
    const result = String(value).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
    
    return result;
}

export default { formatMoney,}