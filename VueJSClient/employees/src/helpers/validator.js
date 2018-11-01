function hasValue(value) {
    if (typeof value == 'undefined' || !value || value == '') {
        return false;
    }
    return true;
}

function IsNumeric(value) {
    var numbers = '0123456789';
    for (var i = 0; i < value.length; i++) {
        var num = value[i];
        var exists = (numbers.indexOf(num) >= 0);
        if (!exists) {
            return false;
        }
    }
    return true;
}

export default {
    hasValue,
    IsNumeric
}