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
    $('.modal').on('hidden.bs.modal', function (event) {
        $(this).removeClass('fv-modal-stack');
        $('body').data('fv_open_modals', $('body').data('fv_open_modals') - 1);
    });
    $('.modal').on('shown.bs.modal', function (event) {
        if (typeof ($('body').data('fv_open_modals')) == 'undefined') {
            $('body').data('fv_open_modals', 0);
        }
        if ($(this).hasClass('fv-modal-stack')) {
            return;
        }
        $(this).addClass('fv-modal-stack');
        $('body').data('fv_open_modals', $('body').data('fv_open_modals') + 1);
        $(this).css('z-index', 1040 + (10 * $('body').data('fv_open_modals')));
        $('.modal-backdrop').not('.fv-modal-stack').css('z-index', 1039 + (10 * $('body').data('fv_open_modals')));
        $('.modal-backdrop').not('fv-modal-stack').addClass('fv-modal-stack');
    });
    window.addEventListener("submit", function (e) {
        var form = e.target;
        if (form.getAttribute("enctype") === "multipart/form-data") {
            if (form.dataset.ajax) {
                e.preventDefault();
                e.stopImmediatePropagation();
                var xhr = new XMLHttpRequest();
                var progressbar = $(form).find('.progress-bar');
                if (progressbar.length > 0) {
                    xhr.upload.onprogress = function (e) {
                        var done =e.loaded, total = e.total;
                        var present = Math.floor(done / total * 100);
                        $(progressbar).css('width', present + '%');
                        $(progressbar).html(present + '%');
                    }
                }
                xhr.open(form.method, form.action);
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 4 && xhr.status == 200) {
                        if (form.dataset.ajaxUpdate) {
                            
                            var updateTarget = document.querySelector(form.dataset.ajaxUpdate);
                           
                            if (updateTarget) {
                                var ajaxmode = $(form).attr('data-ajax-mode');
                                if (ajaxmode != null) {
                                    if (ajaxmode == 'replace-with') $(updateTarget).replaceWith(xhr.responseText);
                                    else $(updateTarget).html(xhr.responseText);
                                } else {
                                    $(updateTarget).replaceWith(xhr.responseText);
                                }
                      
                            }
                        }
                    }
                };

                xhr.send(new FormData(form));
            }
        }
    }, true);
});