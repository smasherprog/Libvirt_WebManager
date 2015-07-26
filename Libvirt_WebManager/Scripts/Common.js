ko.bindingHandlers.tooltip = {
    init: function (element, valueAccessor) {
        var local = ko.utils.unwrapObservable(valueAccessor()),
            options = {};

        ko.utils.extend(options, ko.bindingHandlers.tooltip.options);
        ko.utils.extend(options, local);

        $(element).tooltip(options);

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).tooltip("destroy");
        });
    },
    options: {
        trigger: "click"
    }
};
ko.bindingHandlers.popover = {
    init: function (element, valueAccessor) {
        var local = ko.utils.unwrapObservable(valueAccessor()),
            options = {};

        ko.utils.extend(options, ko.bindingHandlers.popover.options);
        ko.utils.extend(options, local);

        $(element).popover(options);

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).popover("destroy");
        });
    },
    options: {
        trigger: "click"
       
    }
};
var currenturl = '';
function LoadMainContent(url) {
    if (url == currenturl) return;
    else {
        currenturl = url;
        $('#main_content_area').load(url);
    }
}
$(document).ready(function () {
    $('.dropdown-toggle').dropdown();
    $("body").tooltip({ selector: '[data-toggle="tooltip"]' });
    context.init({ preventDoubleContext: false });
    $.ajaxSetup({ cache: false });
    Chart.defaults.global.responsive = true;
});