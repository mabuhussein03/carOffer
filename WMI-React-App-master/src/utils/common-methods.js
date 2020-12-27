

export const getAccessToken = () => localStorage.getItem('tokens') || {};
export const getHeaders = () => ({
    common: {

    }
});