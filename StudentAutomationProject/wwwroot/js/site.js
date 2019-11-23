// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
//Post İşlemleri
post = function (url, data, bsariCallback, hataCallbakc) {
    _ajaxJson(url, data, bsariCallback, hataCallbakc, "post");
};
_ajax = function (url, data, basariCallback, hataCallback, type) {
    $.ajaxSetup({
        cache: false
    });
    $.ajax({
        url: url,
        type: type,
        data: data,
        error: function (response) {

            if (hataCallback) {
                hataCallback(response);
            }

        },
        success: function (response) {

            if (basariCallback) {
                basariCallback(response);
            }
            else {
                if (!response.IsSuccess && response.HttpHataKodu && response.HttpHataKodu == 401) {
                    windows.location.href = LOGIN_URL;
                }
            }
        },
        complete: function () {
        },

    });
};

_ajaxJson = function (url, data, basariCallback, hataCallback, type) {
    $.ajaxSetup({
        cache: false
    });
    $.ajax({
        url: url,
        type: type,
        data: JSON.stringify(data),
        dataType: 'json',
        contentType: 'application/Json',
        traditional: true,
        error: function (response) {
            if (hataCallback) {
                hataCallback(response);
            }
            else {
                console.log(response);
            }
        },
        success: function (response) {
            if (basariCallback) {
                basariCallback(response);
            }
            else {
                if (!response.IsSuccess && response.HttpHataKodu && response.HttpHataKodu === 401) {
                    windows.location.href = LOGIN_URL;
                }
            }
        },
        complete: function () {
        },

    });
};


//comboboxlara bilgi getiren metod
function getJSONforComboBox(url, sendData, name, selectId) {
    $.getJSON(url, sendData,
        function (data) {
            var items = '';
            $(name).empty();
            $.each(data,
                function (i, row) {
                    items += "<option value = '" + row.Value + "'>" + row.Text + "</option>";
                });
            $(name).html(items);
            if (selectId != null || selectId != undefined) {
                $(name).val(selectId);
            }
        });
}
