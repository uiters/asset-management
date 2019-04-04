(function () {
    $(function () {
        var _tenantDashboardService = abp.services.app.tenantDashboard;
        var salesSummaryDatePeriod = {
            daily: 1,
            weekly: 2,
            monthly: 3
        };

        var initDashboardTopStats = function (totalProfit, newFeedbacks, newOrders, newUsers) {
            //Dashboard top stats => CounterUp: https://github.com/bfintal/Counter-Up

            $("#totalProfit").text(totalProfit);
            $("#newFeedbacks").text(newFeedbacks);
            $("#newOrders").text(newOrders);
            $("#newUsers").text(newUsers);
        };

        var initSalesSummaryChart = function (salesSummaryData, totalSales, revenue, expenses, growth) {
            //Sales summary => MorrisJs: https://github.com/morrisjs/morris.js/

            var SalesSummaryChart = function (element) {
                var instance = null;

                var init = function (data) {
                    return new Morris.Area({
                        element: element,
                        padding: 0,
                        behaveLikeLine: false,
                        gridEnabled: false,
                        gridLineColor: false,
                        axes: false,
                        fillOpacity: 1,
                        data: data,
                        lineColors: ['#399a8c', '#92e9dc'],
                        xkey: 'period',
                        ykeys: ['sales', 'profit'],
                        labels: ['Sales', 'Profit'],
                        pointSize: 0,
                        lineWidth: 0,
                        hideHover: 'auto',
                        resize: true
                    });
                }

                var refresh = function (datePeriod) {
                    var self = this;
                    _tenantDashboardService
                        .getSalesSummary({
                            salesSummaryDatePeriod: datePeriod
                        })
                        .done(function (result) {
                            self.graph.setData(result.salesSummary);
                            self.graph.redraw();
                        });
                };

                var draw = function (data) {
                    if (!this.graph) {
                        this.graph = init(data);
                    } else {
                        this.graph.setData(data);
                        this.graph.redraw();
                    }
                };

                return {
                    draw: draw,
                    refresh: refresh,
                    graph: instance
                }
            };

            $("#salesStatistics").show();
            var salesSummary = new SalesSummaryChart("salesStatistics");
            salesSummary.draw(salesSummaryData);

            $("input[name='SalesSummaryDateInterval'").change(function () {
                salesSummary.refresh(this.value);
            });

            $("#totalSales").text(totalSales);
            $("#revenue").text(revenue);
            $("#expenses").text(expenses);
            $("#growth").text(growth);
            $("#salesStatisticsLoading").hide();
        };

        var initGeneralStats = function (transactionPercent, newVisitPercent, bouncePercent) {
            //General stats =>  EasyPieChart: https://rendro.github.io/easy-pie-chart/

            var init = function (transactionPercent, newVisitPercent, bouncePercent) {
                $("#transactionPercent").attr("data-percent", transactionPercent);
                $("#transactionPercent span").text(transactionPercent);
                $("#newVisitPercent").attr("data-percent", newVisitPercent);
                $("#newVisitPercent span").text(newVisitPercent);
                $("#bouncePercent").attr("data-percent", bouncePercent);
                $("#bouncePercent span").text(bouncePercent);
                $(".easy-pie-chart-loading").hide();
            }

            var refreshGeneralStats = function (transactionPercent, newVisitPercent, bouncePercent) {
                $('#transactionPercent').data('easyPieChart').update(transactionPercent);
                $("#transactionPercent span").text(transactionPercent);
                $('#newVisitPercent').data('easyPieChart').update(newVisitPercent);
                $("#newVisitPercent span").text(newVisitPercent);
                $('#bouncePercent').data('easyPieChart').update(bouncePercent);
                $("#bouncePercent span").text(bouncePercent);
            };

            var createPieCharts = function () {
                $('.easy-pie-chart .number.transactions').easyPieChart({
                    animate: 1000,
                    size: 75,
                    lineWidth: 3,
                    barColor: "#ffb822"
                });

                $('.easy-pie-chart .number.visits').easyPieChart({
                    animate: 1000,
                    size: 75,
                    lineWidth: 3,
                    barColor: "#36a3f7"
                });

                $('.easy-pie-chart .number.bounce').easyPieChart({
                    animate: 1000,
                    size: 75,
                    lineWidth: 3,
                    barColor: "#f4516c"
                });
            }

            $("#generalStatsReload").click(function () {
                _tenantDashboardService
                    .getGeneralStats({})
                    .done(function (result) {
                        refreshGeneralStats(result.transactionPercent, result.newVisitPercent, result.bouncePercent);
                    });
            });

            init(transactionPercent, newVisitPercent, bouncePercent);
            createPieCharts();
        };

        //== Daily Sales chart.
        //** Based on Chartjs plugin - http://www.chartjs.org/
        var initDailySales = function (data) {
            var dayLabels = [];
            for (var day = 1; day <= data.length; day++) {
                dayLabels.push("Day " + day);
            }

            var chartData = {
                labels: dayLabels,
                datasets: [{
                    //label: 'Dataset 1',
                    backgroundColor: mUtil.getColor('success'),
                    data: data
                }, {
                    //label: 'Dataset 2',
                    backgroundColor: '#f3f3fb',
                    data: data
                }]
            };

            var chartContainer = $('#m_chart_daily_sales');

            if (chartContainer.length === 0) {
                return;
            }

            var chart = new Chart(chartContainer, {
                type: 'bar',
                data: chartData,
                options: {
                    title: {
                        display: false,
                    },
                    tooltips: {
                        intersect: false,
                        mode: 'nearest',
                        xPadding: 10,
                        yPadding: 10,
                        caretPadding: 10
                    },
                    legend: {
                        display: false
                    },
                    responsive: true,
                    maintainAspectRatio: false,
                    barRadius: 4,
                    scales: {
                        xAxes: [{
                            display: false,
                            gridLines: false,
                            stacked: true
                        }],
                        yAxes: [{
                            display: false,
                            stacked: true,
                            gridLines: false
                        }]
                    },
                    layout: {
                        padding: {
                            left: 0,
                            right: 0,
                            top: 0,
                            bottom: 0
                        }
                    }
                }
            });
        }

        var initRegionalStats = function () {

            _initSparklineChart = function(src, data, color, border) {
                if (src.length === 0) {
                    return;
                }

                var config = {
                    type: 'line',
                    data: {
                        labels: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October"],
                        datasets: [{
                            label: "",
                            borderColor: color,
                            borderWidth: border,

                            pointHoverRadius: 4,
                            pointHoverBorderWidth: 12,
                            pointBackgroundColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                            pointBorderColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                            pointHoverBackgroundColor: mUtil.getColor('danger'),
                            pointHoverBorderColor: Chart.helpers.color('#000000').alpha(0.1).rgbString(),
                            fill: false,
                            data: data,
                        }]
                    },
                    options: {
                        title: {
                            display: false,
                        },
                        tooltips: {
                            enabled: false,
                            intersect: false,
                            mode: 'nearest',
                            xPadding: 10,
                            yPadding: 10,
                            caretPadding: 10
                        },
                        legend: {
                            display: false,
                            labels: {
                                usePointStyle: false
                            }
                        },
                        responsive: true,
                        maintainAspectRatio: true,
                        hover: {
                            mode: 'index'
                        },
                        scales: {
                            xAxes: [{
                                display: false,
                                gridLines: false,
                                scaleLabel: {
                                    display: true,
                                    labelString: 'Month'
                                }
                            }],
                            yAxes: [{
                                display: false,
                                gridLines: false,
                                scaleLabel: {
                                    display: true,
                                    labelString: 'Value'
                                },
                                ticks: {
                                    beginAtZero: true
                                }
                            }]
                        },

                        elements: {
                            point: {
                                radius: 4,
                                borderWidth: 12
                            },
                        },

                        layout: {
                            padding: {
                                left: 0,
                                right: 10,
                                top: 5,
                                bottom: 0
                            }
                        }
                    }
                };

                return new Chart(src, config);
            };

            var refreshInitregionalStats = function () {
                _tenantDashboardService
                    .getRegionalStats({})
                    .done(function (result) {
                        var $tableBody = $('#region_statistics_content table tbody');
                        for (var rowIndex = 0; rowIndex < result.stats.length; rowIndex++) {
                            var stat = result.stats[rowIndex];
                            var $tr = $('<tr></tr>').append(
                                $(
                                    '<td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check">' + 
                                        '<span style="width: 40px;">'+
                                            '<label class="m-checkbox m-checkbox--solid m-checkbox--single m-checkbox--brand" style="margin-bottom:-18px;">' +
                                                '<input type = "checkbox" > <span></span>' +
                                            '</label>' +
                                        '</span>'+
                                    '</td>'
                                ),
                                $('<td>' + stat.countryName + '</td>'),
                                $('<td>$' + stat.sales.toFixed(2) + '</td>'),
                                $(
                                    '<td>' +
                                        '<div class="m-widget11__chart" style="height:50px; width: 100px">' +
                                            '<iframe class="chartjs-hidden-iframe" tabindex="-1" style="display: block; overflow: hidden; border: 0px; margin: 0px; top: 0px; left: 0px; bottom: 0px; right: 0px; height: 100%; width: 100%; position: absolute; pointer-events: none; z-index: -1;"></iframe>' +
                                            '<canvas class="m_chart_sales_by_region" style="display: block; width: 100px; height: 50px;" width="100" height="50"></canvas>' +
                                        '</div>' +
                                    '</td>'
                                ),
                                $('<td>$' + stat.averagePrice.toFixed(2) + '</td>'),
                                $('<td>$' + stat.totalPrice.toFixed(2) + '</td>')
                            );

                            $tableBody.append($tr);
                        }

                        var colors = ['accent', 'danger', 'success', 'warning'];
                        var $canvasItems = $('canvas.m_chart_sales_by_region');
                        for (var statIndex = 0; statIndex < $canvasItems.length; statIndex++) {
                            var $canvas = $canvasItems[statIndex];
                            self._initSparklineChart($canvas, result.stats[statIndex].change, mUtil.getColor(colors[statIndex % 4]), 2);
                        }
                    });
            };

            refreshInitregionalStats();
        };

        //== Profit Share Chart.
        //** Based on Chartist plugin - https://gionkunz.github.io/chartist-js/index.html
        var profitShare = function (data) {
            var $chart = $('#m_chart_profit_share');
            if ($chart.length === 0) {
                return;
            }

            var $chartItems = $chart.closest('.m-widget14').find('.m-widget14__legend-text');

            $($chartItems[0]).text(data[0] + '% Product Sales');
            $($chartItems[1]).text(data[1] + '% Online Courses');
            $($chartItems[2]).text(data[2] + '% Custom Development');

            var chart = new Chartist.Pie('#m_chart_profit_share', {
                series: [{
                    value: data[0],
                    className: 'custom',
                    meta: {
                        color: mUtil.getColor('brand')
                    }
                },
                {
                    value: data[1],
                    className: 'custom',
                    meta: {
                        color: mUtil.getColor('accent')
                    }
                },
                {
                    value: data[2],
                    className: 'custom',
                    meta: {
                        color: mUtil.getColor('warning')
                    }
                }
                ],
                labels: [1, 2, 3]
            }, {
                    donut: true,
                    donutWidth: 17,
                    showLabel: false
                });

            chart.on('draw', function (data) {
                if (data.type === 'slice') {
                    // Get the total path length in order to use for dash array animation
                    var pathLength = data.element._node.getTotalLength();

                    // Set a dasharray that matches the path length as prerequisite to animate dashoffset
                    data.element.attr({
                        'stroke-dasharray': pathLength + 'px ' + pathLength + 'px'
                    });

                    // Create animation definition while also assigning an ID to the animation for later sync usage
                    var animationDefinition = {
                        'stroke-dashoffset': {
                            id: 'anim' + data.index,
                            dur: 1000,
                            from: -pathLength + 'px',
                            to: '0px',
                            easing: Chartist.Svg.Easing.easeOutQuint,
                            // We need to use `fill: 'freeze'` otherwise our animation will fall back to initial (not visible)
                            fill: 'freeze',
                            'stroke': data.meta.color
                        }
                    };

                    // If this was not the first slice, we need to time the animation so that it uses the end sync event of the previous animation
                    if (data.index !== 0) {
                        animationDefinition['stroke-dashoffset'].begin = 'anim' + (data.index - 1) + '.end';
                    }

                    // We need to set an initial value before the animation starts as we are not in guided mode which would do that for us

                    data.element.attr({
                        'stroke-dashoffset': -pathLength + 'px',
                        'stroke': data.meta.color
                    });

                    // We can't use guided mode as the animations need to rely on setting begin manually
                    // See http://gionkunz.github.io/chartist-js/api-documentation.html#chartistsvg-function-animate
                    data.element.animate(animationDefinition, false);
                }
            });
        }

        var initMemberActivity = function () {
            var refreshMemberActivity = function () {
                _tenantDashboardService
                    .getMemberActivity({})
                    .done(function (result) {
                        $("#memberActivityTable tbody>tr").each(function (index) {
                            var cells = $(this).find("td");
                            var $link = $("<a/>")
                                .attr("href", "javascript:;")
                                .addClass("primary-link")
                                .text(result.memberActivities[index].name);

                            $(cells[1]).empty().append($link);
                            $(cells[2]).html(result.memberActivities[index].cases);
                            $(cells[3]).html(result.memberActivities[index].closed);
                            $(cells[4]).html(result.memberActivities[index].rate);
                            $(cells[5]).html(result.memberActivities[index].rate);
                            $(cells[6]).html(result.memberActivities[index].earnings);
                        });
                    });
            };

            $("#refreshMemberActivityButton").click(function () {
                refreshMemberActivity();
            });

            refreshMemberActivity();
        };

        var getDashboardData = function () {
            _tenantDashboardService
                .getDashboardData({
                    salesSummaryDatePeriod: salesSummaryDatePeriod.daily
                })
                .done(function (result) {
                    initSalesSummaryChart(result.salesSummary, result.totalSales, result.revenue, result.expenses, result.growth);
                    initDashboardTopStats(result.totalProfit, result.newFeedbacks, result.newOrders, result.newUsers);
                    initDailySales(result.dailySales);
                    initGeneralStats(result.transactionPercent, result.newVisitPercent, result.bouncePercent);
                    profitShare(result.profitShares);
                    $(".counterup").counterUp();
                });
        };

        initRegionalStats();
        initMemberActivity();
        getDashboardData();
    });
})();