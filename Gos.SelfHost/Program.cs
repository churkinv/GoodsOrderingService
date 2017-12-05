using Gos.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Gos.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(GosService));
                host.Open();
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                host.Close(); // it will stop accepting new calls and complet the ones whis is in process
            }
            catch (Exception ex)
            {
                // log it
                Debug.WriteLine(ex.Message);
            }
           
        }
    }
}
