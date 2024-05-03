import axios from "axios";


export const HttpService = axios.create({

    baseURL: 'http://ajuric1.runasp.net/api/v1',
    headers: {
        'Content-Type' : 'application/json'
    }


});