import Service from './baseService';
import filterData from '../common/filterData';
import axios from 'axios';
const resource = "/menu";
const optionAxios = {
    headers: {
        'Access-Control-Allow-Origin': '*',
        'Content-Type': 'application/x-www-form-urlencoded'
    }
}
export default {
    get(filterdata: filterData) {
        return axios.get('/menu', {
            params: {
              conditions: JSON.stringify(filterdata.conditions) ?? "",
              page: filterdata.page,
              limit: filterdata.limit
            }
          });
    },
    getById(itemCode:string){
        return Service.get(`${resource}/${itemCode}`,optionAxios);
    },
    post(payload: any){
        console.log("payload",payload)
        return Service.post(`${resource}`, payload, optionAxios);
    },
    put(itemCode: string, payload:any){
        return Service.put(`${resource}/${itemCode}`, payload, optionAxios);
    },
    delete(itemCode:string){
        return Service.delete(`${resource}/${itemCode}`);
    },
    getByCode(itemCode: string){
        return Service.get(`${resource}/bycode/${itemCode}`);
    }
}