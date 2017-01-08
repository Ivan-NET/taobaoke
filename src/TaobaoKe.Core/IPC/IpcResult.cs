using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Core.IPC
{
    [Serializable]
    public class IpcResult
    {
        private IpcResult()
        {
        }

        public IpcResult(bool success, string result)
        {
            this.Success = success;
            this.Result = result;
        }
        
        public bool Success { get; set; }

        public string Result { get; set; }
    }
}
