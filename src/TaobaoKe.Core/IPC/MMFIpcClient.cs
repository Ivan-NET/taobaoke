using Newtonsoft.Json;
using QuickIPC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaobaoKe.Core.IPC
{
    public class MMFIpcClient : IpcClient
    {
        private IpcService _ipcService = null;
        private Context _context;

        public MMFIpcClient(string name, Context context)
            : base(name)
        {
            this._context = context;
        }

        public event Recieve Recieve;

        protected override void OnStart()
        {
            if (_ipcService == null)
            {
                _ipcService = new IpcService(this._context);
                _ipcService.Init();
                _ipcService.IpcEvent += Listener_IpcEvent;
            }
        }

        void Listener_IpcEvent(object sender, TextualEventArgs eventArgs)
        {
            bool success = false;
            string result = string.Empty;
            string s = eventArgs.Data;
            if (this.Recieve != null)
            {
                string data = Encoding.UTF8.GetString( Convert.FromBase64String(eventArgs.Data));
                result = this.Recieve(JsonConvert.DeserializeObject<IpcArgs>(data));
                success = true;
            }
            IpcResult ipcResult = new IpcResult(success, result);
            _ipcService.Poke(JsonConvert.SerializeObject(ipcResult));
        }

        protected override void OnStop()
        {
            if (_ipcService != null)
                _ipcService.Dispose();
        }

        public override IpcResult Send(IpcArgs args, int timeout = 3000)
        {
            string jsonArgs = JsonConvert.SerializeObject(args);
            string data = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonArgs));
            _ipcService.Poke(data);
            string result = _ipcService.Peek();
            return JsonConvert.DeserializeObject<IpcResult>(result);
        }

        #region Singleton Default Instance

        private static MMFIpcClient _server;
        private static MMFIpcClient _client;

        public static MMFIpcClient Server
        {
            get
            {
                if (_server == null)
                {
                    string ipc_name = ConfigurationManager.AppSettings["ipc_name"];
                    if (string.IsNullOrEmpty(ipc_name))
                    {
                        throw new ArgumentNullException("应用程序的配置节中未设置ipc_name");
                    }
                    _server = new MMFIpcClient(ipc_name, Context.Server);
                }
                return _server;
            }
        }

        public static MMFIpcClient Client
        {
            get
            {
                if (_client == null)
                {
                    string ipc_name = ConfigurationManager.AppSettings["ipc_name"];
                    if (string.IsNullOrEmpty(ipc_name))
                    {
                        throw new ArgumentNullException("应用程序的配置节中未设置ipc_name");
                    }
                    _client = new MMFIpcClient(ipc_name, Context.Client);
                }
                return _client;
            }
        }

        #endregion
    }
}
