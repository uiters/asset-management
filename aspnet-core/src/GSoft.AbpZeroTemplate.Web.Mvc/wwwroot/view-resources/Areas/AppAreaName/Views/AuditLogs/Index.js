(function ($) {
    $(function () {

        var _$auditLogsTable = $('#AuditLogsTable');
        var _$auditLogFilterForm = $('#AuditLogFilterForm');

        var _$entityChangesTable = $('#EntityChangesTable');
        var _$entityChangeFilterForm = $('#EntityChangeFilterForm');

        var _auditLogService = abp.services.app.auditLog;

        var _selectedDateRangeEntityChange;
        var _selectedDateRangeAuditLog = _selectedDateRangeEntityChange = {
            startDate: moment().startOf('day'),
            endDate: moment().endOf('day')
        };

        _$auditLogFilterForm.find('input.date-range-picker').daterangepicker(
            $.extend(true, app.createDateRangePickerOptions(), _selectedDateRangeAuditLog),
            function (start, end) {
                _selectedDateRangeAuditLog.startDate = start.format('YYYY-MM-DDT00:00:00Z');
                _selectedDateRangeAuditLog.endDate = end.format('YYYY-MM-DDT23:59:59.999Z');

                getAuditLogs();
            });

        _$entityChangeFilterForm.find('input.date-range-picker').daterangepicker(
            $.extend(true, app.createDateRangePickerOptions(), _selectedDateRangeEntityChange),
            function (start, end) {
                _selectedDateRangeEntityChange.startDate = start.format('YYYY-MM-DDT00:00:00Z');
                _selectedDateRangeEntityChange.endDate = end.format('YYYY-MM-DDT23:59:59.999Z');

                getEntityChanges();
            });

        _auditLogService.getEntityHistoryObjectTypes()
            .done(function (result) {
                $.each(result, function (index, item) { // Iterates through a collection
                    $("#EntityTypeFullName").append( // Append an object to the inside of the select box
                        $("<option></option>") // Yes you can do this.
                            .text(item.name)
                            .val(item.value)
                    );
                });
            });

        var auditLogDataTable = _$auditLogsTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _auditLogService.getAuditLogs,
                inputFilter: function () {
                    return createAuditLogRequestParams();
                }
            },
            columnDefs: [
                {
                    className: 'control responsive',
                    orderable: false,
                    render: function () {
                        return '';
                    },
                    targets: 0
                },
                {
                    targets: 1,
                    data: null,
                    orderable: false,
                    defaultContent: '',
                    rowAction: {
                        element: $("<div/>")
                            .addClass("text-center")
                            .append($("<button/>")
                                .addClass("btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill")
                                .attr("title", app.localize("AuditLogDetail"))
                                .append($("<i/>").addClass("la la-search"))
                            ).click(function () {
                                showAuditLogDetails($(this).data());
                            })
                    }
                },
                {
                    targets: 2,
                    data: "exception",
                    orderable: false,
                    render: function (exception) {
                        var $div = $("<div/>").addClass("text-center");
                        if (exception) {
                            $div.append($("<i/>").addClass("fa fa-warning m--font-warning").attr("title", app.localize("HasError")));
                        } else {
                            $div.append($("<i/>").addClass("fa fa-check-circle m--font-success").attr("title", app.localize("Success")));
                        }

                        return $div[0].outerHTML;
                    }
                },
                {
                    targets: 3,
                    data: "executionTime",
                    render: function (executionTime) {
                        return moment(executionTime).format('YYYY-MM-DD HH:mm:ss');
                    }
                },
                {
                    targets: 4,
                    data: "userName"
                },
                {
                    targets: 5,
                    data: "serviceName"
                },
                {
                    targets: 6,
                    data: "methodName"
                },
                {
                    targets: 7,
                    data: "executionDuration",
                    render: function (executionDuration) {
                        return app.localize('Xms', executionDuration);
                    }
                },
                {
                    targets: 8,
                    data: "clientIpAddress",
                    orderable: false
                },
                {
                    targets: 9,
                    data: "clientName"
                },
                {
                    targets: 10,
                    data: "browserInfo",
                    render: function (browserInfo) {
                        return $("<span/>").text(abp.utils.truncateStringWithPostfix(browserInfo, 32))
                            .attr("title", browserInfo)[0].outerHTML;
                    }
                }
            ]
        });

        var entityChangeDataTable = _$entityChangesTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _auditLogService.getEntityChanges,
                inputFilter: function () {
                    return createEntityChangeRequestParams();
                }
            },
            columnDefs: [
                {
                    className: 'control responsive',
                    orderable: false,
                    render: function () {
                        return '';
                    },
                    targets: 0
                },
                {
                    targets: 1,
                    data: null,
                    orderable: false,
                    defaultContent: '',
                    rowAction: {
                        element: $("<div/>")
                            .addClass("text-center")
                            .append($("<button/>")
                                .addClass("btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill")
                                .attr("title", app.localize("EntityChangeDetail"))
                                .append($("<i/>").addClass("la la-search"))
                            ).click(function () {
                                showEntityChangeDetails($(this).data());
                            })
                    }
                },
                {
                    targets: 2,
                    data: "changeTypeName",
                    orderable: false,
                    render: function (changeTypeName) {
                        return app.localize(changeTypeName);
                    }
                },
                {
                    targets: 3,
                    data: "entityTypeFullName",
                    render: function (entityTypeFullName) {
                        return app.localize(entityTypeFullName);
                    }
                },
                {
                    targets: 4,
                    data: "userName"
                },
                {
                    targets: 5,
                    data: "changeTime",
                    render: function (changeTime) {
                        return moment(changeTime).format('YYYY-MM-DD HH:mm:ss');
                    }
                }
            ]
        });

        function createAuditLogRequestParams() {
            var prms = {};
            _$auditLogFilterForm.serializeArray().map(function (x) { prms[abp.utils.toCamelCase(x.name)] = x.value; });
            return $.extend(prms, _selectedDateRangeAuditLog);
        }

        function createEntityChangeRequestParams() {
            var prms = {};
            _$entityChangeFilterForm.serializeArray().map(function (x) { prms[abp.utils.toCamelCase(x.name)] = x.value; });
            return $.extend(prms, _selectedDateRangeEntityChange);
        }

        function getAuditLogs() {
            auditLogDataTable.ajax.reload();
        }

        function getEntityChanges() {
            entityChangeDataTable.ajax.reload();
        }

        function getFormattedParameters(parameters) {
            try {
                var json = JSON.parse(parameters);
                return JSON.stringify(json, null, 4);
            } catch (e) {
                return parameters;
            }
        }

        function showEntityChangeDetails(entityChange) {
            var entityChangeDetailModal = new app.ModalManager({
                viewUrl: abp.appPath + 'AppAreaName/AuditLogs/EntityChangeDetailModal',
                modalClass: 'EntityChangeDetailModal'
            });

            entityChangeDetailModal.open({ entityChangeListDto: entityChange });
        }

        function showAuditLogDetails(auditLog) {
            $('#AuditLogDetailModal_UserName').html(auditLog.userName);
            $('#AuditLogDetailModal_ClientIpAddress').html(auditLog.clientIpAddress);
            $('#AuditLogDetailModal_ClientName').html(auditLog.clientName);
            $('#AuditLogDetailModal_BrowserInfo').html(auditLog.browserInfo);
            $('#AuditLogDetailModal_ServiceName').html(auditLog.serviceName);
            $('#AuditLogDetailModal_MethodName').html(auditLog.methodName);
            $('#AuditLogDetailModal_ExecutionTime').html(moment(auditLog.executionTime).fromNow() + ' (' + moment(auditLog.executionTime).format('YYYY-MM-DD hh:mm:ss') + ')');
            $('#AuditLogDetailModal_Duration').html(app.localize('Xms', auditLog.executionDuration));
            $('#AuditLogDetailModal_Parameters').html(getFormattedParameters(auditLog.parameters));

            if (auditLog.impersonatorUserId) {
                $('#AuditLogDetailModal_ImpersonatorInfo').show();
            } else {
                $('#AuditLogDetailModal_ImpersonatorInfo').hide();
            }

            if (auditLog.exception) {
                $('#AuditLogDetailModal_Success').hide();
                $('#AuditLogDetailModal_Exception').show();
                $('#AuditLogDetailModal_Exception').html(auditLog.exception);
            } else {
                $('#AuditLogDetailModal_Exception').hide();
                $('#AuditLogDetailModal_Success').show();
            }

            if (auditLog.customData) {
                $('#AuditLogDetailModal_CustomData_None').hide();
                $('#AuditLogDetailModal_CustomData').show();
                $('#AuditLogDetailModal_CustomData').html(auditLog.customData);
            } else {
                $('#AuditLogDetailModal_CustomData').hide();
                $('#AuditLogDetailModal_CustomData_None').show();
            }

            $('#AuditLogDetailModal').modal('show');
        }

        $('#RefreshAuditLogsButton').click(function (e) {
            e.preventDefault();
            getAuditLogs();
        });

        $('#RefreshEntityChangesButton').click(function (e) {
            e.preventDefault();
            getEntityChanges();
        });

        $('#ExportAuditLogsToExcelButton').click(function (e) {
            e.preventDefault();
            _auditLogService.getAuditLogsToExcel(createAuditLogRequestParams())
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        $('#ExportEntityChangesToExcelButton').click(function (e) {
            e.preventDefault();
            _auditLogService.getEntityChangesToExcel(createEntityChangeRequestParams())
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        $('#ShowAdvancedFiltersSpan').click(function () {
            $('#ShowAdvancedFiltersSpan').hide();
            $('#HideAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideDown();
        });

        $('#HideAdvancedFiltersSpan').click(function () {
            $('#HideAdvancedFiltersSpan').hide();
            $('#ShowAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideUp();
        });

        _$auditLogFilterForm.keydown(function (e) {
            if (e.which === 13) {
                e.preventDefault();
                getAuditLogs();
            }
        });

        _$entityChangeFilterForm.keydown(function (e) {
            if (e.which === 13) {
                e.preventDefault();
                getEntityChanges();
            }
        });
    });
})(jQuery);