using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Core.IPC
{
    public delegate string Recieve(IpcArgs args);

    public abstract class IpcClient : IDisposable
    {
        protected abstract void OnStart();
        protected abstract void OnStop();

        public void Start()
        {
            OnStart();
            this.Started = true;
        }

        public void Stop()
        {
            OnStop();
            this.Started = false;
        }

        public bool Started { get; private set; }

        public abstract IpcResult Send(IpcArgs args, int timeout = 3000);

        public void Dispose()
        {
            this.Stop();
        }
    }
}
