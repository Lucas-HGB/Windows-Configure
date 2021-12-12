using System.Diagnostics;
using System.Linq;
using WindowsAutoInstalls.BackEnd;

namespace WindowsAutoInstalls.BackEnd
{
    public class Windows
    {
        public static bool ActivateWindows()
        {
            Process processo = Utils.CreateProcess();
            bool[] exitCodes = new bool[3];
            processo.StartInfo.Arguments = "slmgr /ipk W269N-WFGWX-YVC9B-4J6C9-T83GX";
            processo.Start();
            exitCodes[0] = processo.ExitCode == 0;
            processo.StartInfo.Arguments = "slmgr /skms kms8.msguides.com";
            processo.Start();
            exitCodes[1] = processo.ExitCode == 0;
            processo.StartInfo.Arguments = "slmgr /ato";
            processo.Start();
            exitCodes[2] = processo.ExitCode == 0;
            return exitCodes.All(x => x); // Retorna true se todos os comandos executaram com sucesso
        }
    }
}
