import axios from "axios";
import { assoc, isNil } from "ramda";

export default (initialConfig) => ({
    execute: ({method, url, headers, token, data}) => {
        console.log(data);
        token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIxMDA1IiwiZG9jdG9ySWQiOiIxMDAzIiwicGF0aWVudElkIjoiMTAwNSIsImV4cCI6MTU4MjAzMTI3MCwiaXNzIjoieW91cmRvbWFpbi5jb20iLCJhdWQiOiJ5b3VyZG9tYWluLmNvbSJ9.OpCgNXmR3FXJyxUtG_DQv1EQ-_5z5Qp1qg5racYD6Jk"; // todo
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