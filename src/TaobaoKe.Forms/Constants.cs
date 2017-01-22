
using System.IO;
using System.Windows.Forms;

namespace TaobaoKe.Forms
{
    public static class Constants
    {
        public static readonly string ConfigFilePath = Path.Combine(Application.StartupPath, "config.dat");

        public static readonly string CQImagePath = Path.Combine(Application.StartupPath + @"\CQ\data\image\");

        public static readonly string CQPath = Path.Combine(Application.StartupPath + @"\CQ\CQA.exe");

        public static readonly string CQProxyPath = Path.Combine(Application.StartupPath + @"\CQ\Flexlive.CQP.CSharpProxy.exe");

    }
}
