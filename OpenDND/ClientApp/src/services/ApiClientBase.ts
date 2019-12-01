import Axios from 'axios'

const Client = Axios.create({
  baseURL: '/api/',
  timeout: 5000,
  withCredentials: true
})

export default Client
