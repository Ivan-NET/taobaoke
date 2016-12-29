using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tiesky.com;

namespace TaobaoKe.Core.IPC
{
    public delegate string Recieve(IpcArgs args);

    public class ShareMemoryIpcClient : IpcClient
    {
        private SharmIpc _sharmIpc = null;
        private string _uniqueName = string.Empty;

        public ShareMemoryIpcClient(string uniqueName)
        {
            _uniqueName = uniqueName;
        }

        public event Recieve Recieve;

        public override void Start()
        {
            if (_sharmIpc != null)
                _sharmIpc = new SharmIpc(_uniqueName, RemoteCall);
            this.Started = true;
        }

        public override void Stop()
        {
            if (_sharmIpc != null)
                _sharmIpc.Dispose();
            this.Started = false;
        }

        public override IpcResult Send(IpcArgs args, int timeout = 3000)
        {
            string jsonArgs = JsonConvert.SerializeObject(args);            
            Tuple<bool, byte[]> result = _sharmIpc.RemoteRequest(Encoding.UTF8.GetBytes(jsonArgs));
            return new IpcResult(result.Item1, Encoding.UTF8.GetString(result.Item2));
        }

        public override void Dispose()
        {
            this.Stop();
        }

        private Tuple<bool,byte[]> RemoteCall(byte[] data)
        {
            bool success = false;
            string result = string.Empty;
            if (Recieve != null)
            {
                string args = Encoding.UTF8.GetString(data);
                IpcArgs ipcArgs = JsonConvert.DeserializeObject<IpcArgs>(args);
                result = Recieve(ipcArgs);
                success = true;
            }
            return new Tuple<bool, byte[]>(success, Encoding.UTF8.GetBytes(result));
        }

        #region Singleton Default Instance

        private static ShareMemoryIpcClient _default;

        public static ShareMemoryIpcClient Default
        {
            get
            {
                if (_default == null)
                {
                    string ipc_name = ConfigurationManager.AppSettings["ipc_name"];
                    if (string.IsNullOrEmpty(ipc_name))
                    {
                        throw new ArgumentNullException("应用程序的配置节中未设置ipc_name");
                    }
                    _default = new ShareMemoryIpcClient(ipc_name);
                }
                return _default;
            }
        }

        #endregion
    }
}
