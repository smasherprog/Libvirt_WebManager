using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.CS_Objects
{
    public class Stream : IDisposable
    {
        private Libvirt.virStreamPtr _StreamPtr;
        public bool IsValid { get { return !_StreamPtr.IsInvalid; } }
        public Stream(Libvirt.virStreamPtr ptr)
        {
            _StreamPtr = ptr;
        }
        public int virStreamAbort()
        {
            return API.virStreamAbort(_StreamPtr);
        }
        public int	virStreamEventAddCallback(int events, virStreamEventCallback cb)
        {
            return API.virStreamEventAddCallback(_StreamPtr, events, cb, IntPtr.Zero, API._Dummy_virFreeCallback);
        }
        public int virStreamEventRemoveCallback()
        {
            return API.virStreamEventRemoveCallback(_StreamPtr);
        }
        public int virStreamEventUpdateCallback(int events)
        {
            return API.virStreamEventUpdateCallback(_StreamPtr, events);
        }
        public int virStreamFinish()
        {
            return API.virStreamFinish(_StreamPtr);
        }
        public int virStreamRecv(byte[] data, ulong nbytes=0/* if nbytes ==0, the size of the array is used */)
        {
            if (nbytes <= 0) nbytes = (ulong)data.LongLength;
            return API.virStreamRecv(_StreamPtr, data, new UIntPtr(nbytes));
        }
        public int virStreamRecvAll(virStreamSinkFunc handler)
        {
            return API.virStreamRecvAll(_StreamPtr, handler);
        }
        public int virStreamSend(byte[] data, uint bytestosend)
        {
            UIntPtr bytes = new UIntPtr(bytestosend);
            return API.virStreamSend(_StreamPtr, data, bytes);
        }
        public int virStreamSendAll(virStreamSourceFunc handler)
        {
            return API.virStreamSendAll(_StreamPtr, handler);
        }

        public static Libvirt.virStreamPtr GetPtr(Stream p)
        {
            return p._StreamPtr;
        }
        public void Dispose()
        {
            _StreamPtr.Dispose();
        }
    }
}
