using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NodeJsDublin
{
    public partial class Form1 : Form
    {

        List<PerformanceCounter> memcounters = new List<PerformanceCounter>();

        List<PerformanceCounter> cpucounters = new List<PerformanceCounter>();



        public Form1()
        {

            InitializeComponent();

            Process[] localAll = Process.GetProcesses();

            foreach (var process in localAll)
            {
                if(process.ProcessName.StartsWith("node") || process.ProcessName.StartsWith("WebServer"))
                processList.Items.Add(process.ProcessName + "-" + process.Id + "-" + process.StartInfo.Arguments);

            }

        }



        private void createperfcounter(string processname)
        {

            PerformanceCounter cpu =

                new PerformanceCounter(

                    "Process", "% Processor Time", processname, true);



            cpucounters.Add(cpu);



            PerformanceCounter mem =

                new PerformanceCounter(

                    "Process", "Working Set", processname, true);



            memcounters.Add(mem);



        }



        private void Form1_Load(object sender, EventArgs e)
        {

            Console.WriteLine("Press the any key to stop...\n");

        }



        private void timer1_Tick(object sender, EventArgs e)
        {

            double date = DateTime.Now.ToOADate();

            try
            {

                foreach (var counter in memcounters)
                {

                    double pnt = counter.NextValue();
                    pnt = Math.Round(pnt / 1048576);
                    DataPoint dp = new DataPoint(date, pnt);

                    chart1.Series[counter.InstanceName].Points.Add(dp);

                }



                foreach (var counter in cpucounters)
                {

                    double pnt = counter.NextValue();

                    DataPoint dp = new DataPoint(date, pnt);

                    chart2.Series[counter.InstanceName].Points.Add(dp);

                }

            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

        }



        private void processList_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (e.NewValue == CheckState.Checked)
            {

                string[] spliters = { "-" };

                string value = processList.Items[e.Index].ToString();

                string instanceName = value.Split(spliters, StringSplitOptions.None).FirstOrDefault();

                this.createperfcounter(instanceName);



                Series series = new Series(instanceName);

                series.ChartType = SeriesChartType.FastLine;

                series.BorderWidth = 5;



                Series cpuseries = new Series(instanceName);

                cpuseries.ChartType = SeriesChartType.FastLine;

                cpuseries.BorderWidth = 5;

                chart1.Series.Add(series);

                chart2.Series.Add(cpuseries);



            }

        }


        

    }
}
