import axios from 'axios';

const baseDomain = "http://localhost:14139";
const baseUrl = `${baseDomain}/api/v1/`;

export default axios.create({
    baseURL: baseUrl,
})