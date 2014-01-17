function getLocalStorageValue(key) {
    var jsonString = localStorage.getItem(key);
    var result;
    if (jsonString == null) {
        result = [];
    } else {
        result = JSON.parse(jsonString);
    }
    return result;
}

function setLocalStorageValue(key, value) {
    var jsonString = JSON.stringify(value);
    localStorage.setItem(key, jsonString);
}