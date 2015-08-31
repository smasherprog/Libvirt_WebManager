using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libvirt_Pinvoke.CS_Objects.Container
{
    public class LibvirtContainer<T> : IEnumerable<T>, IDisposable where T : IDisposable
    {
        T[] m_Items = null;

        public LibvirtContainer(T[] items)
        {
            m_Items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in m_Items)
            {
                yield return t;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return this.GetEnumerator();
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var item in m_Items) item.Dispose();

                }
                m_Items = null;
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
