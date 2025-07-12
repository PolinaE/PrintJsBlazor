export function printJson(keys_array) {
    printJS({printable:  editor1.json_value, properties: keys_array, type: 'json'});
}

export function jsonIsArray() {
    var jsonVal = editor1.json_value;
    return Array.isArray(jsonVal);
}

export function doBeauty(inpValue) {
    editor1.value  = inpValue;
}

export function checkTextByPrintEditor() {
    editor_check.value = inp.value
    if (!editor_check.is_valid()){
        return false;
    }
    
    editor_check.value  = ``;
    return true;
}

export function getArrayKeys() {
    
    var jsonVal = editor1.json_value;
    var keys_array= Object.keys(jsonVal[0]);
    if (jsonVal.length > 1)
    {
        for (var i = 1; i < jsonVal.length; i++) 
            keys_array = keys_array.concat(Object.keys(jsonVal[i]));
    }
    return keys_array = [...new Set(keys_array)]
}