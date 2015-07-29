namespace Libvirt_Pinvoke.CS_Objects.Extensions
{
    public static class Storage_Volume_Extensions
    {
        public static void Upload(this Libvirt.CS_Objects.Storage_Volume s, Libvirt.CS_Objects.Host host, System.IO.Stream stream)
        {
            using (var st = host.virStreamNew(Libvirt.virStreamFlags.VIR_STREAM_NONBLOCK))
            {
                var stupload = s.virStorageVolUpload(st, 0, (ulong)stream.Length);
                long chunksize = 65000;
                var dat = new byte[chunksize];
                var totalbytes = stream.Length;
                while (totalbytes > 0)
                {
                    var bytestoread = chunksize;
                    if (totalbytes < bytestoread)
                    {
                        bytestoread = totalbytes;
                    }
                    var bread = (uint)stream.Read(dat, 0, (int)bytestoread);
                    var bytessent = st.virStreamSend(dat, bread);
                    if (bytessent < 0)
                    {
                        st.virStreamAbort();
                        break;//get out!!
                    }
                    totalbytes -= (long)bread;

                }
                st.virStreamFinish();
            }
        }
    }
}
