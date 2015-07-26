﻿var Libvirt = Libvirt || {};

function namespace(ns, ns_string) {
    var parts = ns_string.split('.'),
        parent = ns,
        pl, i;
    if (parts[0] == 'Libvirt') {
        parts = parts.slice(1);
    }
    pl = parts.length;
    for (i = 0; i < pl; i++) {
        //create a property if it doesnt exist
        if (typeof parent[parts[i]] == 'undefined') {
            parent[parts[i]] = {};
        }
        parent = parent[parts[i]];
    }
    return parent;
}

namespace(Libvirt, 'Libvirt');
namespace(Libvirt, 'Libvirt.Host');
namespace(Libvirt, 'Libvirt.ViewModels.Host');
namespace(Libvirt, 'Libvirt.Config');
namespace(Libvirt, 'Libvirt.UI');
namespace(Libvirt, 'Libvirt.Utilities');

Libvirt.Config.HostAPIUrl = 'Api/Host/';
Libvirt.Config._Hub = null;
Libvirt.Hub = function () {
    if (Libvirt.Config._Hub == null) {
        Libvirt.Config._Hub = $.connection.libvirt_ManagerHub;
    }
    return Libvirt.Config._Hub;
}
Libvirt.Config._HubStarter = null;
Libvirt.HubStart = function () {
    if (Libvirt.Config._HubStarter === null) {
        Libvirt.Config._HubStarter = $.connection.hub.start();
    }
    return Libvirt.Config._HubStarter;
};

$(document).ready(function () {
    $('body').append("<div class='modal fade' tabindex='-1' role='dialog' id='MyModalDialogBoxArea_sm'><div class='modal-dialog modal-sm'><div class='modal-content'></div></div></div>");
    $('body').append("<div class='modal fade' tabindex='-1' role='dialog' id='MyModalDialogBoxArea'><div class='modal-dialog'><div class='modal-content'></div></div></div>");
    $('body').append("<div class='modal fade' tabindex='-1' role='dialog' id='MyModalDialogBoxArea_lg'><div class='modal-dialog modal-lg'><div class='modal-content'></div></div></div>");
});

Libvirt.UI.OpenDialog_sm = function (url) {
    $('#MyModalDialogBoxArea_sm .modal-content').load(url);
    $('#MyModalDialogBoxArea_sm').modal('show');
}
Libvirt.UI.OpenDialog = function (url) {
    $('#MyModalDialogBoxArea .modal-content').load(url);
    $('#MyModalDialogBoxArea').modal('show');
}
Libvirt.UI.OpenDialog_lg = function (url) {
    $('#MyModalDialogBoxArea_lg .modal-content').load(url);
    $('#MyModalDialogBoxArea_lg').modal('show');
}

//HOST
Libvirt.ViewModels.Host.List = function () {
    var self = this;
    self.items = ko.observableArray();

    self.refresh = function () {
        Libvirt.Host.Get(function (data) {
            self.items(data);
        });
    }
}

Libvirt.Host.Get = function (callback) {
    Ajax.GET(Libvirt.Config.HostAPIUrl, callback).error(
        function (jq, status, message) {
            alert('A jQuery error has occurred. Status: ' + status + ' - Message: ' + message);
        });
}


Libvirt.ViewModels.LogMessages = function () {
    var self = this;
    self.messages = ko.observableArray();
    self.AfterAdddingFunc = function (element, index, data) {
        $(element).addClass('bg-' + data.Message_Type)
    }
    self.AddMessage = function (message) {
        if (self.messages.length > 100) self.messages.pop();
        self.messages.push(message);
    }
    Libvirt.Hub().client.logEventReceived = function (message) {
        self.AddMessage(message);
    };
}


Libvirt.ViewModels.ErrorMessage = function (code, title, body, add_1, add_2, add_3, mes_type, time, onrecevnedcb) {
    var self = this;
    self.Code = ko.observable(code);
    self.Title = ko.observable(title);
    self.Body = ko.observable(body);
    self.Additional_Info_1 = ko.observable(add_1);
    self.Additional_Info_2 = ko.observable(add_2);
    self.Additional_Info_3 = ko.observable(add_3);
    self.Message_Type = ko.observable(mes_type);
    self.Time = ko.observable(time);
    self.OnReceviedCallback = onrecevnedcb;
    Libvirt.Hub().client.errorEventReceived = function (message) {
        self.Code(message.Code);
        self.Title(message.Title);
        self.Body(message.Body);
        self.Additional_Info_1(message.Additional_Info_1);
        self.Additional_Info_2(message.Additional_Info_2);
        self.Additional_Info_3(message.Additional_Info_3);
        self.Additional_Info_3(message.Additional_Info_3);
        self.Time(message.Time);
        self.OnReceviedCallback();
    };
}


