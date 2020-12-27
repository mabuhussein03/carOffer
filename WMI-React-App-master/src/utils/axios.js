import axios from 'axios';

export const headers = {
  'Content-Type': 'application/x-www-form-urlencoded'
};

let baseURL = `https://localhost:5001/api/`;


export const request = axios.create({
  baseURL
});
