using Libvirt.Models.Interface;
using Libvirt_Pinvoke.Models.Concrete;
using System;

namespace Libvirt.Models.Concrete
{
    public class Graphics : IXML, IValidation
    {
        public enum Graphic_Types { vnc, spice };

        public Graphics()
        {
            Reset();
        }
        public Graphic_Types Graphic_Type { get; set; }
        public int _port = -1;
        public Graphics_Listen Graphics_Listen { get; set; }
        public string listen { get; set; }
        public string passwd { get; set; }
        public int? websocket { get; set; }
        public int port
        {
            get { return _port; }
            set
            {
                if (value == -1) autoport = true;
                else autoport = false;
                _port = value;
            }
        }
        public bool _autoport = true;
        public bool autoport
        {
            get { return _autoport; }
            set
            {
                if (value) _port = -1;
                else if (_port <= -1) _port = 5900;
                _autoport = value;
            }
        }
        private void Reset()
        {
            Graphic_Type = Graphic_Types.vnc;
            _port = -1;
            websocket = -1;
            autoport = true;
        }
        public string To_XML()
        {
            var ret = "<graphics type='" + Graphic_Type.ToString() + "' port='" + _port.ToString() + "' " + (autoport ? "autoport='yes'" : "") + (!string.IsNullOrWhiteSpace(passwd) ? "passwd='" + passwd + "'" : "") + (websocket.HasValue ? "websocket='" + websocket.Value.ToString() + "'" : "") + " >";
            if (Graphics_Listen != null) ret += Graphics_Listen.To_XML();
            ret += "</graphics>";
            return ret;
        }
        public void Validate(IValdiator v)
        {
            if (_autoport && _port != -1)
            {
                v.AddError("autoport", "If autoport is true, port must also be -1");
            }
            if (websocket.HasValue && Graphic_Type == Graphic_Types.spice)
            {
                v.AddError("websocket", "websocket must be null if the graphics type is spice.");
            }
        }

        public void From_XML(System.Xml.Linq.XElement xml)
        {
            Reset();
            var element = xml.Element("graphics");
            if (element != null)
            {
                var type = element.Attribute("type");
                if (type != null)
                {
                    var a = Graphic_Types.vnc;
                    Enum.TryParse(type.Value, out a);
                    Graphic_Type = a;
                }
                type = element.Attribute("port");
                if (type != null)
                {
                    var a = -1;
                    Int32.TryParse(type.Value, out a);
                    port = a;
                }
                type = element.Attribute("autoport");
                if (type != null)
                {
                    if (type.Value == "yes") autoport = true;
                    else autoport = false;
                }
                type = element.Attribute("passwd");
                if (type != null) passwd = type.Value;
                type = element.Attribute("listen");
                if (type != null) listen = type.Value;
                type = element.Attribute("websocket");
                if (type != null)
                {
                    int a = -1;
                    if(Int32.TryParse(type.Value, out a))
                    {
                        websocket = a;
                    }
                }

            }
            var sublisten = element.Element("listen");
            if (sublisten != null)
            {
                Graphics_Listen = new Graphics_Listen();
                Graphics_Listen.From_XML(sublisten);
            }
        }
    }
}