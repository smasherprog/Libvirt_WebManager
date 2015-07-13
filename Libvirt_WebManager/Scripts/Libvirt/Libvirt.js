var Libvirt = Libvirt || {};

function namespace(ns, ns_string) {
    var parts = ns_string.split('.'),
        parent = ns,
        pl, i;
    if (parts[0] == "Libvirt") {
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

Libvirt.Config.HostAPIUrl = 'Api/Host/';
