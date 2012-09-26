using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    class Program
    {

        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:9000/");
            listener.Start();

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                Process(context);
            }

        }



        private async static void Process(HttpListenerContext context)
        {
            if (context.Request.Url.AbsolutePath != "/")
            {
                context.Response.Close();
                return;
            }
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                ServiceReference1.Service1Client clnt1 = new ServiceReference1.Service1Client();
                ServiceReference1.Service1Client clnt2 = new ServiceReference1.Service1Client();

                Task<ServiceReference1.TestData[]> task1 = clnt1.GetDataUsingDataContractAsync();
                Task<ServiceReference1.TestData[]> task2 = clnt1.GetDataUsingDataContractAsync();
                
                ServiceReference1.TestData[] values = await task1;
                ServiceReference1.TestData[] values2 = await task2;

                StringBuilder bldr = new StringBuilder();
                foreach (var row in values)
                {
                    bldr.Append("{'name':'" + row.name + "','table':'" + row.table + "','date':" + row.date.ToFileTimeUtc().ToString() + "}"); 
                }
                foreach (var row in values2)
                {
                    bldr.Append("{'name':'" + row.name + "','table':'" + row.table + "','date':" + row.date.ToFileTimeUtc().ToString() + "}");
                }

                byte[] res = Encoding.UTF8.GetBytes(bldr.ToString());
                context.Response.OutputStream.Write(res, 0, res.Length);
                context.Response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                if (reader != null)
                    reader.Close();

                if (response != null)
                    response.Close();
            }
        }
    }
}
