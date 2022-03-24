import axios from "axios";
const api = axios.create({
  baseURL: "https://localhost:44372/",
});

api.interceptors.request.use(
  (config) => {
    const jwtToken = sessionStorage.getItem("jwt");
    config.headers.authorization = `Bearer ${jwtToken}`;
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default api;
