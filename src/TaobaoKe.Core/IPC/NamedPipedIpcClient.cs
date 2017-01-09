using MC.Messaging.Bus;
using MC.Messaging.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;

namespace TaobaoKe.Core.IPC
{
    public enum NamedPipedIpcClientContext
    {
        A,
        B
    }

    public class NamedPipedIpcClient : IpcClient
    {
        private Guid serverId;
        private Guid clientId;
        ICompositeServerMessageBus serverBus = null;
        IClientMessageBus clientBus = null;
        EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
        IpcResult _ipcResult = null;

        public NamedPipedIpcClient(string name, NamedPipedIpcClientContext context)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"D:\np.txt", true))
            {
                string a = ConvertToHexString(name + "A").PadLeft(32, '0');
                string b = ConvertToHexString(name + "B").PadLeft(32, '0');
                Guid guid_A = new Guid(a);
                Guid guid_B = new Guid(b);

                if (context == NamedPipedIpcClientContext.A)
                {
                    this.serverId = guid_A;
                    this.clientId = guid_B;
                }
                else if (context == NamedPipedIpcClientContext.B)
                {
                    this.serverId = guid_B;
                    this.clientId = guid_A;
                }
            }
        }

        public event Recieve Recieve;

        public Guid ServerId
        {
            get { return serverId; }
        }

        public Guid ClientId
        {
            get { return clientId; }
        }

        public bool ClientConnected { get; private set; }

        public override IpcResult Send(IpcArgs args, int timeout = 3000)
        {
            _ipcResult = null;
            waitHandle.Reset();

            serverBus.GetOrCreate(serverId).Publish<IpcArgs>(args);
            if (waitHandle.WaitOne(timeout)) // 等待结果
                return _ipcResult;
            return new IpcResult(false, "发送超时");
        }

        protected override void OnStart()
        {
            serverBus = new CompositeServerMessageBus();
            serverBus.GetOrCreate(serverId).Subscribe<IpcResult>(HandleResult);

            clientBus = new ClientMessageBus(clientId);
            ThreadPool.QueueUserWorkItem(InitClientBus);
        }

        private void InitClientBus(object state)
        {
            clientBus.Subscribe<IpcArgs>(HandleMessage);
            this.ClientConnected = true;
        }

        private void HandleMessage(object sender, MessageReceivedEventArgs<IpcArgs> e)
        {
            //e.Message.Content;
            bool success = false;
            string result = string.Empty;
            if (Recieve != null)
            {
                result = Recieve(e.Message);
                success = true;
            }
            IpcResult ipcResult = new IpcResult(success, result);
            clientBus.Publish<IpcResult>(ipcResult);
        }

        private void HandleResult(object sender, MessageReceivedEventArgs<IpcResult> e)
        {
            _ipcResult = e.Message;
            waitHandle.Set();
        }

        protected override void OnStop()
        {
            serverBus = null;
            clientBus = null;
            this.ClientConnected = false;
        }

        private string ConvertToHexString(string input)
        {
            StringBuilder sb = new StringBuilder();
            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form.
                sb.Append(String.Format("{0:X}", value));
            }
            return sb.ToString();
        }

        #region Singleton Default Instance

        private static NamedPipedIpcClient _default_A;
        private static NamedPipedIpcClient _default_B;

        public static NamedPipedIpcClient Default_A
        {
            get
            {
                if (_default_A == null)
                {
                    string ipc_name = "testpipe";//ConfigurationManager.AppSettings["ipc_name"];
                    if (string.IsNullOrEmpty(ipc_name))
                    {
                        throw new ArgumentNullException("应用程序的配置节中未设置ipc_name");
                    }
                    _default_A = new NamedPipedIpcClient(ipc_name, NamedPipedIpcClientContext.A);
                }
                return _default_A;
            }
        }

        public static NamedPipedIpcClient Default_B
        {
            get
            {
                if (_default_B == null)
                {
                    string ipc_name = "testpipe";//ConfigurationManager.AppSettings["ipc_name"];
                    if (string.IsNullOrEmpty(ipc_name))
                    {
                        throw new ArgumentNullException("应用程序的配置节中未设置ipc_name");
                    }
                    _default_B = new NamedPipedIpcClient(ipc_name, NamedPipedIpcClientContext.B);
                }
                return _default_B;
            }
        }

        #endregion
    }
}
