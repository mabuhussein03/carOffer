import { request } from '../utils/axios';
import { getHeaders } from '../utils/common-methods';


export const getCountries = async () => {
    const propertyRes = await request.get(`wmi/getCountries`, {
        headers: getHeaders()
    });
    return propertyRes;
};

export const getWmi = async () => {
    const propertyRes = await request.get(`wmi/getall`, {
        headers: getHeaders()
    });
    return propertyRes;
};

export const searchWmi = async (filter, country) => {
    const propertyRes = await request.get(`wmi/search?filter=` + filter + `&country=` + country, {
        headers: getHeaders()
    });
    return propertyRes;
};
