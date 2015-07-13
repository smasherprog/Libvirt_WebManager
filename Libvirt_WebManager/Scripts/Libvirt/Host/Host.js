
Libvirt.ViewModels.Host.List = function(){
    var self = this;
    self.items= ko.observableArray();

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



