using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaobaoKe.Core.IPC
{
    public class IpcResult
    {
        public IpcResult(bool success, string result)
        {
            this.Success = success;
            this.Result = result;
        }
        
        public bool Success { get; private set; }

        public string Result { get; private set; }
    }
}
