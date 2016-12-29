using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Core.IPC
{
    public abstract class IpcClient : IDisposable
    {
        public abstract void Start();

        public abstract void Stop();

        public bool Started { get; protected set; }

        public abstract IpcResult Send(IpcArgs args, int timeout = 3000);

        public abstract void Dispose();
    }
}
