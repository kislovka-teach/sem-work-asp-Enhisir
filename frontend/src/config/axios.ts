import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5224/",
});

export default api;
