import axios from 'axios';


const api = axios.create( {
    baseURL: "http://localhost:5298/api/v1/"
}

)

export default api;