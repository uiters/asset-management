$(function () {
    var demoUiComponentsService = abp.services.app.demoUiComponents;

    // 
    // date picker 
    //
    $('.date-picker').datetimepicker({
        locale: abp.localization.currentLanguage.name,
        format: 'L'
    });

    $('.test-btn-date-picker').click(function () {
        var $dateInput = $(this).closest('.input-group').find('input');

        demoUiComponentsService.sendAndGetDate(
            $dateInput.data("DateTimePicker").date().format("YYYY-MM-DDTHH:mm:ssZ")
        ).done(function (result) {
            abp.message.info(result.dateString, app.localize('PostedValue'));
            abp.notify.info(app.localize('SavedSuccessfully'));
        });
    });

    // 
    // datetime picker 
    //
    $('.datetime-picker').datetimepicker({
        locale: abp.localization.currentLanguage.name,
        format: 'L LT'
    });

    $('.test-btn-datetime-picker').click(function () {
        var $datetimeInput = $(this).closest('.input-group').find('input');

        demoUiComponentsService.sendAndGetDateTime(
            $datetimeInput.data("DateTimePicker").date().format("YYYY-MM-DDTHH:mm:ssZ")
        ).done(function (result) {
            abp.message.info(result.dateString, app.localize('PostedValue'));
            abp.notify.info(app.localize('SavedSuccessfully'));
        });
    });

    // 
    // daterange picker 
    //
    var selectedDateRange = {
        startDate: moment().add(-7, 'days').startOf('day'),
        endDate: moment().endOf('day')
    };

    $('.daterange-picker').daterangepicker(
        $.extend(true,
            app.createDateRangePickerOptions({
                allowFutureDate: true
            }),
            selectedDateRange),
        function (start, end, label) {
            selectedDateRange.startDate = start;
            selectedDateRange.endDate = end;
        });

    $('.test-btn-daterange-picker').click(function () {
        demoUiComponentsService.sendAndGetDateRange(
            selectedDateRange.startDate,
            selectedDateRange.endDate
        ).done(function (result) {
            abp.message.info(result.dateString, app.localize('PostedValue'));
            abp.notify.info(app.localize('SavedSuccessfully'));
        });
    });
});

$(function () {
    'use strict';
    // Change this to the location of your server-side upload handler:
    var url = abp.appPath + 'AppAreaName/DemoUiComponents/UploadFile';
    $('#fileupload').fileupload({
        url: url,
        dataType: 'json',
        maxFileSize: 999000,
        done: function (e, response) {

            var jsonResult = response.result;

            if (jsonResult.success) {
                var fileUrl = abp.appPath + 'AppAreaName/DemoUiComponents/GetFile?id=' + jsonResult.result.id + '&contentType=' + jsonResult.result.contentType;
                var uploadedFile = '<a href="' + fileUrl + '" target="_blank">' + app.localize('UploadedFile') + '</a><br/><br/>' + ' Free text: ' + jsonResult.result.defaultFileUploadTextInput;

                abp.libs.sweetAlert.config.info.html = true;
                abp.message.info(uploadedFile, app.localize('PostedData'));
                abp.notify.info(app.localize('SavedSuccessfully'));
            } else {
                abp.message.error(jsonResult.error.message);
            }
        },
        progressall: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progress .progress-bar').css(
                'width',
                progress + '%'
            );
        }
    }).prop('disabled', !$.support.fileInput)
        .parent().addClass($.support.fileInput ? undefined : 'disabled');
});

$(function () {
    var demoUiComponentsService = abp.services.app.demoUiComponents;

    // 
    // select2 initialize
    //
    $(".m-select2").select2({
        placeholder: 'Select',
        ajax: {
            url: abp.appPath + "api/services/app/DemoUiComponents/GetCountries",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    searchTerm: params.term, // search term
                    page: params.page
                };
            },
            processResults: function (data, params) {
                params.page = params.page || 1;

                return {
                    results: $.map(data.result, function (item) {
                        return {
                            text: item.name,
                            id: item.value
                        }
                    }),
                    pagination: {
                        more: (params.page * 30) < data.result.length
                    }
                };
            },
            cache: true
        },
        minimumInputLength: 1,
        language: abp.localization.currentCulture.name
    });

    // 
    // select2 initialize for tagging support
    //
    $(".select2-tagging").select2({
        ajax: {
            url: abp.appPath + "api/services/app/DemoUiComponents/GetCountries",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    searchTerm: params.term, // search term
                    page: params.page
                };
            },
            processResults: function (data, params) {
                params.page = params.page || 1;

                return {
                    results: $.map(data.result, function (item) {
                        return {
                            text: item.name,
                            id: item.value
                        }
                    }),
                    pagination: {
                        more: (params.page * 30) < data.result.length
                    }
                };
            },
            cache: true
        },
        minimumInputLength: 1,
        language: abp.localization.currentCulture.name,
        tags: true,
        tokenSeparators: [',', ' ']
    });

    // 
    // single select - post
    //
    $('.test-btn-select2-single').click(function () {
        var $selectElement = $('#select2SingleSelect');

        var input = [];
        input.push({
            name: $selectElement.text(),
            value: $selectElement.val()
        });

        demoUiComponentsService.sendAndGetSelectedCountries(
            input
        ).done(function (data) {
            var message = "";

            $.each(data, function (index, item) {
                message += '<div><strong>id</strong>: ' + item.value + ' - <strong>name</strong>: ' + item.name + '</div>';
            });

            abp.libs.sweetAlert.config.info.html = true;
            abp.message.info(message, app.localize('PostedValue'));
            abp.notify.info(app.localize('SavedSuccessfully'));
        });
    });

    // 
    // multi select - post
    //
    $('.test-btn-select2-multiple').click(function () {
        var $selectElement = $('#select2MultiSelect');

        var input = [];

        $.each($selectElement.select2('data'), function (index, item) {
            input.push({
                name: item.text,
                value: item.id
            });
        });

        demoUiComponentsService.sendAndGetSelectedCountries(
            input
        ).done(function (data) {
            var message = "";

            $.each(data, function (index, item) {
                message += '<div><strong>id</strong>: ' + item.value + ' - <strong>name</strong>: ' + item.name + '</div>';
            });

            abp.libs.sweetAlert.config.info.html = true;
            abp.message.info(message, app.localize('PostedValue'));
            abp.notify.info(app.localize('SavedSuccessfully'));
        });
    });

    // 
    // tag select - post
    //
    $('.test-btn-select2-tagging').click(function () {
        var $selectElement = $('#select2Tagging');

        var input = [];

        $.each($selectElement.select2('data'), function (index, item) {
            input.push({
                name: item.text,
                value: item.id
            });
        });

        demoUiComponentsService.sendAndGetSelectedCountries(
            input
        ).done(function (data) {
            var message = "";

            $.each(data, function (index, item) {
                message += '<div><strong>id</strong>: ' + item.value + ' - <strong>name</strong>: ' + item.name + '</div>';
            });

            abp.libs.sweetAlert.config.info.html = true;
            abp.message.info(message, app.localize('PostedValue'));
            abp.notify.info(app.localize('SavedSuccessfully'));
        });
    });
});
$(function () {
    var demoUiComponentsService = abp.services.app.demoUiComponents;

    // 
    // input mask initialize
    //
    $(".input-mask").inputmask({
        showMaskOnHover: false
    });

    // 
    // tag select - post
    //
    $('.test-btn-input-mask').click(function () {
        var $inputElement = $(this).closest('.input-group').find('.input-mask');

        demoUiComponentsService.sendAndGetValue(
            $inputElement.val()
        ).done(function (data) {
            abp.message.info(data.output, app.localize('PostedValue'));
            abp.notify.info(app.localize('SavedSuccessfully'));
        });
    });
});
$(function () {
    var demoUiComponentsService = abp.services.app.demoUiComponents;

    // 
    // summernote initialize
    //
    $('#summernote').summernote({
        height: "300px"
    });

    // 
    // tag select - post
    //
    $('.test-btn-summernote').click(function () {
        demoUiComponentsService.sendAndGetValue(
            $("#summernote").summernote('code')
        ).done(function (data) {
            abp.libs.sweetAlert.config.info.html = true;
            abp.message.info(data.output, app.localize('PostedValue'));
            abp.notify.info(app.localize('SavedSuccessfully'));
        });
    });
});