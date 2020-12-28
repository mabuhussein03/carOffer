import axios from 'axios';

export const headers = {
  'Content-Type': 'application/x-www-form-urlencoded'
};

let baseURL = `${process.env.REACT_APP_API_URL}`

export const request = axios.create({
  baseURL
});
