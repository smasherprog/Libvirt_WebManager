var Libvirt = Libvirt || {};

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
namespace(Libvirt, 'Libvirt.UI.Internal');
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

Libvirt.UI.Internal.OpenDialog = function (url, ctype) {
    var did = '_' + (new Date()).getTime();
    var newd = $("<div class='modal fade' tabindex='-1' role='dialog' id='" + did + "'><div class='modal-dialog " + ctype + "'><div class='modal-content'></div></div></div>");
    $('body').append(newd);
    $('#' + did + ' .modal-content').load(url);
    $('#' + did).modal('show');
    $('#' + did).on('hidden.bs.modal', function () {
        console.log('hiding stuff ' + did);
        $('#' + did).remove();
    });
    return newd;
}
Libvirt.UI.OpenDialog_sm = function (url) {
    return Libvirt.UI.Internal.OpenDialog(url, 'modal-sm');
}
Libvirt.UI.OpenDialog = function (url) {
    return Libvirt.UI.Internal.OpenDialog(url, '');
}
Libvirt.UI.OpenDialog_lg = function (url) {
    return Libvirt.UI.Internal.OpenDialog(url, 'modal-lg');
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
if (!String.prototype.format) {
    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
              ? args[number]
              : match
            ;
        });
    };
}
if (!String.prototype.replaceAll) {
    function escapeRegExp(string) {
        return string.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
    }
    String.prototype.replaceAll = function (find, replace) {
        return this.replace(new RegExp(escapeRegExp(find), 'g'), replace);
    };
}
Libvirt.Utilities.FormatBytes = function (bytes) {
    var scale = 1024;
    var possibles = ["TB", "GB", "MB", "KB", "Bytes"];
    var max = scale;
    for (var i = 0; i < possibles.length-2; i++) {
        max = max * scale;
    }
    for (var i = 0; i < possibles.length; i++) {
        if (bytes > max) {
            var re = Math.floor(bytes / max);
            console.log(re);
            return re + ' ' + possibles[i];
        }
            
        max /= scale;
    }
    return "0 Bytes";
}
