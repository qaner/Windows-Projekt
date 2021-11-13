using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace QAner_Service
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        static void Main()
        {
            Service1 service = new Service1();
            service.Getmain();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
}
