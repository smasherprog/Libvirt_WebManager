using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt.Utilities
{
    public class Default_EventLoop : IDisposable
    {

        private bool KeepRunningLoop = true;
        private Libvirt.virFreeCallback _FuncDeclare_To_Keep_GC_From_Collecting_free;
        private Libvirt.virEventTimeoutCallback _FuncDeclare_To_Keep_GC_From_Collecting;
  
        private int TimerHandle = -1;
        public Default_EventLoop()
        {
            _FuncDeclare_To_Keep_GC_From_Collecting = virEventTimeoutCallback;
            _FuncDeclare_To_Keep_GC_From_Collecting_free = DummyFree;
            Libvirt.API.virEventRegisterDefaultImpl();
      
            TimerHandle = Libvirt.API.virEventAddTimeout(1000, _FuncDeclare_To_Keep_GC_From_Collecting, IntPtr.Zero, _FuncDeclare_To_Keep_GC_From_Collecting_free);
            if (TimerHandle < 0)
            {
                Debug.WriteLine("Could not register callback for event loop. This will lead to instability within the program.");
            }
        }


        void DummyFree(IntPtr opaque)
        {
            //Does nothing on purpose!
        }
        void virEventTimeoutCallback(int timer, IntPtr opaque)
        {
            //Does nothing on purpose, this is to keep the event loop running with something to do 
        }
        public void Start(System.Threading.CancellationToken c)
        {
            while (!c.IsCancellationRequested && KeepRunningLoop)
            {
                try
                {
                    if (Libvirt.API.virEventRunDefaultImpl() != 0) break;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            KeepRunningLoop = false;
            if (!disposedValue)
            {
                if (TimerHandle > -1) Libvirt.API.virEventRemoveTimeout(TimerHandle);
                TimerHandle = -1;
                disposedValue = true;
            }
        }

        ~Default_EventLoop()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
