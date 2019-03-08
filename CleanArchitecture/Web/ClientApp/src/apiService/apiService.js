import axios from "axios";
import { assoc, isNil } from "ramda";

export default (initialConfig) => ({
    execute: ({method, url, headers, token, data}) => {
        
        const config = {
            method,
            url: `${initialConfig.baseUrl}/${url}`,
            headers: isNil(token) 
                ? headers
                : assoc('Authorization', `Bearer ${token}`, headers || {}),
            data,
        };

        return axios(config);
    }
});