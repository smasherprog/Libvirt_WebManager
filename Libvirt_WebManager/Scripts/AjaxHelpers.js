var Ajax = {
    POST : function(url, data){
        return $.ajax({
            url: url,
            type: "POST",
            data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    },
    GET: function (url, callback) {
        return $.getJSON(url, callback);
    },
    PUT: function (url, data) {
        return $.ajax({
            url: url,
            type: "PUT",
            data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    },
    DELETE: function (url, data) {
        return $.ajax({
            url: url,
            type: "PUT",
            data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
};