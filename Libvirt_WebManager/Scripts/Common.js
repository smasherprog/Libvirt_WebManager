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
$(document).ready(function () {
    $('.dropdown-toggle').dropdown();
    context.init({ preventDoubleContext: false });
    $.ajaxSetup({ cache: false });
});