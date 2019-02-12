import axios from "axios";

export default (initialConfig) => ({
    execute: ({method, url, headers, token, data}) => {
        console.log(data);
        
        const config = {
            method,
            // url: `${initialConfig.baseUrl}/${url}`,
            url,
            headers,
            data,
        };

        return axios(config);
    }
});