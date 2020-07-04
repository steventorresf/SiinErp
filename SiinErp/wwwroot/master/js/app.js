(function () {
    'use-strict';

    var app = angular.module('app', [
        //'ui.highlight',
        'ui.grid',
        'ui.grid.selection',
        'ui.grid.autoResize',
        'ui.grid.edit',
        'ngSanitize',
        'ui.select',
        'ngCookies',
        'angular-growl',
        'ngAnimate'
    ]);

    app.directive('datepicker', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            compile: function () {
                return {
                    pre: function (scope, element, attrs, ngModelCtrl) {
                        console.log(ngModelCtrl);
                        var format, dateObj, viewmode;
                        format = (!attrs.dpFormat) ? 'd/m/yyyy' : attrs.dpFormat;
                        viewmode = (!attrs.bsdatepickerviewmode) ? 'days' : attrs.bsdatepickerviewmode;
                        if (!attrs.initDate && !attrs.dpFormat) {
                            // If there is no initDate attribute than we will get todays date as the default
                            dateObj = new Date();
                            scope[attrs.ngModel] = dateObj.getDate() + '/' + (dateObj.getMonth() + 1) + '/' + dateObj.getFullYear();
                        } else if (!attrs.initDate) {
                            // Otherwise set as the init date
                            scope[attrs.ngModel] = attrs.initDate;
                        } else {
                            // I could put some complex logic that changes the order of the date string I
                            // create from the dateObj based on the format, but I'll leave that for now
                            // Or I could switch case and limit the types of formats...
                        }

                        // Initialize the date-picker
                        $(element).datepicker({
                            format: format,
                            viewMode: viewmode,
                            minViewMode: viewmode,
                            language: 'es',
                        }).on('changeDate', function (ev) {
                            console.log(ev);
                            // To me this looks cleaner than adding $apply(); after everything.
                            scope.$apply(function () {
                                ngModelCtrl.$setViewValue(ev.format(format));
                            });
                        });
                    }
                }
            }
        }
    });

    app.config(['growlProvider', function (growlProvider) {
        growlProvider.globalTimeToLive(5000);
        growlProvider.globalPosition('bottom-center');
    }]);
        
})();