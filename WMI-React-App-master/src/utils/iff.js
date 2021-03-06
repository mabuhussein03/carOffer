const iff = function (condition, trueRet, falseRet) {
    if (condition === true) {
        if (typeof trueRet === 'function') {
            return trueRet();
        }
        return trueRet;
    } else {
        if (typeof falseRet === 'function') {
            return falseRet();
        }
        return falseRet;
    }
};

export default iff;