function showAlert(message) {
 alert(message);
}

function printJson() {
    if (!editor1.is_valid()){
        alert(`JSON is not valid, please fix it`);
        editor1.value  = ``;
        return;
    }
    var jsonVal = editor1.json_value;
    if (!Array.isArray(jsonVal)){
        alert(`It works only with arrays`);
        return;
    }

    var keys_array= Object.keys(jsonVal[0]);
    if (jsonVal.length > 1)
    {
        for (var i = 1; i < jsonVal.length; i++) 
            keys_array = keys_array.concat(Object.keys(jsonVal[i]));
    }
    keys_array = [...new Set(keys_array)]
    printJS({printable:  editor1.json_value, properties: keys_array, type: 'json'});
}

function doBeauty() {
    editor1.value  = inp.value
    if (!editor1.is_valid()){
        alert(`JSON is not valid, please fix it`);
        editor1.value  = ``;
    }
    
}
