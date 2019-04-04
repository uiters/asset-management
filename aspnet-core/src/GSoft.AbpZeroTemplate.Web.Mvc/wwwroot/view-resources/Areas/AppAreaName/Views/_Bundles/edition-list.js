var FeaturesTree = (function ($) {
    return function() {
        var $tree;

        function init($treeContainer) {
            $tree = $treeContainer;

            $tree.on('ready.jstree', function() {
                    customizeTreeNodes();
                })
                .on('redraw.jstree', function() {
                    customizeTreeNodes();
                })
                .on('after_open.jstree', function() {
                    customizeTreeNodes();
                })
                .on('create_node.jstree', function() {
                    customizeTreeNodes();
                }).on("changed.jstree", function(e, data) {
                    if (!data.node) {
                        return;
                    }

                    var childrenNodes;

                    if (data.node.state.selected) {
                        selectNodeAndAllParents($tree.jstree('get_parent', data.node));

                        childrenNodes = $.makeArray($tree.jstree('get_node', data.node).children);
                        $tree.jstree('select_node', childrenNodes);

                    } else {
                        childrenNodes = $.makeArray($tree.jstree('get_node', data.node).children);
                        $tree.jstree('deselect_node', childrenNodes);
                    }
                }).jstree({
                    "types": {
                        "default": {
                            "icon": "fa fa-folder m--font-warning"
                        },
                        "file": {
                            "icon": "fa fa-file  m--font-warning"
                        }
                    },
                    'checkbox': {
                        keep_selected_style: false,
                        three_state: false,
                        cascade: ''
                    },
                    plugins: ['checkbox', 'types']
                });

            function customizeTreeNodes() {
                $tree.find('.jstree-node').each(function () {
                    var $nodeLi = $(this);
                    var $nodeA = $nodeLi.find('.jstree-anchor');
                    var feature = JSON.parse($nodeLi.attr('data-feature'));
                    var featureValue = $nodeLi.attr('data-feature-value');

                    if (!feature || !feature.inputType) {
                        return;
                    }

                    if (feature.inputType.name == 'CHECKBOX') {
                        //no change for checkbox
                    } else if (feature.inputType.name == 'SINGLE_LINE_STRING') {
                        if (!$nodeLi.find('.feature-tree-textbox').length) {
                            $nodeA.find('.jstree-checkbox').hide();

                            var inputType = 'text';
                            if (feature.inputType.validator) {
                                if (feature.inputType.validator.name == 'NUMERIC') {
                                    inputType = 'number';
                                }
                            }

                            var $textbox = $('<input class="feature-tree-textbox" type="' + inputType + '" />')
                                .val(featureValue);

                            if (inputType == 'number') {
                                $textbox.attr('min', feature.inputType.validator.minValue);
                                $textbox.attr('max', feature.inputType.validator.maxValue);
                            } else {
                                if (feature.inputType.validator && feature.inputType.validator.name == 'STRING') {
                                    if (feature.inputType.validator.maxLength > 0) {
                                        $textbox.attr('maxlength', feature.inputType.validator.maxLength);
                                    }
                                    if (feature.inputType.validator.minLength > 0) {
                                        $textbox.attr('required', 'required');
                                    }
                                    if (feature.inputType.validator.regularExpression) {
                                        $textbox.attr('pattern', feature.inputType.validator.regularExpression);
                                    }
                                }
                            }

                            $textbox.on('input propertychange paste', function () {
                                if (isFeatureValueValid(feature, $textbox.val())) {
                                    $nodeLi.attr('data-feature-value', $textbox.val());
                                    $textbox.removeClass('feature-tree-textbox-invalid');
                                } else {
                                    $textbox.addClass('feature-tree-textbox-invalid');
                                }
                            });

                            $textbox.appendTo($nodeLi);
                        }
                    } else if (feature.inputType.name == 'COMBOBOX') {
                        if (!$nodeLi.find('.feature-tree-combobox').length) {
                            $nodeA.find('.jstree-checkbox').hide();

                            var $combobox = $('<select class="feature-tree-combobox" />');
                            _.each(feature.inputType.itemSource.items, function (opt) {
                                $('<option></option>')
                                    .attr('value', opt.value)
                                    .text(opt.displayText)
                                    .appendTo($combobox);
                            });

                            $combobox
                                .val(featureValue)
                                .on('change', function () {
                                    $nodeLi.attr('data-feature-value', $combobox.val());
                                })
                                .appendTo($nodeLi);
                        }
                    }
                });
            }
        };

        function selectNodeAndAllParents(node) {
            $tree.jstree('select_node', node, true);
            var parent = $tree.jstree('get_parent', node);
            if (parent) {
                selectNodeAndAllParents(parent);
            }
        };
        
        function isFeatureValueValid(feature, value) {
            if (!feature || !feature.inputType || !feature.inputType.validator) {
                return true;
            }

            var validator = feature.inputType.validator;
            if (validator.name == 'STRING') {
                if (value == undefined || value == null) {
                    return validator.allowNull;
                }

                if (typeof value != 'string') {
                    return false;
                }

                if (validator.minLength > 0 && value.length < validator.minLength) {
                    return false;
                }

                if (validator.maxLength > 0 && value.length > validator.maxLength) {
                    return false;
                }

                if (validator.regularExpression) {
                    return (new RegExp(validator.regularExpression)).test(value);
                }
            } else if (validator.name == 'NUMERIC') {
                var numValue = parseInt(value);

                if (isNaN(numValue)) {
                    return false;
                }

                var minValue = validator.minValue;
                if (minValue > numValue) {
                    return false;
                }

                var maxValue = validator.maxValue;
                if (maxValue > 0 && numValue > maxValue) {
                    return false;
                }
            }

            return true;
        }

        function isValid() {
            return $tree.find('.feature-tree-textbox-invalid').length <= 0;
        }

        function getFeatureValues() {
            var featureValues = [];

            $tree.find('.jstree-node').each(function() {
                var $nodeLi = $(this);
                var feature = JSON.parse($nodeLi.attr('data-feature'));
                if (!feature.inputType || feature.inputType.name == 'CHECKBOX') {
                    featureValues.push({
                        name: feature.name,
                        value: $tree.jstree('is_checked', $nodeLi) ? 'true' : 'false'
                    });
                } else {
                    featureValues.push({
                        name: feature.name,
                        value: $nodeLi.attr('data-feature-value')
                    });
                }
            });

            return featureValues;
        };

        return {
            init: init,
            getFeatureValues: getFeatureValues,
            isValid: isValid
        }
    }
})(jQuery);
(function () {

    app.modals.CreateOrEditEditionModal = function () {

        var _modalManager;
        var editionService = abp.services.app.edition;
        var $editionInformationForm = null;
        var featuresTree;

        this.init = function (modalManager) {
            _modalManager = modalManager;
            var $modal = _modalManager.getModal();

            featuresTree = new FeaturesTree();
            featuresTree.init($modal.find('.feature-tree'));

            var $editionItemsDiv = $modal.find('.edition-list');
            var $priceDivs = $modal.find('.SubscriptionPrice');
            var $trialDayCountDiv = $modal.find('.trial-day-count');
            var $waitingDayAfterExpireDiv = $modal.find('.waiting-day-after-expire');
            var $paidFeatures = $modal.find('.paid-features');
            var $monthlyPrice = $modal.find('.paid-features > .SubscriptionPrice input[name="MonthlyPrice"]');
            var $annualPrice = $modal.find('.paid-features > .SubscriptionPrice input[name="AnnualPrice"]');

            function toggleEditionItems() {
                if (!$modal.find('#EditEdition_ExpireAction_AssignEdition').is(':checked')) {
                    $editionItemsDiv.slideUp('fast');
                } else {
                    $editionItemsDiv.slideDown('fast');
                }
            }

            function togglePriceDivs() {
                if (!$modal.find('#EditEdition_IsPaid').is(':checked')) {
                    $priceDivs.slideUp('fast');
                    $paidFeatures.slideUp('fast');

                    $priceDivs.find('input').attr('required', false);
                } else {
                    $priceDivs.slideDown('fast');
                    $paidFeatures.slideDown('fast');

                    $priceDivs.find('input').attr('required', true);
                }
            }

            function toggleTrialDayCount() {
                if (!$modal.find('#EditEdition_IsTrialActive').is(':checked')) {
                    $trialDayCountDiv.slideUp('fast');
                } else {
                    $trialDayCountDiv.slideDown('fast');
                }
            }

            function toggleWaitingDayAfterExpire() {
                if (!$modal.find('#EditEdition_IsWaitingDayActive').is(':checked')) {
                    $waitingDayAfterExpireDiv.slideUp('fast');
                } else {
                    $waitingDayAfterExpireDiv.slideDown('fast');
                }
            }

            function createCurrencyInputs() {
                var opts = {
                    radixPoint: ".",
                    groupSeparator: ",",
                    digits: 2,
                    autoGroup: true,
                    prefix: '$ ',
                    rightAlign: false,
                    showMaskOnHover: false,
                    showMaskOnFocus: false,
                    placeholder: "_",
                    removeMaskOnSubmit: true,
                    autoUnmask: true
                };

                $monthlyPrice.inputmask("numeric", $.extend({}, opts));
                $annualPrice.inputmask("numeric", $.extend({}, opts));
            }

            $modal.find('input[name=ExpireAction]').change(function () {
                toggleEditionItems();
            });

            $modal.find('input[name=SubscriptionPrice]').change(function () {
                togglePriceDivs();
            });

            $modal.find('#EditEdition_IsTrialActive').change(function () {
                toggleTrialDayCount();
            });

            $modal.find('#EditEdition_IsWaitingDayActive').change(function () {
                toggleWaitingDayAfterExpire();
            });

            toggleEditionItems();
            togglePriceDivs();
            toggleTrialDayCount();
            toggleWaitingDayAfterExpire();
            createCurrencyInputs();

            $editionInformationForm = _modalManager.getModal().find('form[name=EditionInformationsForm]');
            $editionInformationForm.validate();
        };

        this.save = function () {
            if (!$editionInformationForm.valid()) {
                return;
            }

            if (!featuresTree.isValid()) {
                abp.message.warn(app.localize('InvalidFeaturesWarning'));
                return;
            }

            var edition = $editionInformationForm.serializeFormToObject();

            _modalManager.setBusy(true);
            editionService.createOrUpdateEdition({
                edition: edition,
                featureValues: featuresTree.getFeatureValues()
            }).done(function () {
                abp.notify.info(app.localize('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('app.createOrEditEditionModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();
(function () {
    $(function () {

        var _$editionsTable = $('#EditionsTable');
        var _editionService = abp.services.app.edition;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Editions.Create'),
            edit: abp.auth.hasPermission('Pages.Editions.Edit'),
            'delete': abp.auth.hasPermission('Pages.Editions.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'AppAreaName/Editions/CreateOrEditModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/AppAreaName/Views/Editions/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditEditionModal'
        });

        function deleteEdition(edition) {
            abp.message.confirm(
                app.localize('EditionDeleteWarningMessage', edition.displayName),
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _editionService.deleteEdition({
                            id: edition.id
                        }).done(function () {
                            getEditions();
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        };

        $('#CreateNewEditionButton').click(function () {
            _createOrEditModal.open();
        });

        abp.event.on('app.createOrEditEditionModalSaved', function () {
            getEditions();
        });

        var dataTable = _$editionsTable.DataTable({
            paging: false,
            listAction: {
                ajaxFunction: _editionService.getEditions
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
                    autoWidth: false,
                    defaultContent: '',
                    rowAction: {
                        text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                        items: [
                            {
                                text: app.localize('Edit'),
                                visible: function () {
                                    return _permissions.edit;
                                },
                                action: function (data) {
                                    _createOrEditModal.open({ id: data.record.id });
                                }
                            }, {
                                text: app.localize('Delete'),
                                visible: function () {
                                    return _permissions.delete;
                                },
                                action: function (data) {
                                    deleteEdition(data.record);
                                }
                            }
                        ]
                    }
                },
                {
                    targets: 2,
                    data: "displayName"
                },
                {
                    targets: 3,
                    data: "creationTime",
                    render: function (creationTime) {
                        return moment(creationTime).format('L');
                    }
                }
            ]
        });

        function getEditions() {
            dataTable.ajax.reload();
        }
    });
})();