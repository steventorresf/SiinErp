function fnGet(url, data) {
    $.get(url + data, function (data, status) {
        return data;
    });
}